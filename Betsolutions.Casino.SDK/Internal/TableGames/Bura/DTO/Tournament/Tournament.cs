using System;
using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Bura.DTO.Tournament
{
    internal class Tournament
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
        public int StatusId { get; set; }
        public int GameTypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }
        public List<TournamentTranslation> Translations { get; set; }
        public int FilteredCount { get; set; }
        public bool IsNetwork { get; set; }
        public int FinalPoint { get; set; }
        public List<TournamentPrize> Prizes { get; set; }
        public bool HasRoyalRule { get; set; }
        public bool HasMolodkaRule { get; set; }
    }
}
