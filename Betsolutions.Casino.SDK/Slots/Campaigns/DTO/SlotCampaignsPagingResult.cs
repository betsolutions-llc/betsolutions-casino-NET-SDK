using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Slots.Campaigns.DTO
{
    public class SlotCampaignsPagingResult
    {
        public int TotalCount { get; set; }
        public List<SlotCampaign> Campaigns { get; set; }
    }
}
