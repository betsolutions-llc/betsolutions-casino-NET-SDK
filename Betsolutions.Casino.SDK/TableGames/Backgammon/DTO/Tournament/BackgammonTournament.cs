using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Backgammon.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Tournament
{
    public class BackgammonTournament
    {
        public int Id { get; set; }
        public decimal BetAmount { get; set; }
        public decimal Prize { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int RegisteredPlayerCount { get; set; }
        public int TournamentTypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public BackgammonTournamentStatus Status { get; set; }
        public BackgammonGameType GameType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }
        public IEnumerable<BackgammonTournamentTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
        public int FinalPoint { get; set; }
        public IEnumerable<BackgammonTournamentPrize> Prizes { get; set; }
    }
}
