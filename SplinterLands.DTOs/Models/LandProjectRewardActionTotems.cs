using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class LandProjectRewardActionTotems
    {
        public int id { get; set; } = 0;
        public int reward_action_id { get; set; } = 0;
        public int land_work_type_id { get; set; } = 0;
        public int land_project_number { get; set; } = 0;
        public int tract_number { get; set; } = 0;
        public int region_number { get; set; } = 0;
        public string deed_uid { get; set; } = string.Empty;
        public string fragment_type { get; set; } = string.Empty;
        public bool fragment_found { get; set; } = false;
        public double fragment_chance { get; set; } = 0.0d;
        public double fragment_roll { get; set; } = 0.0d;
        public string trx_id { get; set; } = string.Empty;
        public int block_num { get; set; } = 0;
        public DateTime? created_date { get; set; } = null;
        public DateTime? last_updated_date { get; set; } = null;
    }
}
