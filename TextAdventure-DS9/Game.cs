using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    /// <summary>
    /// Main Game Loop
    /// </summary>
    class Game
    {
        private Player player;
        public bool isRunning { get; private set; }

        /// <summary>
        /// Game Constructor
        /// </summary>
        public Game()
        {
            // Setup the Console window
            Extentions.ConsoleStartScreen();
            // Print info
            // Initialize player
            player = new Player(new string[] { "Command", "Operations", "Science" }, 0);

            // Load Game 
            Start();
        }

        /// <summary>
        /// List of all Locations.
        /// </summary>
        public static List<Location> locations = new List<Location>();

        private int locationIndex = 0;

        /// <summary>
        /// Setting up the things needed for the Game
        /// </summary>
        /// <param name="locationIndex"></param>
        public void Start()
        {
            isRunning = true;

            #region Location: Turbolift 
            Location turbolift = new Location
                ("Turbolift",
                new string[]
                {
                    "An empty turbolift.",
                    "You hear a voice. 'Please state your destination'."
                },
                locationIndex,
                new List<Item> 
                { 
                    new Item("Rock", "It's a rock.", true, "You have used the rock"), new Item("Stick", "It's a stick.", true), new Item("Postcard", "It's a random postcard.", false) 
                });

            locations.Add(turbolift);
            #endregion

            #region Location: Player Quarters
            Location playerQuarters = new Location
                ("Quarters", 
                new string[] 
                {
                    "You are in your quarters.", 
                    "You look around. It's pretty empty.", 
                    "Besides a table and your bed there is not much furniture." 
                },
                locationIndex += 1,
                new List<Item> 
                { 
                    new Item("Pillow", "There are a few gray, triangular pillows on the bed.", true) 
                });

            locations.Add(playerQuarters);
            #endregion

            #region Location: Promenade
            Location promenade = new Location
                ("Promenade", 
                new string[] 
                { "You step onto the promenade.", 
                    "Looking around you you can see quite a few shops and restaurants.", 
                    "It's quite busy here, considering there is a war going on."
                },
                locationIndex += 1,
                new List<Item>
                {
                    new Item("Stone", "There is a shiny stone on the floor.", true)
                });

            locations.Add(promenade);
            #endregion

            #region Location: Quarks Bar
            Location quarks = new Location
                ("Quarks", 
                new string[] 
                { "You walk into quarks restaurant.", 
                    "It's buzzing with people." 
                },
                locationIndex += 1, 
                new List<Item> 
                { 
                    new Item("Latinum", "Something on the floor catches your eye. It's a bar of latinum.", true), 
                    new Item("Dabo Table", "There are some dabo tables.", false),
                    new Item("Bar", "A ferengin is tending the bar.", false)
                });

            locations.Add(quarks);
            #endregion

            #region Location: Klingon Restaurant
            Location klingonRestaurant = new Location
                ("Klingon Restaurant",
                new string[] 
                { 
                    "It's a klingon restaurant.." 
                },
                locationIndex += 1, 
                new List<Item> 
                { 
                    new Item("Gagh", "A klingon delecacy.", true)
                });
            locations.Add(klingonRestaurant);
            #endregion

            #region Location: Garracks Tailor shop
            Location garaksShop = new Location
                ("Tailorshop",
                new string[]
                {
                    "Garaks Tailor shop."
                },
                locationIndex += 1,
                new List<Item>
                {
                    new Item("Fabric", "There are some fabric rolls leaning against the wall.", false)
                }
                );
            locations.Add(garaksShop);
            #endregion

            #region Docking Ring
            Location dockingRing = new Location
                ("Dockingring",
                new string[]
                {
                    "Ships can dock here."
                },
                locationIndex += 1,
                new List<Item>
                {
                    new Item("Dust", "A few specks of dust are floating around.", false)
                }
                );
            locations.Add(dockingRing);
            #endregion

            #region Operations
            Location ops = new Location
                ("Ops",
                new string[]
                {
                    "It's quite busy"
                },
                locationIndex += 1,
                new List<Item>
                {
                    // Add items here
                }
                );
            locations.Add(ops);
            #endregion

            #region Infirmary
            Location infirmary = new Location
                ("Infirmary",
                new string[]
                {
                "The stations infirmary. Doctor Julien Bashier works here."
                },
                locationIndex += 1,
                new List<Item>
                {
                    new Item("Hypospray", "A medical device to inject liquids into the body. There is no vile attatched to it.", true)
                });
            locations.Add(infirmary);
            #endregion

            #region Brig
            Location brig = new Location
                ("Brig",
                new string[]
                {
                    "The Brig. It's where people are heald if they break the rules"
                },
                locationIndex += 1,
                new List<Item>
                {
                    new Item("Holding cell", "A few holding cell with two beds in it.", false)
                }
                );
            locations.Add(brig);
            #endregion

            #region Add exits
            // Turbolift 
            turbolift.AddExit(new Exit(playerQuarters));
            turbolift.AddExit(new Exit(promenade));
            turbolift.AddExit(new Exit(dockingRing));
            turbolift.AddExit(new Exit(ops));

            // Player Quarters
            playerQuarters.AddExit(new Exit(turbolift));

            // Promenade
            promenade.AddExit(new Exit(turbolift));
            promenade.AddExit(new Exit(quarks));
            promenade.AddExit(new Exit(klingonRestaurant));
            promenade.AddExit(new Exit(garaksShop));
            promenade.AddExit(new Exit(infirmary));
            promenade.AddExit(new Exit(brig));

            // Klingon Restaurant
            klingonRestaurant.AddExit(new Exit(promenade));

            // Quarks Bar
            quarks.AddExit(new Exit(promenade));
            // TODO:// Holosuites

            // Garaks Tailor shop
            garaksShop.AddExit(new Exit(promenade));

            // Dockingring
            dockingRing.AddExit(new Exit(turbolift));

            // Ops
            ops.AddExit(new Exit(turbolift));

            // Infirmary
            infirmary.AddExit(new Exit(promenade));

            // Brig
            brig.AddExit(new Exit(promenade));

            #endregion

            Console.Clear();
            Extentions.UI(player.Name, player.Department, player.Strenght, player.Health, player.MaxHealth);

            string[] intro = new string[] { "You just graduated from Starfleet academy when the war with the Dominion began.",
                                            "Your first assignment is at Deep Space 9, a critical tatical point to keep the Dominion at bay. ",
                                            "After arriving you are shown your quarters.",
                                            "After setteling in and taking a short rest you decide to have a look around the station.",
                                            "You step into the turbolift. The computer awaits your destination."};

            for (int i = 0; i < intro.Length; i++)
            {
                Console.WriteLine(intro[i]);
            }
            locations[player.currentLocation].ShowLocation();
            Console.WriteLine(player.GetInventory());
        }

        /// <summary>
        /// Called when a new game loop starts.
        /// </summary>
        public void Update()
        {
            if (player.Health <= 0)
            {
                isRunning = false;
                return;
            }
            string input = Extentions.PromtForInput("");


            // Player adds item to their inventory and removes the item from the location.
            player.TakeItem(locations[player.currentLocation], input, new string[] { "take", "pick up", "pickup" }, "Please specify what you would like to take.");

            // Player removes item from their inventory and adds the item to the location.
            player.DropItem(locations[player.currentLocation], input, new string[] { "drop" }, "Please specify what you would like to drop.");

            // Player removes item from their inventory. 
            player.UseItem(locations[player.currentLocation], input, new string[] { "use" }, "Please specify what you would like to use.");

            // Player moves to a different location.
            player.MoveLocation(input, new string[] { "go to", "goto", "move to", "moveto" }, "Please specify where you'd like to go.", locations);

            switch (input)
            {
                // Quit the game.
                case "q":
                case "quit":

                    isRunning = false;
                    break;

                // Display player inventory.
                case "inventory":
                case "i":
                    foreach (Item item in player.Inventory)
                    {
                        Console.WriteLine(item.Name);
                    }
                    break;

                // Write the location description and items at the location.
                case "look around":
                case "l":
                case "location":
                    locations[player.currentLocation].ShowLocation();
                    break;

                // Player dies and it's Game over. Closes the game.
                case "die":
                case "commit suicide":
                case "kill myself":
                    // make the player die based on a random death based on an array
                    Console.WriteLine("You die");
                    isRunning = false;
                    break;

                default:
                    //Console.WriteLine("Unknown command. Enter 'help'/'h' for more information.");
                    break;
            }
        }

    }
}
