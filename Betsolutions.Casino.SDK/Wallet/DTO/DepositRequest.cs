namespace Betsolutions.Casino.SDK.Wallet.DTO
{
    public class DepositRequest
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
    }
}
