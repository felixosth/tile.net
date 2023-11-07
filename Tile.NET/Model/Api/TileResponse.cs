namespace Tile.NET.Model.Api
{
    public class TileResponse
    {
        public int version { get; set; }
        public int revision { get; set; }
        public DateTime timestamp { get; set; }
        public long timestamp_ms { get; set; }
        public int result_code { get; set; }
        public TileTrackerResult result { get; set; }
    }

    public class TileTrackerResult
    {
        public long last_modified_timestamp { get; set; }
        public string status { get; set; }
        public object node_type { get; set; }
        public long activation_timestamp { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
        public string image_url { get; set; }
        public string product { get; set; }
        public bool visible { get; set; }
        public object permissions_mask { get; set; }
        public object[] parents { get; set; }
        public object user_node_relationships { get; set; }
        public User_Node_Data user_node_data { get; set; }
        public string archetype { get; set; }
        public string owner_user_uuid { get; set; }
        public string thumbnail_image { get; set; }
        public object group { get; set; }
        public string tile_uuid { get; set; }
        public string firmware_version { get; set; }
        public object category { get; set; }
        public object superseded_tile_uuid { get; set; }
        public bool is_dead { get; set; }
        public string? hw_version { get; set; }
        public Configuration configuration { get; set; }
        public Last_Tile_State last_tile_state { get; set; }
        public object firmware { get; set; }
        public object auth_key { get; set; }
        public string renewal_status { get; set; }
        public Metadata metadata { get; set; }
        public string battery_status { get; set; }
        public object serial_number { get; set; }
        public bool auto_retile { get; set; }
        public object all_user_node_relationships { get; set; }
        public bool is_lost { get; set; }
        public int auth_timestamp { get; set; }
        public string tile_type { get; set; }
        public long registration_timestamp { get; set; }
        public object product_friendly_name { get; set; }
    }

    public class User_Node_Data
    {
    }

    public class Configuration
    {
        public object fw10_advertising_interval { get; set; }
    }

    public class Last_Tile_State
    {
        public string uuid { get; set; }
        public int connectionStateCode { get; set; }
        public int ringStateCode { get; set; }
        public string tile_uuid { get; set; }
        public string client_uuid { get; set; }
        public long timestamp { get; set; }
        public object advertised_rssi { get; set; }
        public float client_rssi { get; set; }
        public float battery_level { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float altitude { get; set; }
        public float raw_h_accuracy { get; set; }
        public float v_accuracy { get; set; }
        public float speed { get; set; }
        public float course { get; set; }
        public object authentication { get; set; }
        public bool owned { get; set; }
        public object has_authentication { get; set; }
        public int lost_timestamp { get; set; }
        public string connection_client_uuid { get; set; }
        public long connection_event_timestamp { get; set; }
        public int last_owner_update { get; set; }
        public object partner_id { get; set; }
        public object partner_client_id { get; set; }
        public float speed_accuracy { get; set; }
        public float course_accuracy { get; set; }
        public long discovery_timestamp { get; set; }
        public string connection_state { get; set; }
        public string ring_state { get; set; }
        public bool is_lost { get; set; }
        public float h_accuracy { get; set; }
        public string voip_state { get; set; }
    }

    public class Metadata
    {
    }

}
