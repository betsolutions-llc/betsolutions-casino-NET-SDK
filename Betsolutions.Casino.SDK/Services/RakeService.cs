using System.Linq;
using Betsolutions.Casino.SDK.DTO.Rake;
using Betsolutions.Casino.SDK.Internal.Repositories;

namespace Betsolutions.Casino.SDK.Services
{
    public sealed class RakeService
    {
        private readonly RakeRepository _rakeRepository;
        private readonly MerchantAuthInfo _merchantAuthInfo;
        public RakeService(MerchantAuthInfo merchantAuthInfo)
        {
            _merchantAuthInfo = merchantAuthInfo;
            _rakeRepository = new RakeRepository(merchantAuthInfo);
        }

        public GetRakeResponseContainer GetRake(GetRakeRequest request)
        {
            var result = _rakeRepository.GetRake(new Internal.DTO.Rake.GetRakeRequest
            {
                FromDate = request.FromDate?.ToString("MM-dd-yyyy HH:mm:ss"),
                GameId = request.GameId,
                MerchantId = _merchantAuthInfo.MerchantId,
                ToDate = request.ToDate?.ToString("MM-dd-yyyy HH:mm:ss"),
                UserId = request.UserId
            });

            if (200 != result.StatusCode)
            {
                return new GetRakeResponseContainer { StatusCode = result.StatusCode };
            }

            return new GetRakeResponseContainer
            {
                StatusCode = result.StatusCode,
                Data = new GetRakeResponse
                {
                    RakeData = result.Data.RakeData.Select(i => new RakeItem
                    {
                        Amount = i.Amount,
                        Date = i.Date,
                        MerchantPlayerId = i.MerchantPlayerId,
                        PlayerId = i.PlayerId
                    })
                }
            };
        }
    }
}
