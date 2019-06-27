using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Slots.Campaigns.DTO
{
    public class AddPlayersToCampaignRequest
    {
        public int CampaignId { get; set; }
        public List<string> PlayerIds { get; set; }
    }
}
