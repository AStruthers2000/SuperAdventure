using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level
        {
            get { return ((ExperiencePoints / 100) + 1); }
        }
        public Location CurrentLocation { get; set; }


        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }



        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();

        }


        public bool HasRequiredItemToEnterLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                //There is no item required for this location, so return true
                return true;
            }

            //Check to see if the player has the item in their inventory
            return Inventory.Exists(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }


        public bool HasThisQuest(Quest quest)
        {
            return Quests.Exists(pq => pq.Details.ID == quest.ID);
        }


        public bool CompletedThisQuest(Quest quest)
        {
            foreach(PlayerQuest pq in Quests)
            {
                if(pq.Details.ID == quest.ID)
                {
                    return pq.IsCompleted;
                }
            }
            return false;
        }


        public bool HasAllQuestCompletionItems(Quest quest)
        {
            //∀ qci ∈ quest.QuestCompletionItems, ∃ ii ∈ Inventory | ii.ID = qci.ID id.Quantity ≥ qci.Quantity
            return quest.QuestCompletionItems.All(qci => Inventory.Exists(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity));
        }


        public void RemoveQuestCompletionItems(Quest quest)
        {
            //Remove quest items from inventory
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if (item != null)
                {
                    // Subtract the quantity from the player's inventory that was needed to complete the quest
                    item.Quantity -= qci.Quantity;
                }
            }
        }


        public void AddItemToInventory(Item itemToAdd)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
            if(item == null)
            {
                //They didn't have the item, so add it to their inventory with a quantity of 1
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            }
            else
            {
                //They have the item in their inventory, so increase the quantity by one
                item.Quantity++;
            }
        }


        public void MarkQuestCompleted(Quest quest)
        {
            //Find the quest in the player's quest list
            PlayerQuest playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);
            if (playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }
    }
}
