namespace SplinterLands.DTOs.Models
{
    public class LandProjectSegment
    {
        public int id { get; set; } = 0;
        public int land_project_id { get; set; } = 0;
        public string deed_uid { get; set; } = string.Empty;
        public double staked_pp {get;set;} = 0.0d;
        public double duration { get; set; } = 0.0d;
        public double raw_pp_spent { get; set; } = 0.0d;
        public double pp_spent { get; set; } = 0.0d;
        public double timecrystal_pp { get; set; } = 0.0d;
        public double efficiency { get; set; } = 0.0d;
        public uint time_crystals_used { get; set; } = 0;
        public double time_crystal_value { get; set; } = 0.0d;
        public int project_number { get; set; } = 0;
        public DateTime? created_date { get; set; } = DateTime.MinValue;
        public DateTime? ended_date { get; set; } = null;
        public string opened_trx { get; set; } = string.Empty;
        public string closed_trx { get; set; } = string.Empty;
        public string source { get; set; } = string.Empty;
        public double end_staked_pp { get; set; } = 0.0d;
    }
}
