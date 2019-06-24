﻿using System;
using System.Linq;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.Slots.Campaigns.DTO;
using Newtonsoft.Json;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.Slots.Repositories
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
                CampaignTypeId = campaign.CampaignTypeId,
                EndDate = campaign.EndDate.ToString("MM-dd-yyyy HH:mm:ss"),
                FreespinCount = campaign.FreespinCount,
                GameId = campaign.GameId,
                Name = campaign.Name,
                PlayerIds = campaign.PlayerIds.Select(i => i),
                StartDate = campaign.StartDate.ToString("MM-dd-yyyy HH:mm:ss"),
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
    }
}
