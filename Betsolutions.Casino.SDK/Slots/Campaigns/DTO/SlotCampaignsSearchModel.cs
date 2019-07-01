using System;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Slots.Campaigns.Enums;

namespace Betsolutions.Casino.SDK.Slots.Campaigns.DTO
{
    public class SlotCampaignsSearchModel
    {
        public string Name { get; set; }
        public int? GameId { get; set; }
        public CampaignStatus? Status { get; set; }
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
        public int? CampaignId { get; set; }
    }
}
