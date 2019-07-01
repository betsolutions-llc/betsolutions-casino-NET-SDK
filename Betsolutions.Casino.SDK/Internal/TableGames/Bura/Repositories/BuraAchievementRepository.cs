using System;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.TableGames.Bura.DTO.Achievement;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Bura.Repositories
{
    internal class BuraAchievementRepository : BaseRepository
    {
        internal BuraAchievementRepository(MerchantAuthInfo authInfo) : base(authInfo, "BuraAchievement")
        {

        }

        public GetAchievementsResponseContainer GetAchievements(AchievementsFilter searchModel)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "GetAchievements",
                Method = Method.POST
            };

            searchModel.MerchantId = AuthInfo.MerchantId;

            var rawHash = $"{searchModel.MerchantId}|{searchModel.AchievementTypeId}";
            rawHash += $"|{searchModel.OrderingDirection}|{searchModel.OrderingField}|{searchModel.PageIndex}|{searchModel.PageSize}";
            rawHash += $"|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            searchModel.Hash = hash;

            request.AddJsonBody(searchModel);
            var response = client.Execute<GetAchievementsResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }
    }
}
