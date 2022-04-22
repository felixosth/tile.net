namespace Tile.NET.Model.Api
{
    internal class ClientResponse
    {
        public int version { get; set; }
        public int revision { get; set; }
        public DateTime timestamp { get; set; }
        public long timestamp_ms { get; set; }
        public int result_code { get; set; }
        public Client result { get; set; }
    }

    internal class Client
    {
        public string locale { get; set; }
        public string entityName { get; set; }
        public string client_uuid { get; set; }
        public string app_id { get; set; }
        public string app_version { get; set; }
        public object os_name { get; set; }
        public object os_release { get; set; }
        public object model { get; set; }
        public object signed_in_user_uuid { get; set; }
        public long registration_timestamp { get; set; }
        public object user_device_name { get; set; }
        public bool beta_option { get; set; }
        public long last_modified_timestamp { get; set; }
    }

}
