namespace Betsolutions.Casino.SDK.TableGames.Domino.DTO.Achievement
{
    public class GetDominoAchievementsResult
    {
        public DominoAchievementPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
