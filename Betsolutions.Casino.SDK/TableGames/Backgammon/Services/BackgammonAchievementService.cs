using System.Linq;
using Betsolutions.Casino.SDK.Internal.TableGames.Backgammon.Repositories;
using Betsolutions.Casino.SDK.TableGames.Backgammon.DTO.Achievement;
using Betsolutions.Casino.SDK.TableGames.Backgammon.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Backgammon.Services
{
    public class BackgammonAchievementService
    {
        private readonly BackgammonAchievementRepository _backgammonAchievementRepository;

        public BackgammonAchievementService(MerchantAuthInfo merchantAuthInfo)
        {
            _backgammonAchievementRepository = new BackgammonAchievementRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(BackgammonAchievementsFilter filter)
        {
            if (filter.PageIndex < 1)
            {
                return $"invalid {nameof(filter.PageIndex)}";
            }

            if (filter.PageSize < 1)
            {
                return $"invalid {nameof(filter.PageSize)}";
            }

            if (filter.OrderingDirection != null
                && filter.OrderingDirection.ToLowerInvariant() != "asc"
                && filter.OrderingDirection.ToLowerInvariant() != "desc")
            {
                return $"invalid {nameof(filter.OrderingDirection)}";
            }

            return null;
        }

        public GetBackgammonAchievementsResult GetAchievements(BackgammonAchievementsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetBackgammonAchievementsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _backgammonAchievementRepository.GetAchievements(
                new Internal.TableGames.Backgammon.DTO.Achievement.AchievementsFilter
                {
                    OrderingDirection = filter.OrderingDirection,
                    OrderingField = filter.OrderingField,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    AchievementTypeId = (int?) filter.AchievementType
                });

            if (200 != result.StatusCode)
            {
                return new GetBackgammonAchievementsResult {StatusCode = (StatusCodes) result.StatusCode};
            }

            return new GetBackgammonAchievementsResult
            {
                StatusCode = (StatusCodes) result.StatusCode,
                Data = new BackgammonAchievementPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Achievements = result.Data.Achievements.Select(i => new BackgammonAchievement
                    {
                        AchievementType = (BackgammonAchievementType)i.AchievementTypeId,
                        CreateDate = i.CreateDate,
                        FilteredCount = i.FilteredCount,
                        Id = i.Id,
                        IsNetwork = i.IsNetwork,
                        Prize = i.Prize,
                        Count = i.Count,
                        Dice1 = i.Dice1,
                        Dice2 = i.Dice2,
                        IsActive = i.IsActive,
                        MinRank = i.MinRank,
                        Translations = i.Translations.Select(t => new BackgammonAchievementTranslation
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
