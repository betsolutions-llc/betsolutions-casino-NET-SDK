namespace Betsolutions.Casino.SDK.TableGames.Seka.DTO.Achievement
{
    public class GetSekaAchievementsResult
    {
        public SekaAchievementPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
