using System;
using System.Net;
using Betsolutions.Casino.SDK.Exceptions;
using Betsolutions.Casino.SDK.Internal.Wallet.DTO;
using RestSharp;

namespace Betsolutions.Casino.SDK.Internal.Wallet.Repositories
{
    internal class WalletRepository : BaseRepository
    {
        internal WalletRepository(MerchantAuthInfo authInfo) : base(authInfo, "Wallet")
        {
        }

        internal DepositResponseContainer Deposit(DepositRequest model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri($"{AuthInfo.BaseUrl}/{Controller}")
            };

            var request = new RestRequest
            {
                Resource = "Deposit",
                Method = Method.POST
            };

            var rawHash = $"{model.Amount}|{model.Currency}|{model.MerchantId}|{model.TransactionId}|{model.Token}|{model.UserId}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            model.Hash = hash;

            request.AddJsonBody(model);

            var response = client.Execute<DepositResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }

        internal WithdrawResponseContainer Withdraw(WithdrawRequest model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(AuthInfo.BaseUrl)
            };

            var request = new RestRequest
            {
                Resource = "Withdraw",
                Method = Method.POST
            };

            var rawHash = $"{model.Amount}|{model.Currency}|{AuthInfo.MerchantId}|{model.TransactionId}|{model.Token}|{model.UserId}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            model.Hash = hash;

            request.AddJsonBody(model);

            var response = client.Execute<WithdrawResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }

        internal GetBalanceResponseContainer GetBalance(GetBalanceRequest model)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(AuthInfo.BaseUrl)
            };

            var request = new RestRequest
            {
                Resource = "GetBalance",
                Method = Method.POST
            };

            var rawHash = $"{model.Currency}|{model.MerchantId}|{model.Token}|{model.UserId}|{AuthInfo.PrivateKey}";
            var hash = GetSha256(rawHash);
            model.Hash = hash;

            request.AddJsonBody(model);

            var response = client.Execute<GetBalanceResponseContainer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed || response.StatusCode != HttpStatusCode.OK)
            {
                throw new CantConnectToServerException(response);
            }

            return response.Data;
        }
    }
}
