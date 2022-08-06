using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        //Weapons
        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_PARRY_DAGGER = 11;
        public const int ITEM_ID_BOW = 33;
        public const int ITEM_ID_MACE = 34;
        public const int ITEM_ID_LONG_SWORD = 35;
        public const int ITEM_ID_BLACK_FLAME_SWORD = 36;
        public const int ITEM_ID_ELVEN_CURVED_SWORD = 37;
        public const int ITEM_ID_CRAB_CLAW = 26;
        public const int ITEM_ID_ROBBER_DAGGER = 22;

        //Enemy drops
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_SPIDER_EGG = 13;
        public const int ITEM_ID_LIZARD_SCALE = 14;
        public const int ITEM_ID_LIZARD_CLAW = 15;
        public const int ITEM_ID_DARK_ELF_BRAID = 16;
        public const int ITEM_ID_DARK_ELF_DAGGER = 17;
        public const int ITEM_ID_DARK_ELF_GEM = 18;
        public const int ITEM_ID_DARK_ELF_BRANCH = 19;
        public const int ITEM_ID_DARK_ELF_BOW = 20;
        public const int ITEM_ID_DARK_ELF_ARROW = 21;
        public const int ITEM_ID_ROBBER_SATCHEL = 23;
        public const int ITEM_ID_ROBBER_PELT = 24;
        public const int ITEM_ID_CRAB_SHELL = 25;
        public const int ITEM_ID_CRAB_LEG = 27;
        public const int ITEM_ID_SEASHELL = 28;
        public const int ITEM_ID_GOLEM_GEM = 29;
        public const int ITEM_ID_GOLEM_STONE = 30;
        public const int ITEM_ID_GOLEM_MOSS = 31;
        public const int ITEM_ID_GOLEM_CRYSTAL = 32;

        //Potions
        public const int ITEM_ID_MINOR_HEALING_POTION = 7;
        public const int ITEM_ID_HEALING_POTION = 38;
        public const int ITEM_ID_MAJOR_HEALING_POTION = 39;
        public const int ITEM_ID_RETURN_HOME_POTION = 40;

        //Progression items
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        public const int ITEM_ID_ELF_BRANCH = 41;
        public const int ITEM_ID_KING_NOTE = 42;
        public const int ITEM_ID_WITCH_APPROVAL = 43;
        public const int ITEM_ID_LOST_CHILD_COMPANION = 46;
        public const int ITEM_ID_GUARD_PASS = 44;
        public const int ITEM_ID_ALCHEMIST_NOTE = 45;

        //Shop Items
        public const int ITEM_ID_SAPHIRE_NECKLACE = 12;

        //Monsters
        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;
        public const int MONSTER_ID_DARK_ELF = 4;
        public const int MONSTER_ID_LIZARDFOLK = 5;
        public const int MONSTER_ID_WERECRAB = 6;
        public const int MONSTER_ID_GEM_GOLEM = 7;
        public const int MONSTER_ID_ROBBER = 8;

        //Quests
        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;
        public const int QUEST_ID_HELP_GUARD = 3;
        public const int QUEST_ID_VISIT_WITCH = 4;
        public const int QUEST_ID_CLEAR_SPIDER_NEST = 5;
        public const int QUEST_ID_BREW_POTION = 6;
        public const int QUEST_ID_FIND_LOST_CHILD = 7;
        public const int QUEST_ID_SMUGGLE_ELF = 8;
        public const int QUEST_ID_SUPPLY_SHOP = 9;
        public const int QUEST_ID_HELP_WIZARD = 10;

        //Locations
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;
        public const int LOCATION_ID_TOWN_SOUTH = 10;
        public const int LOCATION_ID_TOWN_NORTH = 11;
        public const int LOCATION_ID_TOWN_WEST = 12;
        public const int LOCATION_ID_MARKET = 13;
        public const int LOCATION_ID_SWAMP_BRIDGE = 14;
        public const int LOCATION_ID_SWAMP = 15;
        public const int LOCATION_ID_WITCH_HUT = 16;
        public const int LOCATION_ID_WATCH_TOWER = 17;
        public const int LOCATION_ID_TRADING_ROAD_NORTH = 18;
        public const int LOCATION_ID_TRADING_ROAD_SOUTH = 19;
        public const int LOCATION_ID_TRADING_ROAD = 20;
        public const int LOCATION_ID_SECRET_PATH = 21;
        public const int LOCATION_ID_CAVE = 22;
        public const int LOCATION_ID_WIZARD_TOWER = 23;
        public const int LOCATION_ID_PORT = 24;
        public const int LOCATION_ID_PORT_MARKET = 25;
        public const int LOCATION_ID_DOCKS = 26;
        public const int LOCATION_ID_BEACH = 27;
        public const int LOCATION_ID_ELF_VILLAGE = 28;

        public const int LOCATION_ID_DEEP_FOREST_01 = 101;
        public const int LOCATION_ID_DEEP_FOREST_02 = 102;
        public const int LOCATION_ID_DEEP_FOREST_03 = 103;
        public const int LOCATION_ID_DEEP_FOREST_04 = 104;
        public const int LOCATION_ID_DEEP_FOREST_05 = 105;
        public const int LOCATION_ID_DEEP_FOREST_06 = 106;
        public const int LOCATION_ID_DEEP_FOREST_07 = 107;
        public const int LOCATION_ID_DEEP_FOREST_08 = 108;
        public const int LOCATION_ID_DEEP_FOREST_09 = 109;
        public const int LOCATION_ID_DEEP_FOREST_10 = 110;
        public const int LOCATION_ID_DEEP_FOREST_11 = 111;
        public const int LOCATION_ID_DEEP_FOREST_12 = 112;
        public const int LOCATION_ID_DEEP_FOREST_13 = 113;
        public const int LOCATION_ID_DEEP_FOREST_14 = 114;

        //Useful constants
        public const int UNSELLABLE_ITEM_PRICE = -1;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            //Weapons
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty sword", "Rusty Swords", 0, 5, 5));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10, 8));
            Items.Add(new Weapon(ITEM_ID_PARRY_DAGGER, "Parrying Dagger", "Parrying Daggers", 1, 25, 40));
            Items.Add(new Weapon(ITEM_ID_BOW, "Bow", "Bows", 0, 20, 10));
            Items.Add(new Weapon(ITEM_ID_MACE, "Mace", "Maces", 10, 20, 15));
            Items.Add(new Weapon(ITEM_ID_LONG_SWORD, "Long Sword", "Long Swords", 15, 30, 25));
            Items.Add(new Weapon(ITEM_ID_ROBBER_DAGGER, "Bandit Dagger", "Bandit Daggers", 5, 13, 5));
            Items.Add(new Weapon(ITEM_ID_BLACK_FLAME_SWORD, "Black Flame Sword", "Black Flame Swords", 40, 50, 50));
            Items.Add(new Weapon(ITEM_ID_ELVEN_CURVED_SWORD, "Elven Curved Sword", "Elven Curved Swords", 25, 35, 40));
            Items.Add(new Weapon(ITEM_ID_CRAB_CLAW, "Crab Claw", "Crab Claws", 30, 40, 25));
            Items.Add(new Weapon(ITEM_ID_ROBBER_DAGGER, "Bandit's Dagger", "Bandit's Daggers", 5, 30, 10));
            
            //Loot drops
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails", 1));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of Fur", "Pieces of Fur", 1));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake Fang", "Snake Fangs", 1));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins", 2));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider Fang", "Spider Fangs", 5));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider Silk", "Spider Silks", 15));
            Items.Add(new Item(ITEM_ID_SPIDER_EGG, "Spider Egg", "Spider Eggs", 20));
            Items.Add(new Item(ITEM_ID_LIZARD_SCALE, "Lizard Scale", "Lizard Scales", 10));
            Items.Add(new Item(ITEM_ID_LIZARD_CLAW, "Lizard Claw", "Lizard Claws", 12));
            Items.Add(new Item(ITEM_ID_DARK_ELF_BRAID, "Braid of Dark Elf Hair", "Braids of Dark Elf Hair", 6));
            Items.Add(new Item(ITEM_ID_DARK_ELF_DAGGER, "Dark Elf Dagger", "Dark Elf Daggers", 12));
            Items.Add(new Item(ITEM_ID_DARK_ELF_GEM, "Gem of a Dark Elf", "Dark Elf Gems", 10));
            Items.Add(new Item(ITEM_ID_DARK_ELF_BRANCH, "Bewitching Branch", "Bewitching Branches", 15));
            Items.Add(new Item(ITEM_ID_DARK_ELF_BOW, "Dark Elf Bow", "Dark Elf Bows", 20));
            Items.Add(new Item(ITEM_ID_DARK_ELF_ARROW, "Dark Elf Arrow", "Dark Elf Arrows", 2));
            Items.Add(new Item(ITEM_ID_ROBBER_SATCHEL, "Bandit's Satchel", "Bandit's Satchels", 25));
            Items.Add(new Item(ITEM_ID_ROBBER_PELT, "Bandit's Pelt", "Bandit's Pelts", 13));
            Items.Add(new Item(ITEM_ID_CRAB_SHELL, "Crab Shell", "Crab Shells", 30));
            Items.Add(new Item(ITEM_ID_CRAB_LEG, "Crab Leg", "Crab Legs", 20));
            Items.Add(new Item(ITEM_ID_SEASHELL, "Sea Shell", "Sea Shells", 15));
            Items.Add(new Item(ITEM_ID_GOLEM_GEM, "Gem of a Golem", "Golem Gems", 25));
            Items.Add(new Item(ITEM_ID_GOLEM_STONE, "Stone of a Golem", "Golem Stones", 20));
            Items.Add(new Item(ITEM_ID_GOLEM_MOSS, "Moss of a Golem", "Golem Moss", 17));
            Items.Add(new Item(ITEM_ID_GOLEM_CRYSTAL, "Crystal of a Golem", "Golem Crystals", 50));
            
            //Potions
            Items.Add(new Potion(ITEM_ID_MINOR_HEALING_POTION, "Weak Healing Potion", "Weak Healing Potions", 5, 5));
            Items.Add(new Potion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 15, 10));
            Items.Add(new Potion(ITEM_ID_MAJOR_HEALING_POTION, "Strong Healing Potion", "Strong Healing Potions", 30, 15));
            Items.Add(new Potion(ITEM_ID_RETURN_HOME_POTION, "Return Home Potion", "Return Home Potions", 0, 20, teleportLocation: LocationByID(LOCATION_ID_HOME)));
            
            //Progression Items
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer Pass", "Adventurer passes", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Item(ITEM_ID_ELF_BRANCH, "Sacred Wooden Wreath", "Sacred Wooden Wreaths", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Item(ITEM_ID_KING_NOTE, "King's Note", "King's Notes", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Item(ITEM_ID_WITCH_APPROVAL, "Seal of the Witch's Approval", "Seals of the Witch's Approval", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Item(ITEM_ID_LOST_CHILD_COMPANION, "Guard's Child", "Guard's Children", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Item(ITEM_ID_GUARD_PASS, "Guard's Pass", "Guard's Passes", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Item(ITEM_ID_ALCHEMIST_NOTE, "Potion Recipe", "Potion Recipes", UNSELLABLE_ITEM_PRICE));

            //Shop Items
            Items.Add(new Item(ITEM_ID_SAPHIRE_NECKLACE, "Saphire Necklace", "Saphire Necklaces", 50));
        }

        //TODO: I CAN SCALE THE MONSTER DAMAGE WITH THE LEVEL (and subsequent health) REQUIRED TO ENTER THE AREA
        //THE MONSTER LIVES IN. I CAN THEN SCALE THE MONSTER HEALTH WITH THE EXPECTED WEAPONS THE PLAYER SHOULD HAVE
        //BY THE TIME THEY GET TO THIS AREA, OR EVEN WITH THE EXPECTED WEAPON THEY CAN GET IN THE NEW AREA.
        //CURRENTLY NOTHING IS SCALED. GOLD WILL BE HARDER TO SCALE BECAUSE PLAYERS CAN ALWAYS GRIND
        //I CAN ALSO CHANGE THE PLAYER EXPERIENCE->LEVEL->HEALTH CALCULATIONS TO MAKE THE PLAYER NOT GET OVER POWERED

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 7, 10, 10, 7, 7);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MINOR_HEALING_POTION), 6, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ALCHEMIST_NOTE), 3, false));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 3, 5, 6, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CLUB), 5, false));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 20, 5, 40, 20, 20);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_EGG), 10, false));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PARRY_DAGGER), 1, false));

            Monster robber = new Monster(MONSTER_ID_ROBBER, "Bandit", 40, 25, 30, 25, 25);
            robber.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROBBER_PELT), 65, true));
            robber.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROBBER_SATCHEL), 40, false));
            robber.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ROBBER_DAGGER), 10, false));

            Monster darkElf = new Monster(MONSTER_ID_DARK_ELF, "Dark Elf", 35, 10, 20, 30, 30);
            darkElf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_ELF_BRAID), 15, true));
            darkElf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_ELF_ARROW), 80, true));
            darkElf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_ELF_BRANCH), 20, false));
            darkElf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_ELF_DAGGER), 5, false));
            darkElf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_ELF_GEM), 10, false));
            darkElf.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DARK_ELF_BOW), 7, false));

            Monster lizardfolk = new Monster(MONSTER_ID_LIZARDFOLK, "Lizardfolk", 25, 20, 14, 25, 25);
            lizardfolk.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LIZARD_SCALE), 65, true));
            lizardfolk.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 80, true));
            lizardfolk.LootTable.Add(new LootItem(ItemByID(ITEM_ID_LIZARD_CLAW), 35, false));
            lizardfolk.LootTable.Add(new LootItem(ItemByID(ITEM_ID_MACE), 5, false));

            Monster werecrab = new Monster(MONSTER_ID_WERECRAB, "Werecrab", 40, 34, 72, 50, 50);
            werecrab.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SEASHELL), 80, true));
            werecrab.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CRAB_LEG), 20, false));
            werecrab.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CRAB_SHELL), 5, false));
            werecrab.LootTable.Add(new LootItem(ItemByID(ITEM_ID_CRAB_CLAW), 2, false));

            Monster golem = new Monster(MONSTER_ID_GEM_GOLEM, "Crystal Elemental", 100, 50, 50, 150, 150);
            golem.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLEM_STONE), 60, true));
            golem.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLEM_MOSS), 50, true));
            golem.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLEM_GEM), 35, false));
            golem.LootTable.Add(new LootItem(ItemByID(ITEM_ID_GOLEM_CRYSTAL), 6, false));


            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
            Monsters.Add(robber);
            Monsters.Add(darkElf);
            Monsters.Add(lizardfolk);
            Monsters.Add(werecrab);
            Monsters.Add(golem);
        }


        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden = new Quest(QUEST_ID_CLEAR_ALCHEMIST_GARDEN, "Clear the Alchemist's Garden", "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive healing potions and 10 gold pieces.", 20, 10);
            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));
            clearAlchemistGarden.RewardItems.Add(ItemByID(ITEM_ID_HEALING_POTION), 4);

            Quest clearFarmersField = new Quest(QUEST_ID_CLEAR_FARMERS_FIELD, "Clear the Farmer's Field", "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass and 20 gold pieces.", 20, 20);
            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));
            clearFarmersField.RewardItems.Add(ItemByID(ITEM_ID_ADVENTURER_PASS), 1);

            Quest helpGuard = new Quest(QUEST_ID_HELP_GUARD, "Help the Southern Guard", "The guard wants a new necklace for their partner. Return back with a Saphire Necklace from the market", 150, 0);
            helpGuard.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SAPHIRE_NECKLACE), 1));

            Quest getNote = new Quest(QUEST_ID_VISIT_WITCH, "Visit the Witch", "The alchemist dropped a very important potion recipe and one of the rats picked it up. Get the recipe and bring it to the witch in the heart of the swamp.", 150, 200);
            getNote.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_ALCHEMIST_NOTE), 1));
            getNote.RewardItems.Add(ItemByID(ITEM_ID_MAJOR_HEALING_POTION), 2);

            Quest killSpiders = new Quest(QUEST_ID_CLEAR_SPIDER_NEST, "Exterminate Spiders", "The guard in the guard post has kindly requested we kill some spiders in the forest. He claims he just needs them gone, but the terror in his voice implied something else. They are quite strong, so he recommends being a high level and possibly obtaining some potions first. In return, he will give you a note from the king singing your praises. Meet him in the town square after you are done exterminating.", 50, 200);
            killSpiders.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SPIDER_FANG), 8));
            killSpiders.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SPIDER_SILK), 3));
            killSpiders.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SPIDER_EGG), 1));
            killSpiders.RewardItems.Add(ItemByID(ITEM_ID_BOW), 1);
            killSpiders.RewardItems.Add(ItemByID(ITEM_ID_KING_NOTE), 1);

            Quest helpWitch = new Quest(QUEST_ID_BREW_POTION, "Double, Double Toil and Trouble", "Help the witch brew a potion with ingrediants from the local wildlife.", 100, 50);
            helpWitch.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_LIZARD_SCALE), 3));
            helpWitch.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_LIZARD_CLAW), 2));
            helpWitch.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 5));
            helpWitch.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 5));
            helpWitch.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SPIDER_EGG), 2));
            helpWitch.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 10));
            helpWitch.RewardItems.Add(ItemByID(ITEM_ID_RETURN_HOME_POTION), 4);
            helpWitch.RewardItems.Add(ItemByID(ITEM_ID_WITCH_APPROVAL), 1);

            Quest findChild = new Quest(QUEST_ID_FIND_LOST_CHILD, "Lost Girl", "The guard of the watch tower needs us to help find his daughter who wandered off into the dark forest alone. He will be eternally grateful.", 45, 375);
            findChild.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_LOST_CHILD_COMPANION), 1));
            findChild.RewardItems.Add(ItemByID(ITEM_ID_GUARD_PASS), 1);
            findChild.RewardItems.Add(ItemByID(ITEM_ID_LONG_SWORD), 1);

            Quest smuggleElf = new Quest(QUEST_ID_SMUGGLE_ELF, "Bring the Elf Back Home", "You encounter a scared elf alone in the dark forest. He requests your help getting him back to his village. The dark elves in these woods are very aggressive towards anyone that isn't one of their own. He gives you a wreath crafted out of elven wood that will serve as a key to get past the elven guards.", 68, 32);
            smuggleElf.StartItems.Add(ItemByID(ITEM_ID_ELF_BRANCH), 1);
            smuggleElf.RewardItems.Add(ItemByID(ITEM_ID_ELVEN_CURVED_SWORD), 1);
            smuggleElf.RewardItems.Add(ItemByID(ITEM_ID_MAJOR_HEALING_POTION), 5);
            smuggleElf.RewardItems.Add(ItemByID(ITEM_ID_RETURN_HOME_POTION), 7);

            Quest openShop = new Quest(QUEST_ID_SUPPLY_SHOP, "Resupply the Shop", "The shopkeeper needs help resupplying some of her inventory before she's willing to sell anything to you. A lot of her items are sourced locally, so checking out the beach might be a good place to start helping.", 75, 90);
            openShop.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SEASHELL), 20));
            openShop.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CRAB_CLAW), 1));
            openShop.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CRAB_LEG), 6));
            openShop.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CRAB_SHELL), 2));

            Quest wizardRequest = new Quest(QUEST_ID_HELP_WIZARD, "Craft the Ultimate Weapon", "Deep within the mountains, The Wizard of Ash and Fire is working on building the ultimate weapon. They need your help gathering each item they need, because if anyone were to spot them there is no telling what might happen...", 100, 500);
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 50));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 50));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SPIDER_EGG), 7));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_ROBBER_PELT), 27));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_DARK_ELF_GEM), 7));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_LIZARD_CLAW), 23));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_CRAB_SHELL), 4));
            wizardRequest.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_GOLEM_CRYSTAL), 4));
            wizardRequest.StartItems.Add(ItemByID(ITEM_ID_MAJOR_HEALING_POTION), 10);
            wizardRequest.RewardItems.Add(ItemByID(ITEM_ID_BLACK_FLAME_SWORD), 1);


            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
            Quests.Add(helpGuard);
            Quests.Add(getNote);
            Quests.Add(killSpiders);
            Quests.Add(helpWitch);
            Quests.Add(findChild);
            Quests.Add(smuggleElf);
            Quests.Add(openShop);
            Quests.Add(wizardRequest);
        }


        private static void PopulateLocations()
        {
            //Create each location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house. You really need to clean up the place.");
            Location townSouth = new Location(LOCATION_ID_TOWN_SOUTH, "Southern Town Entrance", "A small guard post and gate seperates the town and the farmland.");
            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.");
            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's Field", "You see rows of vegetables growing here. Some cows are outside getting their graze on.");
            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town Square", "You see a fountain.");
            Location townNorth = new Location(LOCATION_ID_TOWN_NORTH, "Northern Town Entrance", "A cobblestone road leads into the northern hills.");
            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's Hut", "There are many strange plants on the shelves.", levelRequiredToEnter: 3);
            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's Garden", "Many plants are growing here.");
            Location market = new Location(LOCATION_ID_MARKET, "Castle Market", "A bustling market full of vendors and people.");
            Location townWest = new Location(LOCATION_ID_TOWN_WEST, "Western Town Entrance", "A defensive wall protecting the citizens of the town. A watch tower can be seen on the other side of the gate.", levelRequiredToEnter: 5);
            Location watchTower = new Location(LOCATION_ID_WATCH_TOWER, "Forest Watch Tower", "A lone tower where an attentive watcher keeps an eye on the dark forest to the south.");
            Location swampBridge = new Location(LOCATION_ID_SWAMP_BRIDGE, "Swamp Approach", "A series of bridges and barely worn paths lead deep into the heart of the swamp.");
            Location swamp = new Location(LOCATION_ID_SWAMP, "Boggy Swamp", "The deep fog and opaque water are complemented by the dense vegetation. You can feel eyes watching your every move.");
            Location witchHut = new Location(LOCATION_ID_WITCH_HUT, "Witch's Hut", "Through the dense swamp you see a sole hut, rumored to belong to the cursed witch.", itemRequiredToEnter: ItemByID(ITEM_ID_ALCHEMIST_NOTE));
            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard Post", "There is a large, tough-looking guard here.", itemRequiredToEnter: ItemByID(ITEM_ID_ADVENTURER_PASS));
            Location forestBridge = new Location(LOCATION_ID_BRIDGE, "Forest Bridge", "A stone bridge crosses a wide river.");
            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering the trees in this forest.");
            Location tradingRoadNorth = new Location(LOCATION_ID_TRADING_ROAD_NORTH, "Northern Trading Route", "The northern end of the trade route between the port and the capital.", levelRequiredToEnter: 10);
            Location tradingRoad = new Location(LOCATION_ID_TRADING_ROAD, "Trading Route", "A long, well walked path through trees and foothills. Beautiful scenary complements the usefulness of this trading route.");
            Location tradingRoadSouth = new Location(LOCATION_ID_TOWN_SOUTH, "Southern Trading Route", "The southern end of the trade route between the port and the capital. The smell of saltwater is rich here.");
            Location portTown = new Location(LOCATION_ID_PORT, "Oceanside Port", "The bustling port city that is always full of commotion.", itemRequiredToEnter: ItemByID(ITEM_ID_KING_NOTE));
            Location portMarket = new Location(LOCATION_ID_PORT_MARKET, "Dockside Shop", "A shop that will provide you with all the necessities.");
            Location docks = new Location(LOCATION_ID_DOCKS, "Oceanside Docks", "The central hub of Oceanside. Boats of all shapes and sizes bring in cargo from around the world");
            Location beach = new Location(LOCATION_ID_BEACH, "Sandy Shores", "The ocean breaks into shifting sands. These pristine beaches are home to many crustaceans.");
            Location secretRoad = new Location(LOCATION_ID_SECRET_PATH, "Hidden Tunnel", "Shhhh... No one is supposed to know this is here. A tunnel through the bushes leads deep into the mountain.", levelRequiredToEnter: 20);
            Location cave = new Location(LOCATION_ID_CAVE, "Crystal Caves", "Crystals illuminate the caverns, keeping even the deepest corners of this cave system light as day.");
            Location wizardTower = new Location(LOCATION_ID_WIZARD_TOWER, "Wizard's Alcove", "Outside of the cave, nestled in many peaks and valleys, a spiraling tower houses the wizard.", itemRequiredToEnter: ItemByID(ITEM_ID_WITCH_APPROVAL));
            Location elfVillage = new Location(LOCATION_ID_ELF_VILLAGE, "Dreamrose Village", "An elven village nestled deep in the forest. A magical barrier keeps the dark elfs at bay, while tree elves live peacefully hidden away from the rest of the world.", itemRequiredToEnter: ItemByID(ITEM_ID_ELF_BRANCH));

            Location darkForest01 = new Location(LOCATION_ID_DEEP_FOREST_01, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 8);
            Location darkForest02 = new Location(LOCATION_ID_DEEP_FOREST_02, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.");
            Location darkForest03 = new Location(LOCATION_ID_DEEP_FOREST_03, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.");
            Location darkForest04 = new Location(LOCATION_ID_DEEP_FOREST_04, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 10);
            Location darkForest05 = new Location(LOCATION_ID_DEEP_FOREST_05, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.");
            Location darkForest06 = new Location(LOCATION_ID_DEEP_FOREST_06, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 12);
            Location darkForest07 = new Location(LOCATION_ID_DEEP_FOREST_07, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.");
            Location darkForest08 = new Location(LOCATION_ID_DEEP_FOREST_08, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.");
            Location darkForest09 = new Location(LOCATION_ID_DEEP_FOREST_09, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 15);
            Location darkForest10 = new Location(LOCATION_ID_DEEP_FOREST_10, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.");
            Location darkForest11 = new Location(LOCATION_ID_DEEP_FOREST_11, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 17);
            Location darkForest12 = new Location(LOCATION_ID_DEEP_FOREST_12, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 12);
            Location darkForest13 = new Location(LOCATION_ID_DEEP_FOREST_13, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", itemRequiredToEnter: ItemByID(ITEM_ID_GUARD_PASS));
            Location darkForest14 = new Location(LOCATION_ID_DEEP_FOREST_14, "Darkpond Woodland", "Dense, twisting trees and thick ground cover make navigation almost impossible. Shadows can be seen moving around on the edges of vision. Be careful not to get lost.", levelRequiredToEnter: 15);


            //Quests
            QuestByID(QUEST_ID_HELP_GUARD).StartLocation = townSouth;
            QuestByID(QUEST_ID_HELP_GUARD).EndLocation = townSouth;
            
            QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD).StartLocation = farmhouse;
            QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD).EndLocation = farmhouse;

            QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN).StartLocation = alchemistHut;
            QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN).EndLocation = alchemistHut;

            QuestByID(QUEST_ID_VISIT_WITCH).StartLocation = alchemistHut;
            QuestByID(QUEST_ID_VISIT_WITCH).EndLocation = witchHut;

            QuestByID(QUEST_ID_CLEAR_SPIDER_NEST).StartLocation = guardPost;
            QuestByID(QUEST_ID_CLEAR_SPIDER_NEST).EndLocation = townSquare;

            QuestByID(QUEST_ID_BREW_POTION).StartLocation = witchHut;
            QuestByID(QUEST_ID_BREW_POTION).EndLocation = witchHut;

            QuestByID(QUEST_ID_FIND_LOST_CHILD).StartLocation = watchTower;
            QuestByID(QUEST_ID_FIND_LOST_CHILD).EndLocation = watchTower;

            QuestByID(QUEST_ID_SMUGGLE_ELF).StartLocation = darkForest03;
            QuestByID(QUEST_ID_SMUGGLE_ELF).EndLocation = elfVillage;

            QuestByID(QUEST_ID_SUPPLY_SHOP).StartLocation = portMarket;
            QuestByID(QUEST_ID_SUPPLY_SHOP).EndLocation = portMarket;

            QuestByID(QUEST_ID_HELP_WIZARD).StartLocation = wizardTower;
            QuestByID(QUEST_ID_HELP_WIZARD).EndLocation = wizardTower;



            //Monsters
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);
            swamp.MonsterLivingHere =MonsterByID(MONSTER_ID_LIZARDFOLK);
            tradingRoad.MonsterLivingHere = MonsterByID(MONSTER_ID_ROBBER);
            beach.MonsterLivingHere = MonsterByID(MONSTER_ID_WERECRAB);
            cave.MonsterLivingHere = MonsterByID(MONSTER_ID_GEM_GOLEM);

            darkForest01.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest02.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            //darkForest03.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest04.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest05.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest06.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest07.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest08.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest09.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest10.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest11.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest12.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest13.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);
            darkForest14.MonsterLivingHere = MonsterByID(MONSTER_ID_DARK_ELF);

            darkForest10.ItemsPickUpHere.Add(ItemByID(ITEM_ID_LOST_CHILD_COMPANION), 1);


            //Linking the locations together
            home.LocationToNorth = townSouth;

            townSouth.LocationToNorth = townSquare;
            townSouth.LocationToEast = tradingRoadNorth;
            townSouth.LocationToSouth = home;
            townSouth.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSouth;
            farmhouse.LocationToSouth = farmersField;

            farmersField.LocationToNorth = farmhouse;

            townSquare.LocationToNorth = townNorth;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToSouth = townSouth;
            townSquare.LocationToWest = market;

            market.LocationToEast = townSquare;
            market.LocationToWest = townWest;

            townWest.LocationToNorth = swampBridge;
            townWest.LocationToEast = market;
            townWest.LocationToWest = watchTower;

            swampBridge.LocationToNorth = swamp;
            swampBridge.LocationToSouth = townWest;

            swamp.LocationToEast = witchHut;
            swamp.LocationToSouth = swampBridge;

            witchHut.LocationToWest = swamp;

            watchTower.LocationToEast = townWest;
            watchTower.LocationToSouth = darkForest13;

            townNorth.LocationToNorth = alchemistHut;
            townNorth.LocationToSouth = townSquare;

            alchemistHut.LocationToNorth = alchemistsGarden;
            alchemistHut.LocationToSouth = townNorth;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = forestBridge;
            guardPost.LocationToWest = townSquare;

            forestBridge.LocationToEast = spiderField;
            forestBridge.LocationToWest = guardPost;

            spiderField.LocationToSouth = darkForest01;
            spiderField.LocationToWest = forestBridge;

            tradingRoadNorth.LocationToSouth = tradingRoad;
            tradingRoadNorth.LocationToWest = townSouth;

            tradingRoad.LocationToNorth = tradingRoadNorth;
            tradingRoad.LocationToSouth = tradingRoadSouth;

            tradingRoadSouth.LocationToNorth = tradingRoad;
            tradingRoadSouth.LocationToEast = portTown;
            tradingRoadSouth.LocationToWest = secretRoad;

            secretRoad.LocationToEast = tradingRoadSouth;
            secretRoad.LocationToWest = cave;

            cave.LocationToNorth = wizardTower;
            cave.LocationToEast = secretRoad;

            wizardTower.LocationToSouth = cave;

            portTown.LocationToNorth = darkForest12;
            portTown.LocationToEast = docks;
            portTown.LocationToSouth = portMarket;
            portTown.LocationToWest = tradingRoadSouth;

            portMarket.LocationToNorth = portTown;

            docks.LocationToSouth = beach;
            docks.LocationToWest = portTown;

            beach.LocationToNorth = docks;

            darkForest01.LocationToNorth = spiderField;
            darkForest01.LocationToEast = darkForest02;
            darkForest01.LocationToSouth = darkForest03;
            darkForest01.LocationToWest = darkForest04;

            darkForest02.LocationToEast = darkForest13;
            darkForest02.LocationToSouth = darkForest14;
            darkForest02.LocationToWest = darkForest01;

            darkForest03.LocationToNorth = darkForest01;

            darkForest04.LocationToEast = darkForest01;
            darkForest04.LocationToSouth = darkForest05;

            darkForest05.LocationToNorth = darkForest04;
            darkForest05.LocationToSouth = darkForest06;

            darkForest06.LocationToNorth = darkForest05;
            darkForest06.LocationToEast = darkForest07;

            darkForest07.LocationToEast = darkForest08;
            darkForest07.LocationToSouth = darkForest11;
            darkForest07.LocationToWest = darkForest06;

            darkForest08.LocationToEast = darkForest09;
            darkForest08.LocationToWest = darkForest07;

            darkForest09.LocationToNorth = darkForest10;
            darkForest09.LocationToWest = darkForest08;

            darkForest10.LocationToEast = darkForest14;
            darkForest10.LocationToSouth = darkForest09;

            darkForest11.LocationToNorth = darkForest07;
            darkForest11.LocationToWest = darkForest12;

            darkForest12.LocationToEast = darkForest11;
            darkForest12.LocationToSouth = portTown;

            darkForest13.LocationToNorth = watchTower;
            darkForest13.LocationToWest = darkForest02;

            darkForest14.LocationToNorth = darkForest02;
            darkForest14.LocationToSouth = elfVillage;
            darkForest14.LocationToWest = darkForest10;

            elfVillage.LocationToNorth = darkForest14;


            // Add locations to list
            Locations.Add(home);
            Locations.Add(townSouth);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(townSquare);
            Locations.Add(market);
            Locations.Add(townWest);
            Locations.Add(watchTower);
            Locations.Add(swampBridge);
            Locations.Add(swamp);
            Locations.Add(witchHut);
            Locations.Add(townNorth);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(guardPost);
            Locations.Add(forestBridge);
            Locations.Add(spiderField);
            Locations.Add(tradingRoadNorth);
            Locations.Add(tradingRoad);
            Locations.Add(tradingRoadSouth);
            Locations.Add(secretRoad);
            Locations.Add(cave);
            Locations.Add(wizardTower);
            Locations.Add(portTown);
            Locations.Add(portMarket);
            Locations.Add(docks);
            Locations.Add(beach);
            Locations.Add(elfVillage);

            Locations.Add(darkForest01);
            Locations.Add(darkForest02);
            Locations.Add(darkForest03);
            Locations.Add(darkForest04);
            Locations.Add(darkForest05);
            Locations.Add(darkForest06);
            Locations.Add(darkForest07);
            Locations.Add(darkForest08);
            Locations.Add(darkForest09);
            Locations.Add(darkForest10);
            Locations.Add(darkForest11);
            Locations.Add(darkForest12);
            Locations.Add(darkForest13);
            Locations.Add(darkForest14);
        }


        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }


        public static Quest QuestByID(int id)
        {
            foreach(Quest quest in Quests)
            {
                if(quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }


        public static Location LocationByID(int id)
        {
            foreach(Location location in Locations)
            {
                if(location.ID == id)
                {
                    return location;
                }
            }
            return null;
        }
    }
}
