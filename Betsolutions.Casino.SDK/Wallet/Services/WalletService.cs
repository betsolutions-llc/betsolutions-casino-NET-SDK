using Betsolutions.Casino.SDK.Internal.Wallet.Repositories;
using Betsolutions.Casino.SDK.Wallet.DTO;

namespace Betsolutions.Casino.SDK.Wallet.Services
{
    public sealed class WalletService
    {
        private readonly WalletRepository _walletRepository;
        private readonly MerchantAuthInfo _merchantAuthInfo;

        public WalletService(MerchantAuthInfo merchantAuthInfo)
        {
            _walletRepository = new WalletRepository(merchantAuthInfo);
            _merchantAuthInfo = merchantAuthInfo ;
        }

        public DepositResponseContainer Deposit(DepositRequest request)
        {
            var result = _walletRepository.Deposit(new Internal.Wallet.DTO.DepositRequest
            {
                Amount = request.Amount,
                Currency = request.Currency,
                MerchantId = _merchantAuthInfo.MerchantId,
                Token = request.Token,
                TransactionId = request.TransactionId,
                UserId = request.UserId
            });

            if (200 != result.StatusCode)
            {
                return new DepositResponseContainer { StatusCode = result.StatusCode };
            }

            return new DepositResponseContainer
            {
                StatusCode = result.StatusCode,
                Data = new DepositResponse
                {
                    TransactionId = result.Data.TransactionId,
                    Balance = result.Data.Balance
                }
            };
        }

        public WithdrawResponseContainer Withdraw(WithdrawRequest request)
        {
            var result = _walletRepository.Withdraw(new Internal.Wallet.DTO.WithdrawRequest()
            {
                TransactionId = request.TransactionId,
                UserId = request.UserId,
                Token = request.Token,
                MerchantId = _merchantAuthInfo.MerchantId,
                Currency = request.Currency,
                Amount = request.Amount
            });

            if (200 != result.StatusCode)
            {
                return new WithdrawResponseContainer { StatusCode = result.StatusCode };
            }

            return new WithdrawResponseContainer
            {
                StatusCode = result.StatusCode,
                Data = new WithdrawResponse
                {
                    TransactionId = result.Data.TransactionId,
                    Balance = result.Data.Balance
                }
            };
        }

        public GetBalanceResponseContainer GetBalance(GetBalanceRequest request)
        {
            var result = _walletRepository.GetBalance(new Internal.Wallet.DTO.GetBalanceRequest()
            {
                Currency = request.Currency,
                MerchantId = _merchantAuthInfo.MerchantId,
                Token = request.Token,
                UserId = request.UserId,
            });

            if (200 != result.StatusCode)
            {
                return new GetBalanceResponseContainer { StatusCode = result.StatusCode };
            }

            return new GetBalanceResponseContainer
            {
                StatusCode = result.StatusCode,
                Data = new GetBalanceResponse
                {
                    Balance = result.Data.Balance
                }
            };
        }
    }
}
