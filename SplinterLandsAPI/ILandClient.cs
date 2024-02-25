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
        LandWorksiteDetailsResponse GetActiveWorksite(string deed_uid);
        Task<LandWorksiteDetailsResponse> GetActiveWorksiteAsync(string deed_uid);
    }
}
