using SplinterLands.DTOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
