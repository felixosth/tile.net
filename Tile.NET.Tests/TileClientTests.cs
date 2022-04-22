using Xunit;
using Tile.NET.Exceptions;

namespace Tile.NET.Tests
{
    public class TileClientTests
    {
        [Fact]
        public void InvalidSessionThrowsException()
        {
            var tileClient = new TileClient("", "");
            Assert.ThrowsAsync<SessionException>(async () => await tileClient.GetTiles());
        }

        [Fact]
        public void InvalidLoginThrowsException()
        {
            var tileClient = new TileClient("", "");
            Assert.ThrowsAsync<UnauthorizedException>(async () => await tileClient.Initialize());
        }
    }
}