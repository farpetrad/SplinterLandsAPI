namespace SplinterLands.DTOs.Models
{
    public class TokenHistoryRecord
    {
        public string player { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string balance_start { get; set; } = string.Empty;
        public string balance_end { get; set;} = string.Empty;
        public uint block_num { get; set; } = 0;
        public string trx_id { get; set; } = string.Empty;
        public string type { get;set; } = string.Empty;
        public DateTime created_date { get; set; } = DateTime.MinValue;
        public string counterparty { get; set; } = string.Empty;
        public DateTime last_update_date {  get; set; } = DateTime.MinValue;
        public bool is_archived { get; set; } = false;
    }
}
