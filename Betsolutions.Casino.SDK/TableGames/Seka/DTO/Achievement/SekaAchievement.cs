using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Seka.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Achievement
{
    public class SekaAchievement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public SekaAchievementType AchievementType { get; set; }
        public int Count { get; set; }
        public int MinRank { get; set; }
        public double Prize { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<SekaAchievementTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
    }
}
