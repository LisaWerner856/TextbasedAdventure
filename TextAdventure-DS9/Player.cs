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
        public List<Item> Inventory = new List<Item>();

        public string[] Actions = new string[] { "take", "pickup", "use" };

        public int currentLocation { get; private set; }

        /// <summary>
        /// Create a new Player.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        public Player(string[] departments, int startingLocation)
        {
            // Standart Starfleet equiptment 
            Inventory.Add(new Item("Phaser", "A standard Starfleed issued phaser.", true));
            Inventory.Add(new Item("Tricorder", "Versitile, portable sensing device.", true));
            Inventory.Add(new Item("Combadge", "Multi-purpose communications and universal translation device.", false));

            Name = Extentions.PromtForInput("Please enter your name: ", "Your name can't be empty!");
            
            Department = SelectProfession(departments);
            currentLocation = startingLocation;
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
        /// <summary>
        /// Take an item. Check if item exists at current location.
        /// </summary>
        /// <param name="currentLocation">The current location of the player</param>
        /// <param name="input">Player input</param>
        /// <param name="validCommands">Array of valid commands to execute this action</param>
        /// <param name="message">Message if the command needs more informations. Example: Input = take. Message = What do you want to take?</param>
        public void TakeItem(Location currentLocation, string input, string[] validCommands, string message)
        {
            // loop over all valid commands for taking an item.
            foreach (string command in validCommands)
            {
                // checks for the command at the start of the player input.
                if (input.Length >= command.Length && input.Substring(0, command.Length) == command)
                {
                    //If only the command was entered, promt a message for the user to specify which object they would like to pick up.
                    if (input == command)
                    {
                        Console.WriteLine(message);
                        return;
                    }

                    // Check if the item exists in the current location
                    if (currentLocation.Items.Exists(x => x.GetItemName() == input.Substring(command.Length + 1)))
                    {
                        foreach (Item item in currentLocation.Items)
                        {
                            if (item.Name.ToLower() == input.Substring(command.Length + 1))
                            {
                                Console.WriteLine($"\nYou take the {item.GetItemName()}.");
                                Inventory.Add(item);
                                currentLocation.Items.Remove(item);
                                return;
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("\n" + input.Substring(command.Length + 1) + " does not exist.\n");
                        return;
                    }
                }
            }
        }

        // Player action - use  item
        public void UseItem(Location currentLocation, string input, string[] validCommands, string message)
        {
            // loop over all valid commands for taking an item.
            foreach (string command in validCommands)
            {
                // checks for the command at the start of the player input.
                if (input.Length >= command.Length && input.Substring(0, command.Length) == command)
                {
                    //If only the command was entered, promt a message for the user to specify which object they would like to pick up.
                    if (input == command)
                    {
                        Console.WriteLine(message);
                        return;
                    }

                    // Check if the item exists in the players inventory
                    if (Inventory.Exists(x => x.GetItemName() == input.Substring(command.Length + 1)))
                    {
                        foreach (Item item in Inventory)
                        {
                            if (item.Name.ToLower() == input.Substring(command.Length + 1))
                            {
                                Console.WriteLine($"\nYou remove {item.GetItemName()} from your inventory.");
                                // TODO: Something happens
                                Inventory.Remove(item);
                                return;
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine($"You don't have a {input.Substring(command.Length + 1)} in your inventory.");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Drops item from player inventory into their current location.
        /// </summary>
        /// <param name="currentLocation"></param>
        /// <param name="input"></param>
        /// <param name="validCommands"></param>
        /// <param name="message"></param>
        public void DropItem(Location currentLocation, string input, string[] validCommands, string message)
        {
            // loop over all valid commands for taking an item.
            foreach (string command in validCommands)
            {
                // checks for the command at the start of the player input.
                if (input.Length >= command.Length && input.Substring(0, command.Length) == command)
                {
                    //If only the command was entered, promt a message for the user to specify which object they would like to pick up.
                    if (input == command)
                    {
                        Console.WriteLine(message);
                        return;
                    }

                    // Check if the item exists in the current location
                    if (Inventory.Exists(x => x.GetItemName() == input.Substring(command.Length + 1)))
                    {
                        foreach (Item item in currentLocation.Items)
                        {
                            if (item.GetItemName() == input.Substring(command.Length + 1))
                            {
                                Console.WriteLine($"\nYou dropped {item.Name}.");
                                Inventory.Remove(item);
                                currentLocation.Items.Add(item);
                                return;
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine($"You don't have a {input.Substring(command.Length + 1)} in your inventory.");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Prints the contents of the players inventory.
        /// </summary>
        /// <returns>Returns a string with the inventory contents.</returns>
        public string GetInventory()
        {
            string inventoryContent = "";

            foreach (Item item in Inventory)
            {
                inventoryContent += $"{item.Name}\n";
            }
            return inventoryContent;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="input">Player input.</param>
       /// <param name="validCommands">Array of valid commands to do this action.</param>
       /// <param name="message">Message to ask the user to specify where they want to go.</param>
       /// <param name="nextLocation">The locatoin to move to.</param>
       /// <param name="locations">List of locations in the Game.</param>
        public void MoveLocation(string input, string[] validCommands, string message, int nextLocation, List<Location> locations)
        {
            // loop over all valid commands for moving.
            foreach (string command in validCommands)
            {
                // Check if the input is longer or equal to the command length.
                // Check it the input (starting at index 0, ending at the last character in the command string) is equal to the command that's looped over right now.
                if (input.Length >= command.Length && input.Substring(0, command.Length) == command)
                {

                    //If only the command was entered, promt a message for the user to specify which object they would like to pick up.
                    if (input == command)
                    {
                        Console.WriteLine($"{message}");
                        return;
                    }
                    // Check if the exit exists in the current location
                    if (locations[currentLocation].Exits.Exists(exit => exit.LeadsTo.LocationName.ToLower() == input.Substring(command.Length + 1)))
                    {
                        foreach (Exit exit in locations[currentLocation].Exits)
                        {
                            Console.WriteLine($"{exit.LeadsTo.LocationName.ToLower()} == {input.Substring(command.Length + 1)}");
                            if (exit.LeadsTo.LocationName.ToLower() == input.Substring(command.Length + 1))
                            {
                                currentLocation = exit.LeadsTo.LocationIndex;
                                Console.Clear();
                                Extentions.UI(Name, Department, Strenght, Health, MaxHealth);
                                locations[currentLocation].ShowLocation();
                                return;
                            }
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Location not found!");
                    }
                }
            }

        }
    }
}
