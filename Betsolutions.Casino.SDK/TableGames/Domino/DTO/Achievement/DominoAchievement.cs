using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Domino.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Achievement
{
    public class DominoAchievement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DominoAchievementType AchievementType { get; set; }
        public int Count { get; set; }
        public int MinRank { get; set; }
        public double Prize { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<DominoAchievementTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
    }
}
