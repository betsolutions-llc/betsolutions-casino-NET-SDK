using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Domino.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Achievement
{
    public class DominoAchievementsFilter
    {
        public DominoAchievementType? AchievementType { get; set; }
        public int? PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
