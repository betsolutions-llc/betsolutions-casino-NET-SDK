namespace Betsolutions.Casino.SDK.Wallet.DTO
{
    public class WithdrawRequest
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public string TransactionId { get; set; }
        public string Currency { get; set; }
    }
}
