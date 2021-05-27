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
        /// <summary>
        /// Game Constructor
        /// </summary>
        /// <param name="player"></param>
        public Game()
        {
        }

        /// <summary>
        /// List of all Locations.
        /// </summary>
        public List<Location> locations;


        private Player player = new Player("department", 1, 1);
        private bool alive = true;
     

        /// <summary>
        /// GameLoop method. Game begins here.
        /// </summary>
        public void GameLoop()
        {
            while (alive)
            {
                Extentions.UI(player.Name, player.Department, player.Health, player.MaxHealth);
                Console.WriteLine("You are alive!");
                string input = Console.ReadLine().ToLower();
                if (input == "die" || input == "exit" || input == "q")
                {
                    Console.WriteLine("You are dead!");
                    alive = false;
                }
                Console.Clear();
            }
        }
    }
}
