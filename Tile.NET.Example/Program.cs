// See https://aka.ms/new-console-template for more information
using System.Reflection;
using Tile.NET;
using Tile.NET.Model;

var email = "your@email.com";
var password = "pwd";

var client = new TileClient(email, password);
await client.Initialize();
var tiles = await client.GetTiles();

var tileProperties = typeof(TileTracker).GetProperties();

foreach (var tile in tiles)
{
    foreach (PropertyInfo prop in tileProperties)
    {
        Console.WriteLine("[{0}] {1} = {2}", prop.PropertyType.Name, prop.Name, prop.GetValue(tile, null)?.ToString());
    }

    if (tile != tiles.Last())
        Console.WriteLine("----------------------------------");
}