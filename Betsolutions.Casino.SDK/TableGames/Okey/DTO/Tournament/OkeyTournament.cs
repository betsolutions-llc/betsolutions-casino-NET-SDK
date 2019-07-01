using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Okey.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Tournament
{
    public class OkeyTournament
    {
        public int Id { get; set; }
        public decimal BetAmount { get; set; }
        public decimal Prize { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int RegisteredPlayerCount { get; set; }
        public OkeyTournamentType TournamentType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OkeyTournamentStatus Status { get; set; }
        public OkeyGameType GameType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }
        public IEnumerable<OkeyTournamentTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
        public int FinalPoint { get; set; }
        public IEnumerable<OkeyTournamentPrize> Prizes { get; set; }
    }
}
