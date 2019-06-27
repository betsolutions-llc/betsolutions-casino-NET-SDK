using System.Linq;
using Betsolutions.Casino.SDK.DTO;
using Betsolutions.Casino.SDK.DTO.Game;
using Betsolutions.Casino.SDK.Internal.Repositories;

namespace Betsolutions.Casino.SDK.Services
{
    public sealed class GameService
    {
        private readonly GameRepository _gameRepository;

        public GameService(MerchantAuthInfo merchantAuthInfo)
        {
            _gameRepository = new GameRepository(merchantAuthInfo);
        }

        public GetGamesResponseContainer GetGames()
        {
            var result = _gameRepository.GetGames();

            if (200 != result.StatusCode)
            {
                return new GetGamesResponseContainer { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetGamesResponseContainer
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new GetGamesResponse
                {
                    Products = result.Data.Products.Select(p => new Product
                    {
                        ProductId = p.ProductId,
                        Games = p.Games.Select(g => new Game
                        {
                            GameId = g.GameId,
                            ProductId = g.ProductId,
                            HasFreeplay = g.HasFreeplay,
                            HasMobileDeviceSupport = g.HasMobileDeviceSupport,
                            LaunchUrl = g.LaunchUrl,
                            Name = g.Name,
                            RakePercent = g.RakePercent,
                            RTP = g.RTP,
                            Thumbnails = g.Thumbnails.Select(t => new GameThumbnail
                            {
                                Height = t.Height,
                                Url = t.Url,
                                Width = t.Width
                            })
                        })
                    })
                }
            };
        }
    }
}
