namespace Tile.NET.Model.Api
{
    internal class TileStateResponse
    {
        public int version { get; set; }
        public int revision { get; set; }
        public DateTime timestamp { get; set; }
        public long timestamp_ms { get; set; }
        public int result_code { get; set; }
        public TileStateResult[] result { get; set; }
    }

    internal class TileStateResult
    {
        public Location location { get; set; }
        public string tile_id { get; set; }
        public Mark_As_Lost mark_as_lost { get; set; }
    }

    internal class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public long location_timestamp { get; set; }
        public float horizontal_accuracy { get; set; }
        public string client_name { get; set; }
    }

    internal class Mark_As_Lost
    {
        public int timestamp { get; set; }
        public bool is_lost { get; set; }
        public bool is_owner_contact_provided { get; set; }
    }

}
