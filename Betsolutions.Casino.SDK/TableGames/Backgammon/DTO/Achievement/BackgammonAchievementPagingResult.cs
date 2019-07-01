using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Achievement
{
    public class BackgammonAchievementPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<BackgammonAchievement> Achievements { get; set; }
    }
}
