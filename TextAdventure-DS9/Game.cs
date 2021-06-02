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
        private Random randomNumber = new Random();
        private static string[] departments = new string[] { "Command", "Operations", "Science" };
        private Player player = new Player(departments);
        private bool gameRunning = true;

        /// <summary>
        /// Game Constructor
        /// </summary>
        public Game()
        {
        }

        /// <summary>
        /// List of all Locations.
        /// </summary>
        public List<Location> locations = new List<Location>();


        enum DS9Locations
        {
            Dockingring = 0,
            Promenade = 1,
            Operations = 2,
            Infermary = 3,
            Quarks = 4
        }

        /// <summary>
        /// Set the game up.
        /// </summary>
        public void Start()
        {
            List<Item> playerQuartersItems = new List<Item>();
            playerQuartersItems.Add(new Item("Pillow", "You see a few gray, triangular pillows on the sofa."));
            Location playerQuarters = new Location("Your Quarters", new string[] { "You are in your quarters.", "You look around you. You can tell this Station was designed by a Cardassian." }, playerQuartersItems);

            locations.Add(playerQuarters);
        }

        /// <summary>
        /// GameLoop method. Game begins here.
        /// </summary>
        /// <param name="locationIndex"> Starting location </param>
        public void GameLoop(int locationIndex = 0)
        {
            // Clear console and display UI
            Console.Clear();
            Extentions.UI(player.Name, player.Department, player.Strenght, player.Health, player.MaxHealth);


            // Show location 
            locations[locationIndex].ShowLocation();
            // Show items that are in the location
            Console.WriteLine(locations[locationIndex].Items[0].Description);


            // Take user input 
            while (gameRunning)
            {
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "q":
                    case "quit":
                    case "exit":
                    case "close":
                        Environment.Exit(0);
                        break;

                    case "inventory":
                    case "items":
                        foreach (Item item in player.inventory)
                        {
                            Console.WriteLine(item.Name);
                        }
                        break;

                    case "look around":
                    case "location":
                        locations[locationIndex].ShowLocation();
                        break;


                    case "use":
                        Console.WriteLine("Please specify what you want to use.");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
