using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tile.NET.Model.Api;

namespace Tile.NET.Model
{
    public class TileTracker
    {
        private TileTrackerResult? _tileData;
        private readonly Func<TileTracker, Task<TileResponse>> _updateDataFactory;
        private readonly string _uuid;

        internal TileTracker(string uuid, Func<TileTracker, Task<TileResponse>> updateDataFactory)
        {
            _uuid = uuid;
            _updateDataFactory = updateDataFactory;
        }

        public async Task UpdateData()
        {
            var response = await _updateDataFactory(this);

            _tileData = response.result;
        }

        public string Name => _tileData!.name;
        public string Status => _tileData!.status;
        public string Product => _tileData!.product;
        public string Archetype => _tileData!.archetype;
        public string Type => _tileData!.tile_type;
        public string FirmwareVersion => _tileData!.firmware_version;
        public string? HardwareVersion => _tileData?.hw_version;

        public float BatteryLevel => _tileData!.last_tile_state.battery_level;

        public bool IsLost => _tileData!.is_lost;
        public bool IsDead => _tileData!.is_dead;

        public string ImageUrl => _tileData!.image_url;
        public string ThumbnailUrl => _tileData!.thumbnail_image;

        public float Latitude => _tileData!.last_tile_state.latitude;
        public float Longitude => _tileData!.last_tile_state.longitude;
        public float Altitude => _tileData!.last_tile_state.altitude;
        
        public float Speed => _tileData!.last_tile_state.speed;
        public float Course => _tileData!.last_tile_state.course;
        public float SpeedAccuracy => _tileData!.last_tile_state.speed_accuracy;

        public float VerticalAccuracy => _tileData!.last_tile_state.v_accuracy;
        public float HorizontalAccuracy => _tileData!.last_tile_state.h_accuracy;
        
        public DateTimeOffset LastTimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(_tileData!.last_tile_state.timestamp);
        public DateTimeOffset LastTimestampLocal => DateTimeOffset.FromUnixTimeMilliseconds(_tileData!.last_tile_state.timestamp).ToLocalTime();
        public DateTimeOffset LostTimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(_tileData!.last_tile_state.lost_timestamp);
        public DateTimeOffset LostTimestampLocal => DateTimeOffset.FromUnixTimeMilliseconds(_tileData!.last_tile_state.lost_timestamp).ToLocalTime();
        public DateTimeOffset RegistrationTimestampUtc => DateTimeOffset.FromUnixTimeMilliseconds(_tileData!.registration_timestamp);
        public DateTimeOffset RegistrationTimestampLocal => DateTimeOffset.FromUnixTimeMilliseconds(_tileData!.registration_timestamp).ToLocalTime();

        public string UUID => _uuid;
    }
}
