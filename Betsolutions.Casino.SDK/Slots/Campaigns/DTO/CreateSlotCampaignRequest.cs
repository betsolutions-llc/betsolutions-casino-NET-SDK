using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.Slots.Campaigns.Enums;

namespace Betsolutions.Casino.SDK.Slots.Campaigns.DTO
{
    public class CreateSlotCampaignRequest
    {
        public IEnumerable<SlotCampaignBetAmountCurrency> BetAmountsPerCurrency { get; set; }
        public CampaignType CampaignType { get; set; }
        public DateTime EndDate { get; set; }
        public int FreeSpinCount { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> PlayerIds { get; set; }
        public DateTime StartDate { get; set; }
        public bool AddNewlyRegisteredPlayers { get; set; }
    }
}
