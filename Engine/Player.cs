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
        public int Level { get; set; }
        public Location CurrentLocation { get; set; }


        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }



        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();

        }


        public bool HasRequiredItemToEnterLocation(Location location)
        {
            if(location.ItemRequiredToEnter == null)
            {
                //There is no item required for this location, so return true
                return true;
            }

            //Check to see if the player has the item in their inventory
            foreach(InventoryItem ii in Inventory)
            {
                if(ii.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    //We found the item, so return true
                    return true;
                }
            }

            //We didn't find the required item, so return false
            return false;
        }


        public bool HasThisQuest(Quest quest)
        {
            foreach(PlayerQuest pq in Quests)
            {
                if(pq.Details.ID == quest.ID)
                {
                    return true;
                }
            }
            return false;
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
            //See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayerInventory = false;

                //Check each item in the player's inventory to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    //The player has this item in their inventory
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        foundItemInPlayerInventory = true;
                        if (ii.Quantity < qci.Quantity)
                        {
                            //The player does not have enough of this item to complete the quest
                            return false;
                        }
                    }
                }

                //If we didn't find the required item, set our variable and stop looking for other items
                if (!foundItemInPlayerInventory)
                {
                    return false;
                }
            }

            //If we got here, the player must have all the required items at the right quantity
            return true;
        }


        public void RemoveQuestCompletionItems(Quest quest)
        {
            //Remove quest items from inventory
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        //Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }


        public void AddItemToInventory(Item itemToAdd)
        {

            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    //They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;
                    return;
                }
            }

            //They didn't have the item, so add it to their inventory with a quantity of 1
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }


        public void MarkQuestCompleted(Quest quest)
        {
            //Find the quest in the player's quest list
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    //Mark it as complete
                    pq.IsCompleted = true;
                    return;
                }
            }
        }
    }
}
