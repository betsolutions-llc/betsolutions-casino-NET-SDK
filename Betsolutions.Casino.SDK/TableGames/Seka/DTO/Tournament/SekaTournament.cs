using System;
using System.Collections.Generic;
using Betsolutions.Casino.SDK.TableGames.Seka.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Tournament
{
    public class SekaTournament
    {
        public int Id { get; set; }
        public decimal BetAmount { get; set; }
        public decimal Prize { get; set; }
        public int MaxPlayerCount { get; set; }
        public int MinPlayerCount { get; set; }
        public int RegisteredPlayerCount { get; set; }
        public SekaTournamentType TournamentType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public SekaTournamentStatus Status { get; set; }
        public SekaGameType GameType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }
        public IEnumerable<SekaTournamentTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
        public int FinalPoint { get; set; }
        public IEnumerable<SekaTournamentPrize> Prizes { get; set; }
        public bool WithRebuy { get; set; }
        public int RebuyMaxLevel { get; set; }
    }
}
