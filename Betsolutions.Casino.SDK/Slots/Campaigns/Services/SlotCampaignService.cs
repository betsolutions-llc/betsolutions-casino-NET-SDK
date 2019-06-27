using System;
using System.Linq;
using Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO;
using Betsolutions.Casino.SDK.Internal.Slots.Campaigns.Repositories;
using Betsolutions.Casino.SDK.Services;
using Betsolutions.Casino.SDK.Slots.Campaigns.DTO;
using Betsolutions.Casino.SDK.Slots.Campaigns.Enums;
using AddPlayersToCampaignResponseContainer = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.AddPlayersToCampaignResponseContainer;
using CreateSlotCampaignResponse = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.CreateSlotCampaignResponse;
using CreateSlotCampaignResponseContainer = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.CreateSlotCampaignResponseContainer;
using DeactivateSlotCampaignResponseContainer = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.DeactivateSlotCampaignResponseContainer;
using GetSlotCampaignsResponse = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.GetSlotCampaignsResponse;
using GetSlotCampaignsResponseContainer = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.GetSlotCampaignsResponseContainer;
using GetSlotConfigsResponse = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.GetSlotConfigsResponse;
using GetSlotConfigsResponseContainer = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.GetSlotConfigsResponseContainer;
using SlotCampaignsPagingResult = Betsolutions.Casino.SDK.Slots.Campaigns.DTO.SlotCampaignsPagingResult;

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
                    StatusCode = StatusCodes.InvalidRequest,
                    StatusMessage = "min name length: 10"
                };
            }

            if (request.StartDate < DateTime.Now)
            {
                return new CreateSlotCampaignResponseContainer
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    StatusMessage = "start date must be more than current date"
                };
            }

            var result = _slotCampaignRepository.CreateSlotCampaign(request);

            if (200 != result.StatusCode)
            {
                return new CreateSlotCampaignResponseContainer
                {
                    StatusCode = (StatusCodes)result.StatusCode
                };
            }

            return new CreateSlotCampaignResponseContainer
            {
                StatusCode = (StatusCodes)result.StatusCode,
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
                StatusCode = (StatusCodes)result.StatusCode
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
                StatusCode = (StatusCodes)result.StatusCode,
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

        public GetSlotCampaignsResponseContainer GetSlotCampaigns(SlotCampaignsSearchModel searchModel)
        {
            var result = _slotCampaignRepository.GetSlotCampaigns(new GetSlotCampaignsRequestModel
            {
                CampaignId = searchModel.CampaignId,
                EndDateFrom = searchModel.EndDateFrom,
                EndDateTo = searchModel.EndDateTo,
                GameId = searchModel.GameId,
                Name = searchModel.Name,
                OrderingDirection = searchModel.OrderingDirection,
                OrderingField = searchModel.OrderingField,
                PageIndex = searchModel.PageIndex,
                PageSize = searchModel.PageSize,
                StartDateFrom = searchModel.StartDateFrom,
                StartDateTo = searchModel.StartDateTo,
                StatusId = (int?)searchModel.Status
            });

            if (result.StatusCode != 200)
            {
                return new GetSlotCampaignsResponseContainer { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetSlotCampaignsResponseContainer
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new GetSlotCampaignsResponse
                {
                    SlotCampaignsPagingResult = new SlotCampaignsPagingResult
                    {
                        TotalCount = result.Data.SlotCampaignsPagingResult.TotalCount,
                        Campaigns = result.Data.SlotCampaignsPagingResult.Campaigns.Select(i => new SlotCampaign
                        {
                            CampaignType = (CampaignType)i.CampaignTypeId,
                            EndDate = i.EndDate,
                            FilteredCount = i.FilteredCount,
                            FreeSpinCount = i.FreespinCount,
                            GameId = i.GameId,
                            Id = i.Id,
                            Name = i.Name,
                            PlayerCount = i.PlayerCount,
                            StartDate = i.StartDate,
                            Status = (CampaignStatus)i.StatusId
                        }).ToList()
                    }
                }
            };
        }

        public AddPlayersToCampaignResponseContainer AddPlayersToCampaign(AddPlayersToCampaignRequest request)
        {
            if (request.CampaignId < 1)
            {
                return new AddPlayersToCampaignResponseContainer
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    StatusMessage = $"Invalid ${nameof(request.CampaignId)}"
                };
            }

            if (null == request.PlayerIds || request.PlayerIds.Count < 1)
            {
                return new AddPlayersToCampaignResponseContainer
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    StatusMessage = $"{nameof(request.PlayerIds)} is empty"
                };
            }

            var result = _slotCampaignRepository.AddPlayersToCampaign(new AddPlayerToCampaignRequestModel
            {
                CampaignId = request.CampaignId,
                PlayerIds = request.PlayerIds.Select(i => i).ToList()
            });

            return new AddPlayersToCampaignResponseContainer { StatusCode = (StatusCodes)result.StatusCode };
        }
    }
}
