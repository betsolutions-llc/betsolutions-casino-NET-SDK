using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Betsolutions.Casino.SDK.Internal.Services;

namespace Betsolutions.Casino.SDK.Internal
{
    internal class BaseRepository
    {
        protected readonly MerchantAuthInfo AuthInfo;
        protected string Controller;
        internal ConfigService _configService = new ConfigService();

        internal BaseRepository(MerchantAuthInfo authInfo, string controller)
        {
            AuthInfo = authInfo;
            Controller = $"v1/{controller}/";
        }

        protected static string GetSha256(string text)
        {
            var utf8Encoding = new UTF8Encoding();
            var message = utf8Encoding.GetBytes(text);

            var hashString = new SHA256Managed();
            var hex = string.Empty;

            var hashValue = hashString.ComputeHash(message);

            return hashValue.Aggregate(hex, (current, bt) => current + $"{bt:x2}");
        }
    }
}
