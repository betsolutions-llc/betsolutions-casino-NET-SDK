namespace Betsolutions.Casino.SDK.TableGames.Okey.DTO.Tournament
{
    public class GetOkeyTournamentsResult
    {
        public OkeyTournamentPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
