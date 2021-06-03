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
            player = new Player(new string[] { "Command", "Operations", "Science" });

            // Load Game 
            Start();
        }

        /// <summary>
        /// List of all Locations.
        /// </summary>
        public List<Location> locations = new List<Location>();
        private 
            int locationIndex = 0;
        /// <summary>
        /// Setting up the things needed for the Game
        /// </summary>
        /// <param name="locationIndex"></param>
        public void Start()
        {
            isRunning = true;
            #region Location 0: Turbolift 
            Location turbolift = new Location("Turbolift", new string[] { "An empty turbolift." });
            locations.Add(turbolift);
            #endregion

            #region Location 1: Player Quarters
            List<Item> playerQuartersItems = new List<Item>();
            playerQuartersItems.Add(new Item("Pillow", "You see a few gray, triangular pillows on the sofa."));
            playerQuartersItems.Add(new Item("Toothbrush", "There is a toothbrush on the floor.... What..."));
            Location playerQuarters = new Location("Your Quarters", new string[] { "You are in your quarters.", "You look around you. You can tell this Station was designed by a Cardassian." }, playerQuartersItems);

            locations.Add(playerQuarters);
            #endregion

            #region Location 2: Promenade
            List<Item> promenadeItems = new List<Item>();
            promenadeItems.Add(new Item("Coin", "Something on the floor catches your eye. It's a coin."));
            Location promenade = new Location("Promenade", new string[] { "You are on the promenade.", "It's buzzing with people." }, playerQuartersItems);

            locations.Add(promenade);
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
            locations[locationIndex].ShowLocation();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Update()
        {
            string input = Extentions.PromtForInput("");

            switch (input)
            {
                case "q":
                case "quit":
                    isRunning = false;
                    break;

                case "inventory":
                case "i":
                    foreach (Item item in player.inventory)
                    {
                        Console.WriteLine(item.Name);
                    }
                    break;

                case "look around":
                case "location":
                    locations[locationIndex].ShowLocation();
                    break;

                case "die":
                    // make the player die based on a random death based on an array
                    Console.WriteLine("You ");
                    break;
                case "use":
                    Console.WriteLine("Please specify what you want to use.");
                    break;

                default:
                    break;
            }

            switch (input.Substring(0, input.Length))
            {
                case "my quarters":
                case "go to quarters":
                case "go to my quarters":
                    MoveLocation(1);
                    break;

                case "promenade":
                case "go to promenade":
                    MoveLocation(2);
                    break;
                default:
                    Console.WriteLine("You hear a robotic voice: 'Please state your destination'.");
                    break;
            }
        }
        private void MoveLocation(int nextLocation)
        {
            locationIndex = nextLocation;
            Console.Clear();
            Extentions.UI(player.Name, player.Department, player.Strenght, player.Health, player.MaxHealth);
            locations[locationIndex].ShowLocation();
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


            // Take user input 
            while (isRunning)
            {
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "q":
                    case "quit":
                    case "exit":
                    case "close":
                        isRunning = false;
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
