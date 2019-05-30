using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.DTO.Game
{
    internal class Game
    {
        public int GameId { get; set; }
        public int ProductId { get; set; }
        public bool HasFreeplay { get; set; }
        public string Name { get; set; }
        public string LaunchUrl { get; set; }
        public int? RTP { get; set; }
        public int? RakePercent { get; set; }
        public bool HasMobileDeviceSupport { get; set; }
        public IEnumerable<GameThumbnail> Thumbnails { get; set; }
    }
}