namespace Betsolutions.Casino.SDK.Internal.Wallet.DTO
{
    internal class WithdrawRequest
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public int MerchantId { get; set; }
        public string Hash { get; set; }
        public string TransactionId { get; set; }
        public string Currency { get; set; }
    }
}
