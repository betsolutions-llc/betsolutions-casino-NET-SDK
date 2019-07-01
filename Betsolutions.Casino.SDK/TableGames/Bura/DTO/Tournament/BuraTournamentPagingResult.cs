using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Tournament
{
    public class BuraTournamentPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<BuraTournament> Tournaments { get; set; }
    }
}
