using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Achievement
{
    public class SekaAchievementPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<SekaAchievement> Achievements { get; set; }
    }
}
