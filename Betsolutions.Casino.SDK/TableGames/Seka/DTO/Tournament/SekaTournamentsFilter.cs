using System;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Seka.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Tournament
{
    public class SekaTournamentsFilter
    {
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public SekaGameType? GameType { get; set; }
        public SekaTournamentType? TournamentType { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
