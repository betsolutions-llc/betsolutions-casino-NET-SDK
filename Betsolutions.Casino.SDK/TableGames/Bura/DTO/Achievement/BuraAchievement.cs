using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Bura.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Achievement
{
    public class BuraAchievement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public BuraAchievementType AchievementType { get; set; }
        public int Count { get; set; }
        public int MinRank { get; set; }
        public double Prize { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<BuraAchievementTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
    }
}
