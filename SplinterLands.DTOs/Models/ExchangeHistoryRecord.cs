namespace SplinterLands.DTOs.Models
{
    public  class ExchangeHistoryRecord
    {
        public string amount_from { get; set; } = string.Empty;
        public string amount_to { get; set;} = string.Empty;
        public string converter_memo_base64 { get; set; } = string.Empty;
        public string converter_memo_plain { get; set; } = string.Empty;
        public DateTime created_date { get; set; } = DateTime.MinValue;
        public string currency_from { get; set; } = string.Empty;
        public string currency_to { get; set; } = string.Empty;
        public string exchange_address { get; set; } = string.Empty;
        public string exchange_id { get; set; } = string.Empty;
        public string? exchange_memo { get; set; } = null;
        public uint id { get; set; } = 0;
        public string player { get; set; } = string.Empty;
        public string purchase_origin { get; set; } = string.Empty;
    }
}
