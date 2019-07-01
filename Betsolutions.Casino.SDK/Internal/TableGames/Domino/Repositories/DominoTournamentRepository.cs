using System;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.TableGames.Domino.DTO.Tournament;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Domino.Repositories
{
    internal class DominoTournamentRepository : BaseRepository
    {
        internal DominoTournamentRepository(MerchantAuthInfo authInfo) : base(authInfo, "DominoTournament")
        {

        }

        internal GetTournamentsResponseContainer GetTournaments(TournamentsFilter searchModel)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "GetTournaments",
                Method = Method.POST
            };

            var dateTimeFormat = ConfigService.GetDateTimeFormat();


            searchModel.MerchantId = AuthInfo.MerchantId;
            var rawHash = $"{searchModel.MerchantId}|{searchModel.EndDateTo?.ToString(dateTimeFormat)}|{searchModel.EndDateFrom?.ToString(dateTimeFormat)}";
            rawHash += $"|{searchModel.GameTypeId}|{searchModel.OrderingDirection}|{searchModel.OrderingField}|{searchModel.PageIndex}|{searchModel.PageSize}";
            rawHash += $"|{searchModel.StartDateFrom?.ToString(dateTimeFormat)}|{searchModel.StartDateTo?.ToString(dateTimeFormat)}";
            rawHash += $"|{searchModel.TournamentTypeId}";
            rawHash += $"|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            searchModel.Hash = hash;

            Console.WriteLine(rawHash);

            request.AddJsonBody(searchModel);
            var response = client.Execute<GetTournamentsResponseContainer>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }
    }
}
