using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO
{
    internal class AddPlayerToCampaignRequestModel
    {
        public int MerchantId { get; set; }
        public int CampaignId { get; set; }
        public List<string> PlayerIds { get; set; }
        public string Hash { get; set; }
    }
}
