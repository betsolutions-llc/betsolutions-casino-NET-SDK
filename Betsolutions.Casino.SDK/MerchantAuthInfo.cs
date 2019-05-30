namespace Betsolutions.Casino.SDK
{
    public class MerchantAuthInfo
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId">Merchant Id</param>
        /// <param name="privateKey">Merchant's private key</param>
        /// <param name="baseUrl">API base url with format: "https://example.com/"</param>
        public MerchantAuthInfo(int merchantId, string privateKey, string baseUrl)
        {
            MerchantId = merchantId;
            PrivateKey = privateKey;
            BaseUrl = baseUrl;
        }

        public int MerchantId { get; }
        public string PrivateKey { get; }
        public string BaseUrl { get; }
    }
}
