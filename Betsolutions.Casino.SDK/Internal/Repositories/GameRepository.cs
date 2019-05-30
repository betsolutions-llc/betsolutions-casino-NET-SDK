using System;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.DTO;
using Betsolutions.Casino.SDK.Internal.DTO.Game;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.Repositories
{
    internal class GameRepository : BaseRepository
    {
        internal GameRepository(MerchantAuthInfo authInfo) : base(authInfo, "Game")
        {
        }

        public GetGamesResponseContainer GetGames()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "GetGameList",
                Method = Method.POST
            };

            var rawHash = $"{AuthInfo.MerchantId}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);

            request.AddJsonBody(new { AuthInfo.MerchantId, Hash = hash });

            var response = client.Execute<GetGamesResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response.StatusCode, response.Content);
            }

            return response.Data;
        }
    }
}
