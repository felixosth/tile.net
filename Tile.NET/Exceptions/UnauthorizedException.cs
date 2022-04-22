namespace Tile.NET.Exceptions
{
    public class UnauthorizedException : TileClientException
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }
}
