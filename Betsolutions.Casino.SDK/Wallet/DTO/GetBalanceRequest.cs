namespace Betsolutions.Casino.SDK.Wallet.DTO
{
    public class GetBalanceRequest
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string Currency { get; set; }
    }
}
