using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Okey.DTO.Achievement
{
    internal class AchievementPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<Achievement> Achievements { get; set; }
    }
}
