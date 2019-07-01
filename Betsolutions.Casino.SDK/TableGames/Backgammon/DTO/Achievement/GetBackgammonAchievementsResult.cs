namespace Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Achievement
{
    public class GetBackgammonAchievementsResult
    {
        public BackgammonAchievementPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
