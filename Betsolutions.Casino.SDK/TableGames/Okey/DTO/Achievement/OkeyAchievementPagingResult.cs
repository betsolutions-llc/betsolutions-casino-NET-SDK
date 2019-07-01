using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Achievement
{
    public class OkeyAchievementPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<OkeyAchievement> Achievements { get; set; }
    }
}
