using System.Linq;
using Betsolutions.Casino.SDK.Internal.TableGames.Backgammon.Repositories;
using Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Tournament;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.Services
{
    internal class BackgammonTournamentService
    {
        private readonly BackgammonTournamentRepository _backgammonTournamentRepository;

        public BackgammonTournamentService(MerchantAuthInfo merchantAuthInfo)
        {
            _backgammonTournamentRepository = new BackgammonTournamentRepository(merchantAuthInfo);
        }

        public GetTournamentsResult GetTournaments(TournamentsFilter filter)
        {
            var result = _backgammonTournamentRepository.GetTournaments(
                 new Internal.TableGames.Backgammon.DTO.Tournament.TournamentsFilter()
                 {
                     EndDateFrom = filter.EndDateFrom,
                     EndDateTo = filter.EndDateTo,
                     GameTypeId = filter.GameTypeId,
                     MerchantId = filter.MerchantId,
                     OrderingDirection = filter.OrderingDirection,
                     OrderingField = filter.OrderingField,
                     PageIndex = filter.PageIndex,
                     PageSize = filter.PageSize,
                     StartDateFrom = filter.StartDateFrom,
                     StartDateTo = filter.StartDateTo,
                     TournamentTypeId = filter.TournamentTypeId
                 });

            if (0 == result.StatusCode)
            {
                return new GetTournamentsResult { StatusCode = StatusCodes.GeneralError };
            }

            if (200 != result.StatusCode)
            {
                return new GetTournamentsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetTournamentsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new TournamentPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Tournaments = result.Data.Tournaments.Select(i => new Tournament
                    {
                        TournamentTypeId = i.TournamentTypeId,
                        BetAmount = i.BetAmount,
                        CreateDate = i.CreateDate,
                        EndDate = i.EndDate,
                        FilteredCount = i.FilteredCount,
                        FinalPoint = i.FinalPoint,
                        GameTypeId = i.GameTypeId,
                        Id = i.Id,
                        IsHidden = i.IsHidden,
                        IsNetwork = i.IsNetwork,
                        MaxPlayerCount = i.MaxPlayerCount,
                        MinPlayerCount = i.MinPlayerCount,
                        Prize = i.Prize,
                        Prizes = i.Prizes.Select(p => new TournamentPrize
                        {
                            Id = p.Id,
                            Percent = p.Percent
                        }),
                        RegisteredPlayerCount = i.RegisteredPlayerCount,
                        StartDate = i.StartDate,
                        StatusId = i.StatusId,
                        Translations = i.Translations.Select(t => new TournamentTranslation
                        {
                            Lang = t.Lang,
                            Name = t.Name
                        })
                    })
                }
            };
        }

        public GetTournamentTypesResult GetTournamentTypes()
        {
            var result = _backgammonTournamentRepository.GetTournamentTypes();

            if (0 == result.StatusCode)
            {
                return new GetTournamentTypesResult { StatusCode = StatusCodes.GeneralError };
            }

            if (200 != result.StatusCode)
            {
                return new GetTournamentTypesResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetTournamentTypesResult
            {
                StatusCode = (StatusCodes) result.StatusCode,
                Data = result.Data.Select(i => new TournamentType
                {
                    Id = i.Id,
                    Name = i.Name
                })
            };
        }
    }
}
