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
            // Initialize player
            player = new Player(new string[] { "Command", "Operations", "Science" }, 0);

            // Load Game 
            Start();
        }

        /// <summary>
        /// List of all Locations.
        /// </summary>
        public List<Location> locations = new List<Location>();

        //private int currentLocation = 0;

        /// <summary>
        /// Setting up the things needed for the Game
        /// </summary>
        /// <param name="locationIndex"></param>
        public void Start()
        {
            isRunning = true;

            #region Location: Turbolift 
            List<Item> itemsTesting = new List<Item> { new Item("Rock", "It's a rock.", true), new Item("Stick", "It's a stick.", true), new Item("Postcard", "It's a random postcard.", false) };
            Location turbolift = new Location("Turbolift", new string[] { "An empty turbolift." }, 0, itemsTesting);
            locations.Add(turbolift);
            #endregion

            #region Location: Player Quarters
            List<Item> playerQuartersItems = new List<Item>();
            playerQuartersItems.Add(new Item("Pillow", "You see a few gray, triangular pillows on the sofa.", true));
            playerQuartersItems.Add(new Item("Toothbrush", "There is a toothbrush on the floor.... What...", false));
            Location playerQuarters = new Location("Quarters", new string[] { "You are in your quarters.", "You look around you. You can tell this Station was designed by a Cardassian." }, 1, playerQuartersItems);

            locations.Add(playerQuarters);
            #endregion

            #region Location: Promenade
            List<Item> promenadeItems = new List<Item>();
            promenadeItems.Add(new Item("Coin", "Something on the floor catches your eye. It's a coin.", true));
            Location promenade = new Location("Promenade", new string[] { "You are on the promenade.", "It's buzzing with people." }, 2, playerQuartersItems);

            locations.Add(promenade);
            #endregion

            // Add exits
            turbolift.AddExit(new Exit(playerQuarters));
            turbolift.AddExit(new Exit(promenade));

            playerQuarters.AddExit(new Exit(turbolift));

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
        }

        /// <summary>
        /// Called when a new game loop starts.
        /// </summary>
        public void Update()
        {
            string input = Extentions.PromtForInput("");

            //Action(input, locations[currentLocation]);

            // Player adds item to their inventory and removes the item from the location.
            player.TakeItem(locations[player.currentLocation], input, new string[] { "take", "pick up", "pickup" }, "Please specify what you would like to take.");

            // Player removes item from their inventory and adds the item to the location.
            player.DropItem(locations[player.currentLocation], input, new string[] { "drop" }, "Please specify what you would like to take.");

            // Player removes item from their inventory. 
            player.UseItem(locations[player.currentLocation], input, new string[] { "use" }, "Please specify what you would like to use.");

            // Player moves to a different location.
            player.MoveLocation(input, new string[] { "go to", "goto", "move to", "moveto" }, "Please specify where you'd like to go.", 1, locations);

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

                // TODO: Interact with the items.
                case "use":
                    Console.WriteLine("Work in Progress");
                    Console.WriteLine("Please specify what you want to use.");
                    break;

                //case "test go":
                //    player.MoveLocation(1, locations);
                //    break;
                default:
                    //Console.WriteLine("Unknown command. Enter 'help'/'h' for more information.");
                    break;
            }
        }
    }
}
