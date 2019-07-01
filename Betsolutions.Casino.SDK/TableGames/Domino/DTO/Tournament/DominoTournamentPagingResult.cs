using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Tournament
{
    public class DominoTournamentPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<DominoTournament> Tournaments { get; set; }
    }
}
