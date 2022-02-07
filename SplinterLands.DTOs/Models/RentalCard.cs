using SplinterLands.DTOs.Enums;

namespace SplinterLands.DTOs.Models
{
    public class RentalCard
    {
        public int Id { get; set; } = -1;
        public string Sell_Trx_Id { get; set; } = string.Empty;
        public string Seller { get; set; } = string.Empty;
        public int Num_Cards { get; set; } = 0;
        public string Buy_Price { get; set; } = string.Empty;
        public int Fee_Percent { get; set; } = 0; //Received as Percent * 100
        public Int64 Market_Item_Id { get; set; } = -1;
        public string Rental_Tx { get; set; } = string.Empty;
        public DateTime? Rental_Date { get; set; } = null;
        public string Renter { get; set; } = string.Empty;
        public RentalStatus Status { get; set; } = RentalStatus.Unknown;
        public string Market_Account { get; set; } = string.Empty;
        public string Payment_Currency { get; set; } = string.Empty;
        public string Payment_Amount { get; set; } = string.Empty;
        public string Escrow_Currency { get; set; } = string.Empty;
        public string Escrow_Amount { get; set; } = string.Empty;
        public string Paid_Amount { get; set; } = string.Empty; 
        public string Cancel_Tx { get; set; } = string.Empty;
        public string Cancel_Player { get; set; } = string.Empty;
        public DateTime? Cancel_Date { get; set; } = null;
        public int Card_Detail_Id { get; set; } = -1;
        public bool Gold { get; set; }= false;
        public SetEditionEnum Edition { get; set; } = SetEditionEnum.Invalid;
    }
}
