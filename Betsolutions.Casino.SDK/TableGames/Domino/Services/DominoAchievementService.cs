using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Domino.Repositories;
using Betsolutions.Casino.SDK.TableGames.Domino.DTO.Achievement;
using Betsolutions.Casino.SDK.TableGames.Domino.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Domino.Services
{
    public sealed class DominoAchievementService
    {
        private readonly DominoAchievementRepository _dominoAchievementRepository;

        public DominoAchievementService(MerchantAuthInfo merchantAuthInfo)
        {
            _dominoAchievementRepository = new DominoAchievementRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(DominoAchievementsFilter filter)
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

        public GetDominoAchievementsResult GetAchievements(DominoAchievementsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetDominoAchievementsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _dominoAchievementRepository.GetAchievements(
                new Internal.TableGames.Domino.DTO.Achievement.AchievementsFilter
                {
                    OrderingDirection = filter.OrderingDirection?.ToString(),
                    OrderingField = filter.OrderingField,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    AchievementTypeId = (int?)filter.AchievementType
                });

            if (200 != result.StatusCode)
            {
                return new GetDominoAchievementsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetDominoAchievementsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new DominoAchievementPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Achievements = result.Data.Achievements.Select(i => new DominoAchievement
                    {
                        AchievementType = (DominoAchievementType)i.AchievementTypeId,
                        CreateDate = i.CreateDate,
                        FilteredCount = i.FilteredCount,
                        Id = i.Id,
                        IsNetwork = i.IsNetwork,
                        Prize = i.Prize,
                        Count = i.Count,
                        IsActive = i.IsActive,
                        MinRank = i.MinRank,
                        Translations = i.Translations.Select(t => new DominoAchievementTranslation
                        {
                            Lang = t.Lang,
                            Name = t.Name,
                            Description = t.Description
                        })
                    })
                }
            };
        }
    }
}
