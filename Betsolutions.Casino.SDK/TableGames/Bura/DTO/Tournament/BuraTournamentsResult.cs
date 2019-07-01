namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Tournament
{
    public class GetBuraTournamentsResult
    {
        public BuraTournamentPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
