namespace SplinterLandsAPI.Models
{
    public class BattleActionState
    {
        public bool Alive { get; set; } = false;
        public List<int> Stats { get; set; } = new List<int>();
        public int Base_Health { get; set; } = -1;
        //TODO: we need to flatten this to a key value pair instead of a List of Lists
        public List<List<string>> Other { get; set; } = new List<List<string>>(); 
    }
}
