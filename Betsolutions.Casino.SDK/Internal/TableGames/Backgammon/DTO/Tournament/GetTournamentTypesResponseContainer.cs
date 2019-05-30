using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Backgammon.DTO.Tournament
{
    internal class GetTournamentTypesResponseContainer
    {
        public IEnumerable<TournamentType> Data { get; set; }
        public int StatusCode { get; set; }
    }
}
