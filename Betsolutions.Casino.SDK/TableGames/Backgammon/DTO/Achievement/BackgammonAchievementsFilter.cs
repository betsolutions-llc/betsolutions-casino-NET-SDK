using Betsolutions.Casino.SDK.TableGames.Backgammon.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Achievement
{
    public class BackgammonAchievementsFilter
    {
        public BackgammonAchievementType? AchievementType { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public string OrderingDirection { get; set; }
    }
}
