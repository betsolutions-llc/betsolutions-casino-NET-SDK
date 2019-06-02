namespace Betsolutions.Casino.SDK.Internal.DTO.Rake
{
    internal class GetRakeDetailedRequest
    {
        public string UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int? GameId { get; set; }
        public int MerchantId { get; set; }
        public string Hash { get; set; }
    }
}
