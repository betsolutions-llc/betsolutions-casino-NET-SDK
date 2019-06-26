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
    }
}
