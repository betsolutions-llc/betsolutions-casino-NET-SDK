using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Tournament
{
    public class SekaTournamentPagingResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<SekaTournament> Tournaments { get; set; }
    }
}
