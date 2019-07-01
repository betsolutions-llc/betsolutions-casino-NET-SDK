using System;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Bura.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Tournament
{
    public class BuraTournamentsFilter
    {
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public BuraGameType? GameType { get; set; }
        public BuraTournamentType? TournamentType { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
