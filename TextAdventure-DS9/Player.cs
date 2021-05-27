using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Player
    {
        /// <summary>
        /// Create a new Player.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        public Player(int strenght, int maxHealth, string[] departments)
        {

            // Promt the player for a name.
            Extentions.PromtForInput("Hello. Please enter your name:");
            string playerName = Console.ReadLine().ToLower();

            // Promt the player to select a department
            #region Department Selection
            int count = 1;

            // Write out all the professions
            Console.WriteLine("Which department do you want to join:");
            foreach (string department in departments)
            {
                Console.Write($"{count}.[{department}] ");
                count++;
            }

            // Take user input
            Console.WriteLine();
            string inputProfession = Console.ReadLine().ToLower();
            switch (inputProfession)
            {
                case "1":
                case "command":
                case "command department":
                case "commanddepartment":
                    Console.WriteLine("You selected command!");
                    Department = departments[0];
                    break;

                case "2":
                case "operations department":
                case "operationsdepartment":
                    Console.WriteLine("You selected operations!");
                    Department = departments[1];
                    break;

                case "3":
                case "sciences":
                case "sciences department":
                case "sciencesdepartment":
                    Console.WriteLine("You selected sciences!");
                    Department = departments[2];
                    break;

                case "q":
                case "quit":
                case "exit":

                    Environment.Exit(0);
                    break;

                default:
                    break;
            }
            #endregion


            Name = playerName.First().ToString().ToUpper();
            Strenght = strenght;
            MaxHealth = maxHealth;
            Health = maxHealth;
        }

        /// <summary>
        /// Player name.
        /// </summary>
        public string Name{ get; private set; }

        /// <summary>
        /// Player department.
        /// </summary>
        public string Department{ get; private set; }

        /// <summary>
        /// Player strenght. 
        /// </summary>
        public int Strenght { get; private set; }

        /// <summary>
        /// Player health.
        /// </summary>
        public int MaxHealth { get; private set; }

        /// <summary>
        /// Player health.
        /// </summary>
        public int Health { get; private set; }

        /// <summary>
        /// Items the player is carrying.
        /// </summary>
        public List<Item> items;

        /// <summary>
        /// Player takes damage.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

    }
}
