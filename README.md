# Tile.NET: A simple .NET API for Tile® Bluetooth trackers

Tile.NET is a simple .NET library for retrieving information on [Tile® Bluetooth trackers](https://www.thetileapp.com/en-us/) (including last location and more).

This library is built on an unpublished, unofficial Tile API; it may alter or cease operation at any point.

The code is ported (copy pasted) from the python library [pytile](https://github.com/bachya/pytile).

## Usage

```csharp

var email = "your@email.com";
var password = "pwd";

var client = new TileClient(email, password);

await client.Initialize();

var tiles = await client.GetTiles();

...

// Check if the session is expired before fetching the tiles and call Initialize again if needed
if (DateTimeOffset.Now > client.SessionExpiration)
{
    await client.Initialize();
}

```

### Examples

See the Wpf and Console project examples.

Console
![Console example](/Assets/example_console.png)
Wpf
![Wpf example](/Assets/example_wpf.png)

## Contributing
There's plenty of room for improvements so drop a PR if you'd like, or submit an issue.
