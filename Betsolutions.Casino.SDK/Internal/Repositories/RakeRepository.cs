using System;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.DTO.Rake;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.Repositories
{
    internal class RakeRepository : BaseRepository
    {
        internal RakeRepository(MerchantAuthInfo authInfo) : base(authInfo, "Rake")
        {
        }

        public GetRakeResponseContainer GetRake(GetRakeRequest model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "GetRake",
                Method = Method.POST
            };

            var rawHash = $"{model.MerchantId}|{model.UserId}|{model.FromDate}|{model.ToDate}|{model.GameId}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);

            model.Hash = hash;

            request.AddJsonBody(model);

            var response = client.Execute<GetRakeResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response.StatusCode, response.Content);
            }

            return response.Data;
        }
    }
}
