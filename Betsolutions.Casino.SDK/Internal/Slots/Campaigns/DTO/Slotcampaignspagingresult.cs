using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO
{
    internal class SlotCampaignsPagingResult
    {
        public int TotalCount { get; set; }
        public List<SlotCampaignModel> Campaigns { get; set; }
    }
}