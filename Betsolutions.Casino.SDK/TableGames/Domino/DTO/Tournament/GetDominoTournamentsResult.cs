namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Tournament
{
    public class GetDominoTournamentsResult
    {
        public DominoTournamentPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
