namespace Tile.NET.Exceptions
{
    public class SessionException : TileClientException
    {
        public SessionException() : base("Session invalid or expired")
        {
        }
    }
}
