using System.Collections.Generic;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Tournament
{
    internal class GetTournamentTypesResult
    {
        public IEnumerable<TournamentType> Data { get; set; }
        public StatusCodes StatusCode { get; set; }
    }
}
