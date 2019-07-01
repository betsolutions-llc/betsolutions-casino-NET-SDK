using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Tournament
{
    public class BackgammonTournamentPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<BackgammonTournament> Tournaments { get; set; }
    }
}
