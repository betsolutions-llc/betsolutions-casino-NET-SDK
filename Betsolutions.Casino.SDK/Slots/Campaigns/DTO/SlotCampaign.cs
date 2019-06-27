using System;
using Betsolutions.Casino.SDK.Slots.Campaigns.Enums;

namespace Betsolutions.Casino.SDK.Slots.Campaigns.DTO
{
    public class SlotCampaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GameId { get; set; }
        public CampaignType CampaignType { get; set; }
        public int FreeSpinCount { get; set; }
        public CampaignStatus Status { get; set; }
        public int PlayerCount { get; set; }
        public int FilteredCount { get; set; }
    }
}
