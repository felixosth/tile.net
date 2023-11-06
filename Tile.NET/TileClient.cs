using Newtonsoft.Json;
using System.Net;
using Tile.NET.Exceptions;
using Tile.NET.Model;
using Tile.NET.Model.Api;

namespace Tile.NET
{
    public interface ITileClient
    {
        Task Initialize(string email, string password, Guid clientId = default);
        Task<IEnumerable<TileTracker>> GetTiles();
    }

    public class TileClient : ITileClient
    {
        private const string API_URL = "https://production.tile-api.com";
        private const string API_VERSION = "1.0";
        private const string APP_ID = "ios-tile-production";
        private const string APP_VERSION = "2.89.1.4774";
        private const string LOCALE = "en-GB";
        private const string USER_AGENT = "Tile/4774 CFNetwork/1312 Darwin/21.0.0";

        private string? _clientId;
        private string? _userId;

        private readonly CookieContainer _cookieContainer = new CookieContainer();

        private DateTimeOffset _sessionExpiration = DateTimeOffset.UtcNow;
        public DateTimeOffset SessionExpiration => _sessionExpiration;

        public async Task Initialize(string email, string password, Guid clientId = default)
        {
            _clientId = clientId != default ? clientId.ToString() : Guid.NewGuid().ToString();

            var clientRequestData = new Dictionary<string, string>()
                {
                    { "app_id", APP_ID },
                    { "app_version", APP_VERSION },
                    { "locale", LOCALE }
                };

            await Request<ClientResponse>(HttpMethod.Put, $"clients/{_clientId}", clientRequestData);

            var requestData = new Dictionary<string, string>()
                {
                    { "email", email },
                    { "password", password },
                };

            var loginResponse = await Request<SessionResponse>(HttpMethod.Post, $"clients/{_clientId}/sessions", requestData);

            _userId = loginResponse.result.user.user_uuid;
            _sessionExpiration = DateTimeOffset.FromUnixTimeMilliseconds(loginResponse.result.session_expiration_timestamp);
        }

        public async Task<IEnumerable<TileTracker>> GetTiles()
        {
            ThrowExceptionIfSessionIsInvalid();

            var stateResponse = await Request<TileStateResponse>(HttpMethod.Get, "tiles/tile_states", null);

            var tileTrackers = stateResponse.result.Select(x => new TileTracker(x.tile_id, GetTileDetails)).ToList();

            var updateTileTrackersTasks = tileTrackers.Select(x => x.UpdateData());

            await Task.WhenAll(updateTileTrackersTasks);

            return tileTrackers;
        }

        private async Task<T> Request<T>(HttpMethod method, string uri, Dictionary<string, string>? requestData)
        {
            var request = new HttpRequestMessage(method, $"api/v1/{uri}");

            if (requestData != null)
                request.Content = new FormUrlEncodedContent(requestData);

            using var httpClient = BuildHttpClient();
            HttpResponseMessage? response = null;

            response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException("Failed to login");
            else if (!response.IsSuccessStatusCode)
                throw new RequestException(response.StatusCode.ToString(), (int)response.StatusCode);

            var responseData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseData)!;
        }

        private HttpClient BuildHttpClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = _cookieContainer
            };

            var httpClient = new HttpClient(httpClientHandler);

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(USER_AGENT);

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("tile_api_version", API_VERSION);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("tile_app_id", APP_ID);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("tile_app_version", APP_VERSION);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("tile_client_uuid", _clientId);

            httpClient.BaseAddress = new Uri(API_URL);

            return httpClient;
        }

        private Task<TileResponse> GetTileDetails(TileTracker tile)
        {
            ThrowExceptionIfSessionIsInvalid();
            return Request<TileResponse>(HttpMethod.Get, $"tiles/{tile.UUID}", null);
        }

        private void ThrowExceptionIfSessionIsInvalid()
        {
            if (_userId == null || DateTimeOffset.UtcNow > _sessionExpiration.AddMinutes(-1))
            {
                throw new SessionException();
            }
        }
    }
}