using SplinterLands.DTOs.Enums;
using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ILandClient
    {
        VnexApiResponse<LandWorksiteDetails> GetActiveWorksite(string deed_uid);
        Task<VnexApiResponse<LandWorksiteDetails>> GetActiveWorksiteAsync(string deed_uid);

        VnexApiResponse<LandDeedDetails> GetDeedDetails(int deedId);

        Task<VnexApiResponse<LandDeedDetails>> GetDeedDetailsAsync(int deedId);

        VnexApiResponse<LandProjectRewardAction[]> GetRewardActionsForDeed(string deed_uid, int offset = 0, int limit = 10);

        Task<VnexApiResponse<LandProjectRewardAction[]>> GetRewardActionsForDeedAsync(string deed_uid, int offset = 0, int limit = 10);

        VnexApiResponse<GroupedDeedStakeableCards> GetGroupedDeedStakeableCards(StakeTypesEnum stakeTypeUid, string deedUid, string player, int offset, int limit, 
                                                                                GroupedDeedStakeableCardsOrderByEnum orderBy, GroupedDeedStakeableCardsOrderByAscEnum orderbyAsc,
                                                                                uint? card_detail_id = null, uint? bcx = null, bool? gold = null, uint? edition = null, double? land_pp_at_or_gt = null, double? land_pp_at_or_lt = null,
                                                                                double? land_dec_stake_needed_at_or_gt = null, double? land_dec_stake_needed_at_or_lt = null, string? name = null, uint? tier = null);
       Task<VnexApiResponse<GroupedDeedStakeableCards>> GetGroupedDeedStakeableCardsAsync(StakeTypesEnum stakeTypeUid, string deedUid, string player, int offset, int limit,
                                                                                GroupedDeedStakeableCardsOrderByEnum orderBy, GroupedDeedStakeableCardsOrderByAscEnum orderbyAsc,
                                                                                uint? card_detail_id = null, uint? bcx = null, bool? gold = null, uint? edition = null, double? land_pp_at_or_gt = null, double? land_pp_at_or_lt = null,
                                                                                double? land_dec_stake_needed_at_or_gt = null, double? land_dec_stake_needed_at_or_lt = null, string? name = null, uint? tier = null);
        VnexApiResponse<LiquidityReward[]> GetLiquidityRewards();
        Task<VnexApiResponse<LiquidityReward[]>> GetLiquidityRewardsAsync();
    }
}
