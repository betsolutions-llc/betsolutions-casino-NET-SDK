using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Domino.Repositories;
using Betsolutions.Casino.SDK.TableGames.Domino.DTO.Tournament;
using Betsolutions.Casino.SDK.TableGames.Domino.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Domino.Services
{
    public class DominoTournamentService
    {
        private readonly DominoTournamentRepository _dominoTournamentRepository;

        public DominoTournamentService(MerchantAuthInfo merchantAuthInfo)
        {
            _dominoTournamentRepository = new DominoTournamentRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(DominoTournamentsFilter filter)
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

        public GetDominoTournamentsResult GetTournaments(DominoTournamentsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetDominoTournamentsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _dominoTournamentRepository.GetTournaments(
                 new Internal.TableGames.Domino.DTO.Tournament.TournamentsFilter
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
                return new GetDominoTournamentsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetDominoTournamentsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new DominoTournamentPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Tournaments = result.Data.Tournaments.Select(i => new DominoTournament
                    {
                        TournamentType = (DominoTournamentType)i.TournamentTypeId,
                        BetAmount = i.BetAmount,
                        CreateDate = i.CreateDate,
                        EndDate = i.EndDate,
                        FilteredCount = i.FilteredCount,
                        FinalPoint = i.FinalPoint,
                        GameType = (DominoGameType)i.GameTypeId,
                        Id = i.Id,
                        IsHidden = i.IsHidden,
                        IsNetwork = i.IsNetwork,
                        MaxPlayerCount = i.MaxPlayerCount,
                        MinPlayerCount = i.MinPlayerCount,
                        Prize = i.Prize,
                        Prizes = i.Prizes.Select(p => new DominoTournamentPrize
                        {
                            Id = p.Id,
                            Percent = p.Percent
                        }),
                        RegisteredPlayerCount = i.RegisteredPlayerCount,
                        StartDate = i.StartDate,
                        Status = (DominoTournamentStatus)i.StatusId,
                        Translations = i.Translations.Select(t => new DominoTournamentTranslation
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
