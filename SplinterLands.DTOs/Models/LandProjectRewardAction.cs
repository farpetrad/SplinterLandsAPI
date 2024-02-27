using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class LandProjectRewardAction
    {
        public int id { get; set; } = 0;
        public int plot_id { get; set; } = 0;
        public int tract_id { get; set; } = 0;
        public int region_number { get; set; } = 0;
        public string region_uid { get; set; } = string.Empty;
        public int land_worksite_id { get; set; } = 0;
        public int land_project_id { get; set; } = 0;
        public int resource_id { get; set; } = 0;
        public string resource_symbol { get; set; } = string.Empty;
        public double working_pp { get; set; } = 0.0d;
        public double duration { get; set; } = 0.0d;
        public string deed_uid { get; set; } = string.Empty;
        public double claim_amount { get; set; } = 0.0d;
        public double grain_required { get; set; } = 0.0d;
        public double claim_amount_eaten { get; set; } = 0.0d;
        public double amount_received { get; set; } = 0.0d;
        public double site_efficiency { get; set; } = 0.0d;
        public double amount_taxed { get; set; } = 0.0d;
        public double tax_burnt { get; set; } = 0.0d;
        public string trx_description { get; set; } = string.Empty;
        public string trx_id { get; set; } = string.Empty;
        public int block_num { get; set; } = 0;
        public DateTime? created_date {get; set;} = null;
        public DateTime? last_updated_date { get; set; } = null;
        public LandProjectRewardActionTotems? fragment_roll { get; set; } = null;
    }
}
