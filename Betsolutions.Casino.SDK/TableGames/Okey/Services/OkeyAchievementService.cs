using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Okey.Repositories;
using Betsolutions.Casino.SDK.TableGames.Okey.DTO.Achievement;
using Betsolutions.Casino.SDK.TableGames.Okey.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Okey.Services
{
    public class OkeyAchievementService
    {
        private readonly OkeyAchievementRepository _okeyAchievementRepository;

        public OkeyAchievementService(MerchantAuthInfo merchantAuthInfo)
        {
            _okeyAchievementRepository = new OkeyAchievementRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(OkeyAchievementsFilter filter)
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

        public GetOkeyAchievementsResult GetAchievements(OkeyAchievementsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetOkeyAchievementsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _okeyAchievementRepository.GetAchievements(
                new Internal.TableGames.Okey.DTO.Achievement.AchievementsFilter
                {
                    OrderingDirection = filter.OrderingDirection?.ToString(),
                    OrderingField = filter.OrderingField,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    AchievementTypeId = (int?)filter.AchievementType
                });

            if (200 != result.StatusCode)
            {
                return new GetOkeyAchievementsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetOkeyAchievementsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new OkeyAchievementPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Achievements = result.Data.Achievements.Select(i => new OkeyAchievement
                    {
                        AchievementType = (OkeyAchievementType)i.AchievementTypeId,
                        CreateDate = i.CreateDate,
                        FilteredCount = i.FilteredCount,
                        Id = i.Id,
                        IsNetwork = i.IsNetwork,
                        Prize = i.Prize,
                        Count = i.Count,
                        IsActive = i.IsActive,
                        MinRank = i.MinRank,
                        Translations = i.Translations.Select(t => new OkeyAchievementTranslation
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
