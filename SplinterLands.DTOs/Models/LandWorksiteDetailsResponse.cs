using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class LandWorksiteDetailsResponse
    {
        public string status { get; set; } = string.Empty;
        public LandWorksiteDetails data { get; set; } = null;
    }
}
