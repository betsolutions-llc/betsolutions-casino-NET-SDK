using System;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.TableGames.Okey.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Tournament
{
    public class OkeyTournamentsFilter
    {
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateTo { get; set; }
        public DateTime? EndDateFrom { get; set; }
        public DateTime? EndDateTo { get; set; }
        public OkeyGameType? GameType { get; set; }
        public OkeyTournamentType? TournamentType { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderingField { get; set; }
        public OrderingDirection? OrderingDirection { get; set; }
    }
}
