using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        public int LevelRequiredToEnter { get; set; }
        public List<Quest> QuestStartHere { get; set; }
        public List<Quest> QuestFinishHere { get; set; }
        public Dictionary<Item, int> ItemsPickUpHere { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }

        public Location(int id, string name, string description, Item itemRequiredToEnter = null, int levelRequiredToEnter = 0, Quest questStartHere = null, Quest questFinishHere = null, Monster monsterLivingHere = null)
        {
            ID = id;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
            LevelRequiredToEnter = levelRequiredToEnter;

            MonsterLivingHere = monsterLivingHere;

            QuestStartHere = new List<Quest>();
            QuestFinishHere = new List<Quest>();
            ItemsPickUpHere = new Dictionary<Item, int>();
        }
    }
}
