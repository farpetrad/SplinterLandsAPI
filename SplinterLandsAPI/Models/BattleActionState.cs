namespace SplinterLandsAPI.Models
{
    public class BattleActionState
    {
        public bool Alive { get; set; } = false;
        public List<int> Stats { get; set; } = new List<int>();
        public int Base_Health { get; set; } = -1;
        public List<List<string>> Other { get; set; } = new List<List<string>>(); 
    }
}
