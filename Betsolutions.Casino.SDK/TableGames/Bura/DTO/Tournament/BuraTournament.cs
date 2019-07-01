using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Bura.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Tournament
{
    public class BuraTournament
    {
        public int Id { get; set; }
        public decimal BetAmount { get; set; }
        public decimal Prize { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int RegisteredPlayerCount { get; set; }
        public BuraTournamentType TournamentType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public BuraTournamentStatus Status { get; set; }
        public BuraGameType GameType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }
        public IEnumerable<BuraTournamentTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
        public int FinalPoint { get; set; }
        public IEnumerable<BuraTournamentPrize> Prizes { get; set; }
        public bool HasRoyalRule { get; set; }
        public bool HasMolodkaRule { get; set; }
    }
}
