using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ComponentModel;

namespace Engine
{
    public class Player : LivingCreature
    {
        private int _gold;
        private int _experiencePoints;
        private Location _currentLocation;
        private Monster _currentMonster;

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
                OnPropertyChanged("Level");
            }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged("CurrentLocation");
            }
        }
        

        public int Level
        {
            get { return ((ExperiencePoints / 100) + 1); }
        }

        public Weapon CurrentWeapon { get; set; }


        public BindingList<InventoryItem> Inventory { get; set; }
        public BindingList<PlayerQuest> Quests { get; set; }

        public List<Weapon> Weapons
        {
            get { return Inventory.Where(x=>x.Details is Weapon).Select(x => x.Details as Weapon).ToList(); }
        }

        public List<Potion> Potions
        {
            get { return Inventory.Where(x => x.Details is Potion).Select(x => x.Details as Potion).ToList(); }
        }


        public event EventHandler<MessageEventArgs> OnMessage;

        
        private Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;

            Inventory = new BindingList<InventoryItem>();
            Quests = new BindingList<PlayerQuest>();
        }

        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(10, 10, 20, 0);
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));
            player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

            return player;
        }

        public static Player CreatePlayerFromXmlString(string xmlPlayerData)
        {
            try
            {
                XmlDocument playerData = new XmlDocument();

                playerData.LoadXml(xmlPlayerData);

                int currentHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoints").InnerText);
                int maximumHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumHitPoints").InnerText);
                int gold = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);
                int experiencePoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/ExperiencePoints").InnerText);

                Player player = new Player(currentHitPoints, maximumHitPoints, gold, experiencePoints);

                int currentLocationID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLocation").InnerText);
                player.CurrentLocation = World.LocationByID(currentLocationID);

                if (playerData.SelectSingleNode("/Player/Stats/CurrentWeapon") != null)
                {
                    int currentWeaponID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentWeapon").InnerText);
                    player.CurrentWeapon = (Weapon)World.ItemByID(currentWeaponID);
                }

                foreach(XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);

                    for(int i = 0; i<quantity; i++)
                    {
                        player.AddItemToInventory(World.ItemByID(id));
                    }
                }

                foreach(XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);

                    PlayerQuest playerQuest = new PlayerQuest(World.QuestByID(id));
                    playerQuest.IsCompleted = isCompleted;

                    player.Quests.Add(playerQuest);
                }

                return player;
            }
            catch
            {
                //If there was an error with the XML data, return a default player object
                return Player.CreateDefaultPlayer();
            }
        }

        private void RaiseMessage(string message, bool addExtraNewLine = false)
        {
            if (OnMessage != null)
            {
                OnMessage(this, new MessageEventArgs(message, addExtraNewLine));
            }
        }
        
        public void AddExperiencePoints(int experiencePointsToAdd)
        {
            ExperiencePoints += experiencePointsToAdd;
            MaximumHitPoints = (Level * 10);
        }

        public bool HasRequiredItemToEnterLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                //There is no item required for this location, so return true
                return true;
            }

            //Check to see if the player has the item in their inventory
            return Inventory.Any(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            return Quests.Any(pq => pq.Details.ID == quest.ID);
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
            return quest.QuestCompletionItems.All(qci => Inventory.Any(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity));
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            //Remove quest items from inventory
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                // Subtract the quantity from the player's inventory that was needed to complete the quest
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if (item != null)
                {
                    RemoveItemFromInventory(item.Details, qci.Quantity);
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd, int quantity = 1)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);

            if (item == null)
            {
                //They didn't have the item, so add it to their inventory with a quantity of 1
                Inventory.Add(new InventoryItem(itemToAdd, quantity));
            }
            else
            {
                if (itemToAdd.Price == World.UNSELLABLE_ITEM_PRICE)
                {
                    //If the item can't be sold, i.e. a quest item, only allow one in the inventory
                    return;
                }
                else
                {
                    //They have the item in their inventory, so increase the quantity
                    item.Quantity += quantity;
                }
            }
            RaiseInventoryChangedEvent(itemToAdd);
        }

        public void RemoveItemFromInventory(Item itemToRemove, int quantity = 1)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToRemove.ID);
            if(item == null)
            {
                //The item is not in the player's inventory, so we ignore it

                //We might want to raise an error for this situation
            }
            else
            {
                //They have the item in their inventory, so decrease the quantity
                item.Quantity -= quantity;

                //Don't allow negative quantities
                //We might want to raise an error for this situation
                if(item.Quantity < 0)
                {
                    item.Quantity = 0;
                }

                //If the quantity is zero, remove the item from the list
                if(item.Quantity == 0)
                {
                    Inventory.Remove(item);
                }

                //Notify UI that the inventory has chainged
                RaiseInventoryChangedEvent(itemToRemove);
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


        public string ToXMLString()
        {
            XmlDocument playerData = new XmlDocument();

            //Create the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            //Create the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            //Create the child nodes for the "Stats" node
            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(this.CurrentHitPoints.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(this.MaximumHitPoints.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(this.Gold.ToString()));
            stats.AppendChild(gold);

            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(this.ExperiencePoints.ToString()));
            stats.AppendChild(experiencePoints);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(this.CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);

            if (CurrentWeapon != null)
            {
                XmlNode currentWeapon = playerData.CreateElement("CurrentWeapon");
                currentWeapon.AppendChild(playerData.CreateTextNode(this.CurrentWeapon.ID.ToString()));
                stats.AppendChild(currentWeapon);
            }

            //Create the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            //Create an "InventoryItem" node for each item in the player's inventory
            foreach(InventoryItem item in this.Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);

                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);

                inventoryItems.AppendChild(inventoryItem);
            }

            //Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            //Create a "PlayerQuest" node for each quest the player has aquired
            foreach(PlayerQuest quest in this.Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);

                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);

                playerQuests.AppendChild(playerQuest);
            }

            //Return the XML document, as a string, so we can save the data to a disk
            return playerData.InnerXml;
        }


        private void RaiseInventoryChangedEvent(Item item)
        {
            switch (item)
            {
                case Weapon:
                    OnPropertyChanged("Weapons");
                    break;
                case Potion:
                    OnPropertyChanged("Potions");
                    break;
                default:
                    break;
            }
        }


        public void MoveTo(Location newLocation)
        {
            //Does the location have any required items?
            if (newLocation.ItemRequiredToEnter != null)
            {
                if (!HasRequiredItemToEnterLocation(newLocation))
                {
                    RaiseMessage("You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location.");
                    return;
                }
                else
                {
                    RaiseMessage("You have the required " + newLocation.ItemRequiredToEnter.Name + " so this area can now be accessed whenever you want.");
                    //RemoveItemFromInventory(newLocation.ItemRequiredToEnter);
                    newLocation.ItemRequiredToEnter = null;
                }
            }

            //Does the player have the appropriate level to enter?
            if(Level < newLocation.LevelRequiredToEnter)
            {
                RaiseMessage("The guards prevent you from entering until you're level " + newLocation.LevelRequiredToEnter);
                return;
            }

            //Update the player's current location
            CurrentLocation = newLocation;

            //Full heal the player
            CurrentHitPoints = MaximumHitPoints;

            //Are there any pickup items here?
            if (newLocation.ItemsPickUpHere.Any())
            {
                RaiseMessage("You found:");
                foreach(KeyValuePair<Item, int> pickUp in newLocation.ItemsPickUpHere)
                {
                    RaiseMessage(pickUp.Value + " " + (pickUp.Value > 1 ? pickUp.Key.NamePlural : pickUp.Key.Name));
                    AddItemToInventory(pickUp.Key, pickUp.Value);
                }
            }

            //Does any quest start here?
            if (newLocation.QuestStartHere.Any())
            {
                //Iterate through all quests that start in this location
                foreach (Quest questStart in newLocation.QuestStartHere)
                {
                    //See if the player already has the quest, and if they've completed it
                    bool playerAlreadyHasQuest = HasThisQuest(questStart);

                    //See if the player already has the quest
                    if (!playerAlreadyHasQuest)
                    {
                        //The player does not already have the quest

                        //Display the messages
                        RaiseMessage("You receive the " + questStart.Name + " quest.");
                        RaiseMessage(questStart.Description);

                        //Does the player get any items to start the quest?
                        if (questStart.StartItems.Any())
                        {
                            RaiseMessage("You will be given the following items to complete the quest:");
                            foreach (KeyValuePair<Item, int> startItem in questStart.StartItems)
                            {
                                RaiseMessage(startItem.Value + " " + (startItem.Value > 1 ? startItem.Key.NamePlural : startItem.Key.Name));
                                AddItemToInventory(startItem.Key, startItem.Value);
                            }
                        }

                        //Does this quest require any items to complete?
                        if (questStart.QuestCompletionItems.Any())
                        {
                            RaiseMessage("To complete it, return with:");

                            foreach (QuestCompletionItem qci in questStart.QuestCompletionItems)
                            {
                                if (qci.Quantity == 1)
                                {
                                    RaiseMessage(qci.Quantity.ToString() + " " + qci.Details.Name);
                                }
                                else
                                {
                                    RaiseMessage(qci.Quantity.ToString() + " " + qci.Details.NamePlural);
                                }
                            }
                        }
                        RaiseMessage("");

                        //Add the quest to the player's quest list
                        Quests.Add(new PlayerQuest(questStart));
                    }
                }
            }

            //Do any quests finish here
            if (newLocation.QuestFinishHere.Any())
            {
                //Iterate through all quests that finish in this location
                foreach(Quest questFinish in newLocation.QuestFinishHere)
                {
                    bool playerAlreadyCompletedQuest = CompletedThisQuest(questFinish);

                    //If the player has not completed it yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = HasAllQuestCompletionItems(questFinish);

                        //The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            RemoveQuestCompletionItems(questFinish);

                            //Display message
                            RaiseMessage("");
                            RaiseMessage("You completed the " + questFinish.Name + " quest.");

                            //Give quest rewards
                            RaiseMessage("You receive: ");
                            RaiseMessage(questFinish.RewardExperiencePoints.ToString() + " experience points");
                            RaiseMessage(questFinish.RewardGold.ToString() + " gold");

                            if (questFinish.RewardItems.Any())
                            {
                                //Iterate through reward dictionary and add each item to the player's inventory with the appropriate quantity
                                foreach (KeyValuePair<Item, int> reward in questFinish.RewardItems)
                                {
                                    RaiseMessage(reward.Value + " " + (reward.Value > 1 ? reward.Key.NamePlural : reward.Key.Name));
                                    AddItemToInventory(reward.Key, reward.Value);
                                }
                            }

                            AddExperiencePoints(questFinish.RewardExperiencePoints);
                            Gold += questFinish.RewardGold;


                            //Mark the quest as complete
                            MarkQuestCompleted(questFinish);
                        }
                    }
                }
            }

            //Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                RaiseMessage("You see a " + newLocation.MonsterLivingHere.Name);

                //Make a new monster, using the values of the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                //Using overloaded Monster constructor for simplicity instead of book way
                _currentMonster = new Monster(standardMonster, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }
            }
            else
            {
                _currentMonster = null;
            }
        }


        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
            }
        }

        public void MoveEast()
        {
            if (CurrentLocation.LocationToEast != null)
            {
                MoveTo(CurrentLocation.LocationToEast);
            }
        }

        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
            }
        }

        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
            }
        }


        public void UseWeapon(Weapon currentWeapon)
        {
            //Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            //Apply the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            //Display message
            RaiseMessage("You hit the " + _currentMonster.Name + " for " + damageToMonster.ToString() + " points.");

            //Check if the monster is dead
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                //Monster is dead
                RaiseMessage("");
                RaiseMessage("You defeted the " + _currentMonster.Name);

                //Give the player experience points for killing the monster
                AddExperiencePoints(_currentMonster.RewardExperiencePoints);
                RaiseMessage("You receive " + _currentMonster.RewardExperiencePoints.ToString() + " experience points");

                //Give the player gold for killing the monster
                Gold += _currentMonster.RewardGold;
                RaiseMessage("You receive " + _currentMonster.RewardGold.ToString() + " gold");

                //Get random loot items from the monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                //Add items to the lootedItems list, comparing a random number to the drop percent
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }

                //If no items were randomly selected, then add the default loot items(s)
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                        }
                    }
                }

                //Add the looted items to the player's inventory
                foreach (InventoryItem inventoryItem in lootedItems)
                {
                    AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        RaiseMessage("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name);
                    }
                    else
                    {
                        RaiseMessage("You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural);
                    }
                }

                //Add a blank line to the messages box for appearance.
                RaiseMessage("");

                //Move player to current location (to heal player and create a new monster to fight)
                MoveTo(CurrentLocation);
            }
            else
            {
                //Monster is still alive

                //Determine the amount of damage the monster does to the player
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

                //Display message
                RaiseMessage("The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage.");

                //Subtact damage from player
                CurrentHitPoints -= damageToPlayer;

                if (CurrentHitPoints <= 0)
                {
                    //Display message
                    RaiseMessage("The " + _currentMonster.Name + " killed you.");

                    //Move player to "Home"
                    MoveHome();
                }
            }
        }

        public void UsePotion(Potion potion)
        {

            //Add healing amount to the player's current hit points
            CurrentHitPoints += potion.AmountToHeal;

            //CurrentHitPoints cannot exceed player's MaximumHitPoints
            CurrentHitPoints = Math.Clamp(CurrentHitPoints, 0, MaximumHitPoints);

            //Remove the potion from the player's inventory
            RemoveItemFromInventory(potion, 1);

            //Display message
            RaiseMessage("You drink a " + potion.Name);
            if(potion.ID == World.ITEM_ID_RETURN_HOME_POTION)
            {
                MoveHome();
                return;
            }

            //Monster gets their turn to attack

            //Determine the amount of damage the monster does to the player
            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaximumDamage);

            //Display message
            RaiseMessage("The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage.");

            //Subtact damage from player
            CurrentHitPoints -= damageToPlayer;

            if (CurrentHitPoints <= 0)
            {
                //Display message
                RaiseMessage("The " + _currentMonster.Name + " killed you.");

                //Move player to "Home"
                MoveHome();
            }
        }

        private void MoveHome()
        {
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
        }
    }
}
