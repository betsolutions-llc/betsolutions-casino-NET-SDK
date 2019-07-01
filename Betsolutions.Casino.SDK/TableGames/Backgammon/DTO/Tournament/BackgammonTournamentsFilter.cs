using System;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Tournament
{
    public class BackgammonTournamentsFilter
    {
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public int? GameTypeId { get; set; }
        public int? TournamentTypeId { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public string OrderingDirection { get; set; }
    }
}
