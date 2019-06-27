using System;

namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO
{
    internal class SlotCampaignModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GameId { get; set; }
        public int CampaignTypeId { get; set; }
        public int FreespinCount { get; set; }
        public int StatusId { get; set; }
        public int PlayerCount { get; set; }
        public int FilteredCount { get; set; }
    }
}