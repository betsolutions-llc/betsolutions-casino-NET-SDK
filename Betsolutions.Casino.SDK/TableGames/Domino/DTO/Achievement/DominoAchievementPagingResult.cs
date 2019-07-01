using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Achievement
{
    public class DominoAchievementPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<DominoAchievement> Achievements { get; set; }
    }
}
