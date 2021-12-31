namespace SplinterLandsAPI.Models
{
    public class BattleSettings
    {
        public int Rating_Level { get; set; } = -1;

        public override string ToString()
        {
            return $"{{ Rating_level: {Rating_Level}}}";
        }
    }
}
