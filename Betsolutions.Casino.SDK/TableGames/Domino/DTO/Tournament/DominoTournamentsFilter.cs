using System;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Domino.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Tournament
{
    public class DominoTournamentsFilter
    {
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public DominoGameType? GameType { get; set; }
        public DominoTournamentType? TournamentType { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
