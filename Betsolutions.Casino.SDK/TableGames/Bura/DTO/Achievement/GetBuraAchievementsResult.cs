namespace Betsolutions.Casino.SDK.TableGames.Bura.DTO.Achievement
{
    public class GetBuraAchievementsResult
    {
        public BuraAchievementPagingResult Data { get; set; }
        public StatusCodes StatusCode { get; set; }
        public string Message { get; set; }
    }
}
