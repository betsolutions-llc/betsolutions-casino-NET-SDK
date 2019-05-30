namespace Betsolutions.Casino.SDK.Internal.Wallet.DTO
{
    internal class GetBalanceRequest
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string Hash { get; set; }
        public int MerchantId { get; set; }
        public string Currency { get; set; }
    }
}
