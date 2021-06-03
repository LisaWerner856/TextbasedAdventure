using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TextAdventure_DS9
{
    class Player
    {
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
        public List<Item> inventory = new List<Item>();

        public string[] Actions = new string[] { "take", "pickup", "use" };

        /// <summary>
        /// Create a new Player.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        public Player(string[] departments)
        {
            // Standart Starfleet equiptment 
            inventory.Add(new Item("Phaser", "A standard Starfleed issued phaser."));
            inventory.Add(new Item("Tricorder", "Versitile, portable sensing device."));
            inventory.Add(new Item("Combadge", "Multi-purpose communications and universal translation device."));

            Name = Extentions.PromtForInput("Please enter your name: ", "Your name can't be empty!");
            
            Department = SelectProfession(departments);
        }

        /// <summary>
        /// Player takes damage.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        /// <summary>
        /// Select Proffesion method. Chooses a profession based on options in an array.
        /// </summary>
        /// <param name="departments"></param>
        /// <returns>String</returns>
        private string SelectProfession(string[] departments)
        {
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
                    Strenght = 8;
                    MaxHealth = 25;
                    Health = MaxHealth;
                    Console.WriteLine("You selected command!");
                    return departments[0];

                case "2":
                case "operations department":
                case "operationsdepartment":
                    Strenght = 6;
                    MaxHealth = 20;
                    Health = MaxHealth;
                    Console.WriteLine("You selected operations!");
                    return departments[1];

                case "3":
                case "sciences":
                case "sciences department":
                case "sciencesdepartment":
                    Strenght = 2;
                    MaxHealth = 20;
                    Health = MaxHealth;
                    Console.WriteLine("You selected sciences!");
                    return departments[2];

                case "q":
                case "quit":
                case "exit":

                    Environment.Exit(0);
                    return "0";

                default:
                    return SelectProfession(departments);
            }
        }


        // Player action - collect item
        public void CollectItem(Location location, Item item)
        {
            location.Items.Remove(item);
            inventory.Add(item);
        }

        // Player action - drop item
        public void DropIem(Location location, Item item)
        {
            if (inventory.Contains(item))
            {
                location.Items.Add(item);
                inventory.Remove(item);
            }
        }

        // Player action - use  item
        public void UseItem(Item item)
        {
            if (inventory.Contains(item))
            { 
                inventory.Remove(item);
            }
        }

    }
}
