using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Seka.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Achievement
{
    public class SekaAchievementsFilter
    {
        public SekaAchievementType? AchievementType { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
