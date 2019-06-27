using System;

namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO
{
    internal class GetSlotCampaignsRequestModel
    {
        public string Name { get; set; }
        public int? GameId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public int MerchantId { get; set; }
        public string OrderingField { get; set; }
        public string OrderingDirection { get; set; }
        public int? CampaignId { get; set; }
        public string Hash { get; set; }
    }
}
