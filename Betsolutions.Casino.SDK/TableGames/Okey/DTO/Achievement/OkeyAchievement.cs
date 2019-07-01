using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Okey.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Achievement
{
    public class OkeyAchievement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public OkeyAchievementType AchievementType { get; set; }
        public int Count { get; set; }
        public int MinRank { get; set; }
        public double Prize { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<OkeyAchievementTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
    }
}
