using System;
using System.Linq;
using Betsolutions.Casino.SDK.Enums;
using Betsolutions.Casino.SDK.Internal.TableGames.Seka.Repositories;
using Betsolutions.Casino.SDK.TableGames.Seka.DTO.Achievement;
using Betsolutions.Casino.SDK.TableGames.Seka.Enums;

namespace Betsolutions.Casino.SDK.TableGames.Seka.Services
{
    public sealed class SekaAchievementService
    {
        private readonly SekaAchievementRepository _sekaAchievementRepository;

        public SekaAchievementService(MerchantAuthInfo merchantAuthInfo)
        {
            _sekaAchievementRepository = new SekaAchievementRepository(merchantAuthInfo);
        }

        private string ValidateRequestModel(SekaAchievementsFilter filter)
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

        public GetSekaAchievementsResult GetAchievements(SekaAchievementsFilter filter)
        {
            var validationErrorMessage = ValidateRequestModel(filter);

            if (null != validationErrorMessage)
            {
                return new GetSekaAchievementsResult
                {
                    StatusCode = StatusCodes.InvalidRequest,
                    Message = validationErrorMessage
                };
            }

            var result = _sekaAchievementRepository.GetAchievements(
                new Internal.TableGames.Seka.DTO.Achievement.AchievementsFilter
                {
                    OrderingDirection = filter.OrderingDirection?.ToString(),
                    OrderingField = filter.OrderingField,
                    PageIndex = filter.PageIndex,
                    PageSize = filter.PageSize,
                    AchievementTypeId = (int?)filter.AchievementType
                });

            if (200 != result.StatusCode)
            {
                return new GetSekaAchievementsResult { StatusCode = (StatusCodes)result.StatusCode };
            }

            return new GetSekaAchievementsResult
            {
                StatusCode = (StatusCodes)result.StatusCode,
                Data = new SekaAchievementPagingResult
                {
                    TotalCount = result.Data.TotalCount,
                    Achievements = result.Data.Achievements.Select(i => new SekaAchievement
                    {
                        AchievementType = (SekaAchievementType)i.AchievementTypeId,
                        CreateDate = i.CreateDate,
                        FilteredCount = i.FilteredCount,
                        Id = i.Id,
                        IsNetwork = i.IsNetwork,
                        Prize = i.Prize,
                        Count = i.Count,
                        IsActive = i.IsActive,
                        MinRank = i.MinRank,
                        Translations = i.Translations.Select(t => new SekaAchievementTranslation
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
