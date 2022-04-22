namespace Tile.NET.Model.Api
{
    internal class SessionResponse
    {
        public int version { get; set; }
        public int revision { get; set; }
        public DateTime timestamp { get; set; }
        public long timestamp_ms { get; set; }
        public int result_code { get; set; }
        public Session result { get; set; }
    }

    internal class Session
    {
        public string client_uuid { get; set; }
        public User user { get; set; }
        public long session_start_timestamp { get; set; }
        public long session_expiration_timestamp { get; set; }
        public string changes { get; set; }
    }

    internal class User
    {
        public string user_uuid { get; set; }
        public object full_name { get; set; }
        public string email { get; set; }
        public bool beta_eligibility { get; set; }
        public bool gift_recipient { get; set; }
        public string locale { get; set; }
        public bool email_shared { get; set; }
        public object image_url { get; set; }
        public string status { get; set; }
        public bool pw_exists { get; set; }
        public long registration_timestamp { get; set; }
        public object email_change_request { get; set; }
        public object[] linked_accounts { get; set; }
        public object shipping_address_timestamp { get; set; }
        public long last_modified_timestamp { get; set; }
    }

}
