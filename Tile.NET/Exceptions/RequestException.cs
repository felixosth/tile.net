namespace Tile.NET.Exceptions
{
    public class RequestException : TileClientException
    {
        public int HttpStatusCode { get; set; }

        public RequestException(string message, int httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
