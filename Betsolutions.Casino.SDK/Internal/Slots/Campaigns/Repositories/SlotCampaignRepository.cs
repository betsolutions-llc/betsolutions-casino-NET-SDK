using System;
using System.Linq;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO;
using Newtonsoft.Json;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.Slots.Campaigns.Repositories
{
    internal class SlotCampaignRepository : BaseRepository
    {
        internal SlotCampaignRepository(MerchantAuthInfo authInfo) : base(authInfo, "SlotCampaign")
        {

        }

        public CreateSlotCampaignResponseContainer CreateSlotCampaign(SDK.Slots.Campaigns.DTO.CreateSlotCampaignRequest campaign)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "CreateSlotCampaign",
                Method = Method.POST
            };

            var model = new CreateSlotCampaign
            {
                BetAmountsPerCurrency = campaign.BetAmountsPerCurrency.Select(i => new SlotCampaignBetAmountCurrency
                {
                    CoinCount = i.CoinCount,
                    CoinValueId = i.CoinValueId,
                    Currency = i.Currency
                }),
                CampaignTypeId = (int)campaign.CampaignType,
                EndDate = campaign.EndDate.ToString(ConfigService.GetDateTimeFormat()),
                FreespinCount = campaign.FreeSpinCount,
                GameId = campaign.GameId,
                Name = campaign.Name,
                PlayerIds = campaign.PlayerIds.Select(i => i),
                StartDate = campaign.StartDate.ToString(ConfigService.GetDateTimeFormat()),
                AddNewlyRegisteredPlayers = campaign.AddNewlyRegisteredPlayers,
                MerchantId = AuthInfo.MerchantId
            };

            var rawHash = $"{model.CampaignTypeId}|{model.EndDate}|{model.StartDate}";
            rawHash += $"|{model.FreespinCount}|{model.GameId}|{AuthInfo.MerchantId}|{model.Name}";
            rawHash += $"|{JsonConvert.SerializeObject(model.BetAmountsPerCurrency)}|{JsonConvert.SerializeObject(model.PlayerIds)}";
            rawHash += $"|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            model.Hash = hash;

            request.AddJsonBody(model);
            var response = client.Execute<CreateSlotCampaignResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }

        public DeactivateSlotCampaignResponseContainer DeactivateSlotCampaign(SDK.Slots.Campaigns.DTO.DeactivateSlotCampaignRequest model){

            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "DeactivateSlotCampaign",
                Method = Method.POST
            };

            var requestBody = new DeactivateSlotCampaign
            {
                MerchantId = AuthInfo.MerchantId,
                Id = model.Id
            };

            var rawHash = $"{requestBody.MerchantId}|{requestBody.Id}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            requestBody.Hash = hash;

            request.AddJsonBody(requestBody);
            var response = client.Execute<DeactivateSlotCampaignResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }

        public GetSlotConfigsResponseContainer GetSlotConfigs()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "GetMerchantSlotConfigs",
                Method = Method.POST
            };

            var rawHash = $"{AuthInfo.MerchantId}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);

            request.AddJsonBody(new {AuthInfo.MerchantId, Hash = hash});
            var response = client.Execute<GetSlotConfigsResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }

        public GetSlotCampaignsResponseContainer GetSlotCampaigns(GetSlotCampaignsRequestModel model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "GetSlotCampaigns",
                Method = Method.POST
            };

            model.MerchantId = AuthInfo.MerchantId;

            var dateTimeFormat = ConfigService.GetDateTimeFormat();

            var rawHash = $"{model.MerchantId}|{model.CampaignId}|{model.EndDateFrom?.ToString(dateTimeFormat)}|{model.EndDateTo?.ToString(dateTimeFormat)}|{model.StartDateFrom?.ToString(dateTimeFormat)}|{model.StartDateTo?.ToString(dateTimeFormat)}|{model.StatusId}";
            rawHash += $"|{model.GameId}|{model.Name}|{model.OrderingDirection}|{model.OrderingField}|{model.PageIndex}|{model.PageSize}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            model.Hash = hash;

            request.AddJsonBody(model);
            var response = client.Execute<GetSlotCampaignsResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }
            
            return response.Data;
        }

        public AddPlayersToCampaignResponseContainer AddPlayersToCampaign(AddPlayerToCampaignRequestModel model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "AddPlayersToSlotCampaign",
                Method = Method.POST
            };

            model.MerchantId = AuthInfo.MerchantId;

            var rawHash = $"{model.CampaignId}";
            rawHash += $"|{model.MerchantId}";
            rawHash += $"|{JsonConvert.SerializeObject(model.PlayerIds)}";
            rawHash += $"|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            model.Hash = hash;

            request.AddJsonBody(model);
            var response = client.Execute<AddPlayersToCampaignResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }
    }
}
