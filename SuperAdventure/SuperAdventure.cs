using Engine;
using System.ComponentModel;
using System.IO;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _monster;

        private string PLAYER_DATA_FILE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SuperAdventure\\Save\\";
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";

        public SuperAdventure()
        {
            InitializeComponent();

            if (File.Exists(PLAYER_DATA_FILE_PATH + PLAYER_DATA_FILE_NAME))
            {
                _player = Player.CreatePlayerFromXmlString(File.ReadAllText(PLAYER_DATA_FILE_PATH + PLAYER_DATA_FILE_NAME));
            }
            else
            {
                _player = Player.CreateDefaultPlayer();
            }

            //Binding player stat labels
            lblHitPoints.DataBindings.Add("Text", _player, "CurrentHitPoints");
            lblGold.DataBindings.Add("Text", _player, "Gold");
            lblExperience.DataBindings.Add("Text", _player, "ExperiencePoints");
            lblLevel.DataBindings.Add("Text", _player, "Level");

            //Binding player inventory menu
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.DataSource = _player.Inventory;

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Description"
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });

            //Binding player quest menu
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.AutoGenerateColumns = false;
            dgvQuests.DataSource = _player.Quests;

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Name"
            });

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Done?",
                DataPropertyName = "IsCompleted",
            });

            //Binding player weapons combo box
            cboWeapons.SelectedIndexChanged -= cboWeapons_SelectedIndexChanged;
            cboWeapons.DataSource = _player.Weapons;
            cboWeapons.DisplayMember = "Name";
            cboWeapons.ValueMember = "ID";

            if (_player.CurrentWeapon != null)
            {
                cboWeapons.SelectedItem = _player.CurrentWeapon;
            }

            cboWeapons.SelectedIndexChanged += cboWeapons_SelectedIndexChanged;

            //Binding player potions combo box
            cboPotions.DataSource = _player.Potions;
            cboPotions.DisplayMember = "Name";
            cboPotions.ValueMember = "ID";

            _player.PropertyChanged += PlayerOnPropertyChanged;


            MoveTo(_player.CurrentLocation);
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items?
            if (!_player.HasRequiredItemToEnterLocation(newLocation))
            {
                rtbLocation.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                return;
            }

            //Update the player's current location
            _player.CurrentLocation = newLocation;

            //Show/hide available movement buttons
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            //Display name and description of new location
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            //Full heal the player
            _player.CurrentHitPoints = _player.MaximumHitPoints;

            //Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                //See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                //See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    //If the player has not completed it yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        //The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            //Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You completed the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;

                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            //Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            ScrollToBottomOfMessages();

                            _player.AddExperiencePoints(newLocation.QuestAvailableHere.RewardExperiencePoints);
                            _player.Gold += newLocation.QuestAvailableHere.RewardGold;

                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            //Mark the quest as complete
                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);
                        }
                    }
                }
                else
                {
                    //The player does not already have the quest

                    //Display the messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    ScrollToBottomOfMessages();

                    //Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            //Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                //Make a new monster, using the values of the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                //Using overloaded Monster constructor for simplicity instead of book way
                _monster = new Monster(standardMonster, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _monster.LootTable.Add(lootItem);
                }
                cboWeapons.Visible = _player.Weapons.Any();
                cboPotions.Visible = _player.Potions.Any();
                btnUseWeapon.Visible = _player.Weapons.Any();
                btnUsePotion.Visible = _player.Potions.Any();
            }
            else
            {
                _monster = null;
                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            //Get the currently selected weapon from the cboWeapons Combobox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            //Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinimumDamage, currentWeapon.MaximumDamage);

            //Apply the damage to the monster's CurrentHitPoints
            _monster.CurrentHitPoints -= damageToMonster;

            //Display message
            rtbMessages.Text += "You hit the " + _monster.Name + " for " + damageToMonster.ToString() + " points." + Environment.NewLine;

            //Check if the monster is dead
            if (_monster.CurrentHitPoints <= 0)
            {
                //Monster is dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + _monster.Name + Environment.NewLine;

                //Give the player experience points for killing the monster
                _player.AddExperiencePoints(_monster.RewardExperiencePoints);
                rtbMessages.Text += "You receive " + _monster.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;

                //Give the player gold for killing the monster
                _player.Gold += _monster.RewardGold;
                rtbMessages.Text += "You receive " + _monster.RewardGold.ToString() + " gold" + Environment.NewLine;

                //Get random loot items from the monster
                List<InventoryItem> lootedItems = new List<InventoryItem>();

                //Add items to the lootedItems list, comparing a random number to the drop percent
                foreach (LootItem lootItem in _monster.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }

                //If no items were randomly selected, then add the default loot items(s)
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _monster.LootTable)
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
                    _player.AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    }
                }

                //Add a blank line to the messages box for appearance.
                rtbMessages.Text += Environment.NewLine;

                //Move player to current location (to heal player and create a new monster to fight)
                MoveTo(_player.CurrentLocation);
            }
            else
            {
                //Monster is still alive

                //Determine the amount of damage the monster does to the player
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _monster.MaximumDamage);

                //Display message
                rtbMessages.Text += "The " + _monster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                //Subtact damage from player
                _player.CurrentHitPoints -= damageToPlayer;

                if (_player.CurrentHitPoints <= 0)
                {
                    //Display message
                    rtbMessages.Text += "The " + _monster.Name + " killed you." + Environment.NewLine;

                    //Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }

            ScrollToBottomOfMessages();
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            //Get the currently selected potion from the combobox
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;

            //Add healing amount to the player's current hit points
            _player.CurrentHitPoints += potion.AmountToHeal;

            //CurrentHitPoints cannot exceed player's MaximumHitPoints
            _player.CurrentHitPoints = Math.Clamp(_player.CurrentHitPoints, 0, _player.MaximumHitPoints);

            //Remove the potion from the player's inventory
            _player.RemoveItemFromInventory(potion, 1);

            //Display message
            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;

            //Monster gets their turn to attack

            //Determine the amount of damage the monster does to the player
            int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _monster.MaximumDamage);

            //Display message
            rtbMessages.Text += "The " + _monster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

            //Subtact damage from player
            _player.CurrentHitPoints -= damageToPlayer;

            if (_player.CurrentHitPoints <= 0)
            {
                //Display message
                rtbMessages.Text += "The " + _monster.Name + " killed you." + Environment.NewLine;

                //Move player to "Home"
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }

            ScrollToBottomOfMessages();
        }

        private void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void SuperAdventure_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.WriteAllText(PLAYER_DATA_FILE_PATH + PLAYER_DATA_FILE_NAME, _player.ToXMLString());
            }
            catch
            {
                Directory.CreateDirectory(PLAYER_DATA_FILE_PATH);
                File.WriteAllText(PLAYER_DATA_FILE_PATH + PLAYER_DATA_FILE_NAME, _player.ToXMLString());
            }
        }

        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            _player.CurrentWeapon = (Weapon)cboWeapons.SelectedItem;
        }

        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "Weapons":
                    cboWeapons.DataSource = _player.Weapons;

                    if (!_player.Weapons.Any())
                    {
                        cboWeapons.Visible = false;
                        btnUseWeapon.Visible = false;
                    }
                    break;
                case "Potions":
                    cboPotions.DataSource = _player.Potions;

                    if (!_player.Potions.Any())
                    {
                        cboPotions.Visible = false;
                        btnUsePotion.Visible = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}