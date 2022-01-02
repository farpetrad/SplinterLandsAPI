using Newtonsoft.Json.Linq;
using System.Linq;

namespace SplinterLandsAPI.Models
{
    public class CardStats
    {
        // So we need to use objects due to how the cards present these stats.
        // On a monster these are arrays of numbers to denote what value each
        // stat is at a particular card level, ex a common could have an armor 
        // stat of [ 1, 1, 2, 3, 2, 2, 3, 3, 4, 4] where each value denotes how much
        // armor the card has at that level, where as a summoner will have a single value
        // for any stat, if it is non 0 then that is how much of that stat the summoner
        // gives each monster.  However the abilities a summoner grants are an array
        // but these always apply to all monsters, where as a monsters abilities
        // array denotes what level an ability is granted to the card hence using Object
        // and parsing to the correct data type.  Also the Splinterlands api seems to return
        // these stat values as 64 bit integers even though they can be represented by an int.
        private Object _Armor = new Object();
        public Object Armor { 
            get => _Armor; 
            set
            {
                _Armor = ParsePropertyValue(value);
            }
        }
        private Object _Attack = new Object();
        public Object Attack
        {
            get => _Attack;
            set
            {
                _Attack = ParsePropertyValue(value);
            }
        }
        private Object _Health = new Object();
        public Object Health
        {
            get => _Health;
            set
            {
                _Health = ParsePropertyValue(value);
            }
        }
        private Object _Magic = new Object();
        public Object Magic
        {
            get => _Magic;
            set
            {
                _Magic = ParsePropertyValue(value);
            }
        }
        private Object _Mana = new Object();
        public Object Mana
        {
            get => _Mana;
            set
            {
                _Mana = ParsePropertyValue(value);
            }
        }
        private Object _Ranged = new Object();
        public Object Ranged
        {
            get => _Ranged;
            set
            {
                _Ranged = ParsePropertyValue(value);
            }
        }
        private Object _Speed = new Object();
        public Object Speed
        {
            get => _Speed;
            set
            {
                _Speed = ParsePropertyValue(value);
            }
        }
        private Object _Abilities = new Object();
        public Object Abilities
        {
            get => _Abilities;
            set
            {
                _Abilities = ParseAbilities(value);
            }
        }

        private Object ParsePropertyValue(Object value)
        {
            Object? parsed = new Object();
            if (value.GetType() == typeof(JArray))
            {
                JArray? tmp = value as JArray;
                parsed = tmp != null ? tmp.ToObject<List<string>>() : new Object();
            }
            else
            {
                parsed = value.ToString();
            }
            return parsed != null ? parsed : new Object();
        }

        private Object ParseAbilities(Object value)
        {
           Object parsed = new List<List<string>>();
            if(value.GetType() == typeof(JArray))
            {
                JArray? tmp = value as JArray;
                if(tmp != null)
                {
                    if(tmp.Children().First().GetType() == typeof(JValue))
                    {
                        parsed = tmp.Children().Select(child => child.ToString()).ToList();
                    }
                    else
                    {
                        parsed = tmp.Children().Select(child =>
                        {
                            var array = child.Children().Select(subChild => subChild == null ? "" : subChild.ToString()).ToList();
                            return String.Join(",",array);
                        }).ToList();
                    }
                    
                }
            }
            return parsed; 
        }
    }
}
