using System;
using System.Net;
using Betsolutions.Casino.SDK.Internal.TableGames.Backgammon.DTO.Tournament;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.TableGames.Backgammon.Repositories
{
    internal class BackgammonTournamentRepository : BaseRepository
    {
        internal BackgammonTournamentRepository(MerchantAuthInfo authInfo) : base(authInfo, "BackgammonTournament")
        {

        }

        internal GetTournamentsResponseContainer GetTournaments(TournamentsFilter searchModel)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(AuthInfo.BaseUrl)
            };

            var request = new RestRequest
            {
                Resource = "GetTournaments",
                Method = Method.POST
            };

            var rawHash = $"{searchModel.MerchantId}|{searchModel.EndDateTo?.ToString("MM-dd-yyyy HH:mm:ss")}|{searchModel.EndDateFrom?.ToString("MM-dd-yyyy HH:mm:ss")}";
            rawHash += $"|{searchModel.GameTypeId}|{searchModel.OrderingDirection}|{searchModel.OrderingField}|{searchModel.PageIndex}|{searchModel.PageSize}";
            rawHash += $"|{searchModel.StartDateFrom?.ToString("MM-dd-yyyy HH:mm:ss")}|{searchModel.StartDateTo?.ToString("MM-dd-yyyy HH:mm:ss")}";
            rawHash += $"|{searchModel.TournamentTypeId}";
            rawHash += $"|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            searchModel.Hash = hash;

            Console.WriteLine(rawHash);

            request.AddJsonBody(searchModel);
            var response = client.Execute<GetTournamentsResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                return new GetTournamentsResponseContainer { StatusCode = 0 };
            }

            return response.Data;
        }

        internal GetTournamentTypesResponseContainer GetTournamentTypes()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(AuthInfo.BaseUrl)
            };

            var request = new RestRequest
            {
                Resource = "GetTournamentTypes",
                Method = Method.POST
            };

            var response = client.Execute<GetTournamentTypesResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                return new GetTournamentTypesResponseContainer { StatusCode = 0 };
            }

            return response.Data;
        }
    }
}
