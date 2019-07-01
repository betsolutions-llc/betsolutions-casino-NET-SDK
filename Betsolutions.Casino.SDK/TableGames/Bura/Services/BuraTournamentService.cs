using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Bura.Repositories;
using Betsolutions.Casino.SDK.TableGames.Bura.DTO.Tournament;
using Betsolutions.Casino.SDK.TableGames.Bura.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Bura.Services
{
    public class BuraTournamentService
    {
        private readonly BuraTournamentRepository _backgammonTournamentRepository;

        public BuraTournamentService(MerchantAuthInfo merchantAuthInfo)
        {
            _backgammonTournamentRepository = new BuraTournamentRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(BuraTournamentsFilter filter)
        {
            if (filter.PageIndex < 1)
            {
                return $"invalid {nameof(filter.PageIndex)}";
            }

            if (filter.PageSize < 1)
            {
                return $"invalid {nameof(filter.PageSize)}";
            }

            if (filter.OrderingDirection.HasValue
                && !Enum.IsDefined(typeof(OrderingDirection), filter.OrderingDirection.Value))
            {
                return $"invalid {nameof(filter.OrderingDirection)}";
            }

            return null;
        }

        public GetBuraTournamentsResult GetTournaments(BuraTournamentsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetBuraTournamentsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _backgammonTournamentRepository.GetTournaments(
                 new Internal.TableGames.Bura.DTO.Tournament.TournamentsFilter
                 {
                     EndDateFrom = filter.EndDateFrom,
                     EndDateTo = filter.EndDateTo,
                     GameTypeId = (int?)filter.GameType,
                     OrderingDirection = filter.OrderingDirection?.ToString(),
                     OrderingField = filter.OrderingField,
                     PageIndex = filter.PageIndex,
                     PageSize = filter.PageSize,
                     StartDateFrom = filter.StartDateFrom,
                     StartDateTo = filter.StartDateTo,
                     TournamentTypeId = (int?)filter.TournamentType
                 });

            if (200 != result.StatusCode)
            {
                return new GetBuraTournamentsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetBuraTournamentsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new BuraTournamentPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Tournaments = result.Data.Tournaments.Select(i => new BuraTournament
                    {
                        TournamentType = (BuraTournamentType)i.TournamentTypeId,
                        BetAmount = i.BetAmount,
                        CreateDate = i.CreateDate,
                        EndDate = i.EndDate,
                        FilteredCount = i.FilteredCount,
                        FinalPoint = i.FinalPoint,
                        GameType = (BuraGameType)i.GameTypeId,
                        Id = i.Id,
                        IsHidden = i.IsHidden,
                        IsNetwork = i.IsNetwork,
                        MaxPlayerCount = i.MaxPlayerCount,
                        MinPlayerCount = i.MinPlayerCount,
                        Prize = i.Prize,
                        Prizes = i.Prizes.Select(p => new BuraTournamentPrize
                        {
                            Id = p.Id,
                            Percent = p.Percent
                        }),
                        RegisteredPlayerCount = i.RegisteredPlayerCount,
                        StartDate = i.StartDate,
                        Status = (BuraTournamentStatus)i.StatusId,
                        HasMolodkaRule = i.HasMolodkaRule,
                        HasRoyalRule = i.HasRoyalRule,
                        Translations = i.Translations.Select(t => new BuraTournamentTranslation
                        {
                            Lang = t.Lang,
                            Name = t.Name
                        })
                    })
                }
            };
        }
    }
}
