namespace SplinterLands.DTOs.Models
{
    public class ReferralCollection
    {
        public List<Referral> Referrals { get; set; } = new List<Referral>();
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
