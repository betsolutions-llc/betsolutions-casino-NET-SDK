using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO
{
    internal class CreateSlotCampaign
    {
        public IEnumerable<SlotCampaignBetAmountCurrency> BetAmountsPerCurrency { get; set; }
        public int CampaignTypeId { get; set; }
        public string EndDate { get; set; }
        public int FreespinCount { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> PlayerIds { get; set; }
        public string StartDate { get; set; }
        public bool AddNewlyRegisteredPlayers { get; set; }
        public string Hash { get; set; }
        public int MerchantId { get; set; }
    }
}
