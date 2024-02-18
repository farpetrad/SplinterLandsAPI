namespace SplinterLands.DTOs.Models
{
    public class LandWorksiteDetails
    {
        public int id { get; set; } = 0;
        public string project_type { get; set; } = string.Empty;
        public int project_number { get; set; } = 0;
        public string deed_uid { get; set; } = string.Empty;
        public int resource_id { get; set; } = 0;
        public string token_symbol { get; set; } = string.Empty;
        public int land_work_type_id { get; set; } = 0;
        public int total_time_crystals_used { get; set; } = 0;
        public double pp_staked { get; set; } = 0.0d;
        public double pp_balance { get; set; } = 0.0d;
        public double pp_required { get; set; } = 0.0d;
        public DateTime start_date { get; set; } = DateTime.MinValue;
        public double projected_hours { get; set; } = 0.0d;
        public DateTime? projected_end { get; set; } = null;
        public DateTime? completed_date { get; set; } = null;
        public DateTime created_date { get; set; } = DateTime.MinValue;
        public DateTime last_updated_date { get; set; } = DateTime.MinValue;
        public string trx_id { get; set; } = string.Empty;
        public uint block_num { get; set; } = 0;
        public double? hours_to_completion { get; set; } = 0.0d;
        public double elapsed_hours { get; set; } = 0.0d;
        public double pp_spent { get; set; } = 0.0d;
        public double grain_required { get; set; } = 0.0d;
        public bool is_active { get; set; } = false;
        public DateTime? destroyed_date { get; set; } = null;
        public bool is_construction { get; set; } = false;
        public DateTime last_action_time { get; set; } = DateTime.MinValue;
        public double hours_till_next_op { get; set; } = 0.0d;
        public DateTime? next_op_allowed_date {get;set;} = null;
        public double projected_amount_received { get; set; } = 0.0d;
        public double work_per_hour_per_one_pp { get; set; } = 0.0d;
        public int project_id { get; set; } = 0;
        public bool is_harvesting { get; set; } = false;
        public bool is_empty { get; set; } = false;
        public bool is_sps_work { get; set; } = false;
        public double sps_mining_reward_debt { get; set; } = 0.0d;
        public uint latest_sps_reward_block { get; set; } = 0;
        public double sps_tokens_per_block { get; set; } = 0.0d;
        public double accumulated_sps_rewards_per_share_of_pool { get; set; } = 0.0d;
        public double land_work_type_total_work_type_pp { get; set; } = 0.0d;
        public double? captured_tax_rate { get; set; } = null;
        public double time_crystal_value { get; set; } = 0.0d;
        public DateTime project_created_date { get; set; } = DateTime.Now;
        public string worksite_type { get; set; } = string.Empty;
        public double? max_tax_rate { get; set; } = null;
        public string region_uid { get;set; } = string.Empty;
        public double hours_since_last_op { get; set; } = 0.0d;
        public double site_efficiency { get; set; } = 0.0d;
        public bool is_runi_staked { get; set; } = false;
        public double rewards_per_hour {get;set;} = 0.0d;
        public double grain_req_per_hour { get; set; } = 0.0d;
        public LandProjectSegment[] segments { get; set; } = [];
        public double estimated_totem_chance { get; set; } = 0.0d;
    }
}
