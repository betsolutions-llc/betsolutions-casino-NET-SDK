using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Bura.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Achievement
{
    public class BuraAchievementsFilter
    {
        public BuraAchievementType? AchievementType { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
