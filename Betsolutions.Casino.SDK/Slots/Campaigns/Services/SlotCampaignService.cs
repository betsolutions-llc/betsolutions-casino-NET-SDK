using System;
using System.Linq;
using Betsolutions.Casino.SDK.Internal.Slots.Campaigns.Repositories;
using Betsolutions.Casino.SDK.Services;
using Betsolutions.Casino.SDK.Slots.Campaigns.DTO;

namespace Betsolutions.Casino.SDK.Slots.Campaigns.Services
{
    public class SlotCampaignService : BaseService
    {
        private readonly SlotCampaignRepository _slotCampaignRepository;

        public SlotCampaignService(MerchantAuthInfo authInfo)
        {
            _slotCampaignRepository = new SlotCampaignRepository(authInfo);
        }

        public CreateSlotCampaignResponseContainer CreateCampaign(CreateSlotCampaignRequest request)
        {
            if (request.Name.Length < 10)
            {
                return new CreateSlotCampaignResponseContainer
                {
                    StatusCode = 411,
                    StatusMessage = "min name length: 10"
                };
            }

            if (request.StartDate < DateTime.Now)
            {
                return new CreateSlotCampaignResponseContainer
                {
                    StatusCode = 411,
                    StatusMessage = "start date must be more than current date"
                };
            }

            var result = _slotCampaignRepository.CreateSlotCampaign(request);

            if (200 != result.StatusCode)
            {
                return new CreateSlotCampaignResponseContainer
                {
                    StatusCode = result.StatusCode
                };
            }

            return new CreateSlotCampaignResponseContainer
            {
                StatusCode = result.StatusCode,
                Data = new CreateSlotCampaignResponse
                {
                    CampaignId = result.Data.CampaignId
                }
            };
        }

        public DeactivateSlotCampaignResponseContainer DeactivateSlotCampaign(DeactivateSlotCampaignRequest request)
        {
            var result = _slotCampaignRepository.DeactivateSlotCampaign(request);

            return new DeactivateSlotCampaignResponseContainer
            {
                StatusCode = result.StatusCode
            };
        }

        public GetSlotConfigsResponseContainer GetSlotConfigs()
        {
            var result = _slotCampaignRepository.GetSlotConfigs();

            if (result.StatusCode != 200)
            {
                return new GetSlotConfigsResponseContainer { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetSlotConfigsResponseContainer
            {
                StatusCode = (StatusCodes) result.StatusCode,
                Data = new GetSlotConfigsResponse
                {
                    Configs = result.Data.SlotConfigs.Select(i => new SlotConfig
                    {
                        CoinValue = i.CoinValue,
                        Currency = i.Currency,
                        Id = i.Id,
                        LineMultiplier = i.LineMultiplier,
                        Lines = i.Lines,
                        SlotId = i.SlotId
                    }).ToList()
                }
            };
        }
    }
}
