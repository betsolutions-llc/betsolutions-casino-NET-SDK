using System;
using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Okey.DTO.Achievement
{
    internal class Achievement
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int AchievementTypeId { get; set; }
        public int Count { get; set; }
        public int MinRank { get; set; }
        public double Prize { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<AchievementTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
    }
}
