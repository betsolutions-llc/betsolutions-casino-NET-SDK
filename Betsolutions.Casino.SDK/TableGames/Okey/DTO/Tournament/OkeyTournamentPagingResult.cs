using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Tournament
{
    public class OkeyTournamentPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<OkeyTournament> Tournaments { get; set; }
    }
}
