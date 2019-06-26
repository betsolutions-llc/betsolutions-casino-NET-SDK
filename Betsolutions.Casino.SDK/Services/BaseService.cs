using Betsolutions.Casino.SDK.Internal.Services;

namespace Betsolutions.Casino.SDK.Services
{
    public abstract class BaseService
    {
        internal readonly ConfigService ConfigService = new ConfigService();
    }
}
