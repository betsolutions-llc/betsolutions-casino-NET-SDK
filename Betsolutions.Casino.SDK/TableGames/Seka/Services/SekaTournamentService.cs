using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Seka.Repositories;
using Betsolutions.Casino.SDK.TableGames.Seka.DTO.Tournament;
using Betsolutions.Casino.SDK.TableGames.Seka.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Seka.Services
{
    public class SekaTournamentService
    {
        private readonly SekaTournamentRepository _backgammonTournamentRepository;

        public SekaTournamentService(MerchantAuthInfo merchantAuthInfo)
        {
            _backgammonTournamentRepository = new SekaTournamentRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(SekaTournamentsFilter filter)
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

        public GetSekaTournamentsResult GetTournaments(SekaTournamentsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetSekaTournamentsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _backgammonTournamentRepository.GetTournaments(
                 new Internal.TableGames.Seka.DTO.Tournament.TournamentsFilter
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
                return new GetSekaTournamentsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetSekaTournamentsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new SekaTournamentPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Tournaments = result.Data.Tournaments.Select(i => new SekaTournament
                    {
                        TournamentType = (SekaTournamentType)i.TournamentTypeId,
                        BetAmount = i.BetAmount,
                        CreateDate = i.CreateDate,
                        EndDate = i.EndDate,
                        FilteredCount = i.FilteredCount,
                        FinalPoint = i.FinalPoint,
                        GameType = (SekaGameType)i.GameTypeId,
                        Id = i.Id,
                        IsHidden = i.IsHidden,
                        IsNetwork = i.IsNetwork,
                        MaxPlayerCount = i.MaxPlayerCount,
                        MinPlayerCount = i.MinPlayerCount,
                        Prize = i.Prize,
                        RebuyMaxLevel = i.RebuyMaxLevel,
                        WithRebuy = i.WithRebuy,
                        Prizes = i.Prizes.Select(p => new SekaTournamentPrize
                        {
                            Id = p.Id,
                            Percent = p.Percent
                        }),
                        RegisteredPlayerCount = i.RegisteredPlayerCount,
                        StartDate = i.StartDate,
                        Status = (SekaTournamentStatus)i.StatusId,
                        Translations = i.Translations.Select(t => new SekaTournamentTranslation
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
