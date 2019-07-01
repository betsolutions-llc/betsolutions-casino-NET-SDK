using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Okey.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Achievement
{
    public class OkeyAchievementsFilter
    {
        public OkeyAchievementType? AchievementType { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
