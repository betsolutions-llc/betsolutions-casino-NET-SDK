using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Domino.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Tournament
{
    public class DominoTournament
    {
        public int Id { get; set; }
        public decimal BetAmount { get; set; }
        public decimal Prize { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int RegisteredPlayerCount { get; set; }
        public DominoTournamentType TournamentType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DominoTournamentStatus Status { get; set; }
        public DominoGameType GameType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }
        public IEnumerable<DominoTournamentTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
        public int FinalPoint { get; set; }
        public IEnumerable<DominoTournamentPrize> Prizes { get; set; }
    }
}
