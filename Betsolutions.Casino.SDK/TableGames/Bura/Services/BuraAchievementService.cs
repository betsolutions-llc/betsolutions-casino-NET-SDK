using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Bura.Repositories;
using Betsolutions.Casino.SDK.TableGames.Bura.DTO.Achievement;
using Betsolutions.Casino.SDK.TableGames.Bura.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Bura.Services
{
    public sealed class BuraAchievementService
    {
        private readonly BuraAchievementRepository _buraAchievementRepository;

        public BuraAchievementService(MerchantAuthInfo merchantAuthInfo)
        {
            _buraAchievementRepository = new BuraAchievementRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(BuraAchievementsFilter filter)
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

        public GetBuraAchievementsResult GetAchievements(BuraAchievementsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetBuraAchievementsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _buraAchievementRepository.GetAchievements(
                new Internal.TableGames.Bura.DTO.Achievement.AchievementsFilter
                {
                    OrderingDirection = filter.OrderingDirection?.ToString(),
                    OrderingField = filter.OrderingField,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    AchievementTypeId = (int?)filter.AchievementType
                });

            if (200 != result.StatusCode)
            {
                return new GetBuraAchievementsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetBuraAchievementsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new BuraAchievementPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Achievements = result.Data.Achievements.Select(i => new BuraAchievement
                    {
                        AchievementType = (BuraAchievementType)i.AchievementTypeId,
                        CreateDate = i.CreateDate,
                        FilteredCount = i.FilteredCount,
                        Id = i.Id,
                        IsNetwork = i.IsNetwork,
                        Prize = i.Prize,
                        Count = i.Count,
                        IsActive = i.IsActive,
                        MinRank = i.MinRank,
                        Translations = i.Translations.Select(t => new BuraAchievementTranslation
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
