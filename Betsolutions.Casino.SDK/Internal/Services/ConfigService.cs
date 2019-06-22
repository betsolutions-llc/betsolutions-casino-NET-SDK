using Betsolutions.Casino.SDK.Internal.Repositories;

namespace Betsolutions.Casino.SDK.Internal.Services
{
    internal class ConfigService
    {
        private readonly ConfigRepository _configRepository;

        internal ConfigService()
        {
            _configRepository = new ConfigRepository();
        }

        public string GetDateTimeFormat()
        {
            return _configRepository.GetDateTimeFormat();
        }
    }
}
