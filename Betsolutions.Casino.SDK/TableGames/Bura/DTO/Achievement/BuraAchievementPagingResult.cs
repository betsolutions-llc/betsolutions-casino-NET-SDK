using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Achievement
{
    public class BuraAchievementPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<BuraAchievement> Achievements { get; set; }
    }
}
