namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Tournament
{
    public class GetBackgammonTournamentsResult
    {
        public BackgammonTournamentPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
