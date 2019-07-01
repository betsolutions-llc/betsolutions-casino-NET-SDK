namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Tournament
{
    public class GetSekaTournamentsResult
    {
        public SekaTournamentPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
