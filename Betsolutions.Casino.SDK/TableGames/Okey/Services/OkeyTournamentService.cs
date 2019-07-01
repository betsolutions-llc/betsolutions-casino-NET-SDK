using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Okey.Repositories;
using Betsolutions.Casino.SDK.TableGames.Okey.DTO.Tournament;
using Betsolutions.Casino.SDK.TableGames.Okey.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Okey.Services
{
    public class OkeyTournamentService
    {
        private readonly OkeyTournamentRepository _okeyTournamentRepository;

        public OkeyTournamentService(MerchantAuthInfo merchantAuthInfo)
        {
            _okeyTournamentRepository = new OkeyTournamentRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(OkeyTournamentsFilter filter)
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

        public GetOkeyTournamentsResult GetTournaments(OkeyTournamentsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetOkeyTournamentsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _okeyTournamentRepository.GetTournaments(
                 new Internal.TableGames.Okey.DTO.Tournament.TournamentsFilter
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
                return new GetOkeyTournamentsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetOkeyTournamentsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new OkeyTournamentPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Tournaments = result.Data.Tournaments.Select(i => new OkeyTournament
                    {
                        TournamentType = (OkeyTournamentType)i.TournamentTypeId,
                        BetAmount = i.BetAmount,
                        CreateDate = i.CreateDate,
                        EndDate = i.EndDate,
                        FilteredCount = i.FilteredCount,
                        FinalPoint = i.FinalPoint,
                        GameType = (OkeyGameType)i.GameTypeId,
                        Id = i.Id,
                        IsHidden = i.IsHidden,
                        IsNetwork = i.IsNetwork,
                        MaxPlayerCount = i.MaxPlayerCount,
                        MinPlayerCount = i.MinPlayerCount,
                        Prize = i.Prize,
                        Prizes = i.Prizes.Select(p => new OkeyTournamentPrize
                        {
                            Id = p.Id,
                            Percent = p.Percent
                        }),
                        RegisteredPlayerCount = i.RegisteredPlayerCount,
                        StartDate = i.StartDate,
                        Status = (OkeyTournamentStatus)i.StatusId,
                        Translations = i.Translations.Select(t => new OkeyTournamentTranslation
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
