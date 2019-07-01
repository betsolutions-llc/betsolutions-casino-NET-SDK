namespace Betsolutions.Casino.SDK.Internal.TableGames.Backgammon.DTO.Achievement
{
    internal class AchievementsFilter
    {
        public int? AchievementTypeId { get; set; }
        public int MerchantId { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public string OrderingDirection { get; set; }
        public string Hash { get; set; }
    }
}
