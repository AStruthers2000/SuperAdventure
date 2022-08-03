using Engine;
using System.ComponentModel;
using System.IO;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private Player _player;

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
            //These are bound by tying the label text value to the value of each variable in the player class
            //The player inherits from living creature, which inherits from INotifyPropertyChanged, so each time the 
            //value of any one of these variables is changed, the label is notified from the inherited INotifyPropertyChanged class
            //and the label knows what to do from there
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
                DataPropertyName = "IsCompletedString",
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

            //Linking player properties with the UI by adding the function SuperAdventure.PlayerOnPropertyChanged to the function stored
            //in the LivingCreature.PropertyChanged varianble
            _player.PropertyChanged += PlayerOnPropertyChanged;

            //Binding player display message event
            _player.OnMessage += DisplayMessage;

            _player.MoveTo(_player.CurrentLocation);
        }

        private void DisplayMessage(object sender, MessageEventArgs messageEventArgs)
        {
            rtbMessages.Text += messageEventArgs.Message + Environment.NewLine;
            if (messageEventArgs.AddExtraNewLine)
            {
                rtbMessages.Text += Environment.NewLine;
            }
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            _player.MoveNorth();
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            _player.MoveSouth();
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            _player.MoveEast();
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            _player.MoveWest();
        }

        
        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            //Get the currently selected weapon from the cboWeapons Combobox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;
            _player.UseWeapon(currentWeapon);
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            //Get the currently selected potion from the combobox
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;
            _player.UsePotion(potion);
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
                case "CurrentLocation":
                    // Show/hide available movement buttons
                    btnNorth.Visible = (_player.CurrentLocation.LocationToNorth != null);
                    btnEast.Visible = (_player.CurrentLocation.LocationToEast != null);
                    btnSouth.Visible = (_player.CurrentLocation.LocationToSouth != null);
                    btnWest.Visible = (_player.CurrentLocation.LocationToWest != null);
                    
                    // Display current location name and description
                    rtbLocation.Text = _player.CurrentLocation.Name + Environment.NewLine;
                    rtbLocation.Text += _player.CurrentLocation.Description + Environment.NewLine;

                    if (_player.CurrentLocation.MonsterLivingHere == null)
                    {
                        cboWeapons.Visible = false;
                        cboPotions.Visible = false;
                        btnUseWeapon.Visible = false;
                        btnUsePotion.Visible = false;
                    }
                    else
                    {
                        cboWeapons.Visible = _player.Weapons.Any();
                        cboPotions.Visible = _player.Potions.Any();
                        btnUseWeapon.Visible = _player.Weapons.Any();
                        btnUsePotion.Visible = _player.Potions.Any();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}