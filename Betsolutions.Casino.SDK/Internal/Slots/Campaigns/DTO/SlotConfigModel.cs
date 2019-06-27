namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO
{
    internal class SlotConfigModel
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public int CoinValue { get; set; }
        public string Currency { get; set; }
        public int Lines { get; set; }
        public int LineMultiplier { get; set; }
    }
}