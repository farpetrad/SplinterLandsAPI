using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class Purchase
    {
        public string Purchase_Tx_Id { get; set; } = string.Empty;
        public string Purchase_Id { get; set; } = string.Empty;
        public string Purchase_Type { get; set; } = string.Empty;
        public string Affiliate { get; set; } = string.Empty;
        public string Purchaser { get; set; } = string.Empty;
        public DateTime? Created_Date { get; set; } = null;
        public string Type { get; set; } = string.Empty;
        public string Purchase_Payment { get; set; } = string.Empty;
        public string Affiliate_Payment { get; set; } = string.Empty;
        public string Purchase_Amount_Usd { get; set; } = string.Empty;
        public PlayerPurchaseData Player_Data { get; set; } = new PlayerPurchaseData();

    }
}
