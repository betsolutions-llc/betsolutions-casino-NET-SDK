using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Backgammon.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Achievement
{
    public class BackgammonAchievement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public BackgammonAchievementType AchievementType { get; set; }
        public int Count { get; set; }
        public int MinRank { get; set; }
        public int? Dice1 { get; set; }
        public int? Dice2 { get; set; }
        public double Prize { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BackgammonAchievementTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
    }
}
