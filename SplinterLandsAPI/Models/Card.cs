namespace SplinterLandsAPI.Models
{
    public class Card
    {
        public int Id { get; set; } = -1;
        public string Name { get; set; } = String.Empty;
        public string Color { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        public CardRarity Rarity { get; set; } = CardRarity.Unknown;
        public Int64 Total_printed { get; set; } = -1;
        public bool Is_Promo { get; set; } = false;
        public bool Is_Starter { get; set; } = false;

        public CardStats Stats { get; set; } = new CardStats();
        public Object? Subtype { get; set; } = null;
        public Object? tier { get; set; } = null;
        public int MaxLevel => MaxLevelForRarity();

        private int MaxLevelForRarity()
        {
            if (Rarity == CardRarity.Common)
            {
                return 10;
            }
            else if (Rarity == CardRarity.Rare)
            {
                return 8;
            }
            else if (Rarity == CardRarity.Epic)
            {
                return 6;
            }
            else if (Rarity == CardRarity.Legendary)
            {
                return 4;
            }
            return -1;
        }
    }
}
