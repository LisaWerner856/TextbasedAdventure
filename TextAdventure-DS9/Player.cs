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
        public Item RemoveItem(string itemToRemove)
        {
            foreach (Item item in Inventory)
            {
                if (item.Name.ToLower() == itemToRemove)
                {
                    Inventory.Remove(item);
                    return item;
                }
            }

            return null;
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
                    if (currentLocation.Items.Exists(x => x.GetNameLowercase() == input.Substring(command.Length + 1)))
                    {
                        foreach (Item item in currentLocation.Items)
                        {
                            if (item.Name.ToLower() == input.Substring(command.Length + 1))
                            {
                                if (item.GetNameLowercase() == "pillow")
                                {
                                    Console.WriteLine("You take the pillow. It's surprisingly soft...");
                                    Console.WriteLine("After squishing the pillow for a while you sit down on the bed.");
                                    Console.WriteLine("It's more comfortable than it looks. You lay down. Your eyes feel pretty heavy...");
                                    Console.WriteLine("Before you know it you fell asleep. Lets hope you wake up in time to report to duty...");
                                    TakeDamage(Health);
                                    return;
                                }
                                if (item.Useable)
                                {
                                    Console.WriteLine($"\nYou take the {item.GetNameLowercase()}.");
                                    Inventory.Add(item);
                                    currentLocation.Items.Remove(item);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine($"You can't take this.");
                                    return;
                                }
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
                    if (Inventory.Exists(x => x.GetNameLowercase() == input.Substring(command.Length + 1)))
                    {
                        foreach (Item item in Inventory)
                        {
                            if (item.Name.ToLower() == input.Substring(command.Length + 1) && item.Useable)
                            {
                                Console.WriteLine($"Use {item.GetNameLowercase()} on?");
                                string secondItem = Console.ReadLine();

                                if (secondItem == "myself" || secondItem == "self" && item.GetNameLowercase() == "phaser")
                                {
                                    TakeDamage(5);
                                    Console.Clear();
                                    Extentions.UI(Name, Department, Strenght, MaxHealth, Health);
                                    currentLocation.ShowLocation();
                                    Console.WriteLine($"You shoot yourself! What's wrong with you {Extentions.CapitalizeString(Name)}?!");
                                    Console.WriteLine("Luckily your phaser was set to stun...");
                                    Console.WriteLine("Security was called and you were taken to the infirmary.");
                                    Console.WriteLine("Besides a small phaser burn you are fine. But you are temportarily relieved from duty... ");
                                    Console.WriteLine("Your phaser is taken away and you have to see the counselor.");
                                    //int targetLocatoin = Game.locations.FindIndex(x => x.GetLocationNameLowercase() == "infirmary");
                                    //Console.WriteLine($"{targetLocatoin} target");

                                    //Inventory.Remove(item);
                                    TakeDamage(Health);

                                    return;
                                }

                                if (currentLocation.Items.Exists(i => i.GetNameLowercase() == secondItem) || Inventory.Exists(i => i.GetNameLowercase() == secondItem))
                                {
                                    Console.WriteLine("You use the item.");
                                    if (secondItem == "rock" && item.GetNameLowercase() == "phaser")
                                    {
                                        Console.WriteLine("You shoot the rock.");
                                        currentLocation.AddItem(new Item("Molten Rock", "There is molten rock all over the place now...", false));

                                        // Remove rock from location inventory or player inventory
                                        if (currentLocation.Items.Exists(x => x.GetNameLowercase() == secondItem))
                                        {
                                            currentLocation.RemoveItem(secondItem);

                                        }
                                        if (Inventory.Exists(x => x.GetNameLowercase() == secondItem))
                                        {
                                            RemoveItem(secondItem);
                                        }

                                        return;
                                    }
                                    // Play at the dabo table.
                                    if (secondItem == "dabo table" || secondItem == "dabo" && item.GetNameLowercase() == "latinum")
                                    {
                                        Console.WriteLine("You play dabo!");
                                        Console.WriteLine("You have a nice relaxing evening at Quarks. You return to your quarters, happy and exicited for your first day of duty tomorrow!");

// TODO: Win or lose based on a random number

                                        return;
                                    }

                                    // Buy something at the bar.
                                    if (secondItem == "bar" && item.GetNameLowercase() == "latinum")
                                    {
                                        #region Story: Bar
                                        Console.WriteLine("You walk over to the bar to order. The Ferengi walks over to you and greets you.");
                                        Console.WriteLine($"'Oh, you are the new arrival, fresh from the academy. Welcome to my bar!'");
                                        Console.WriteLine("You nod.");
                                        Console.WriteLine("'Feel free to try your luck at the dabo wheel! It's an excellent game. Just make sure you have enough latinum.'");
                                        #endregion

                                        // Create available items for purchase.
                                        Item[] beverages = new Item[]
                                        {
                                            new Item("Beer", "A Human beverage called beer.", true),
                                            new Item("Raktajino", "A combination of cappuccino and the Klingon drink ra'taj. It's quite popular.", true),
                                            new Item("Bajoran ale", "A type of ale created by the Bajorans. It's not very potent.", true)
                                        };

                                        // Promt user for input.
                                        string drink = Extentions.PromtForInput("'Anyways. Can I get you anything? If you want I can recommend you something.'\n").ToLower();
                                        
                                        switch (drink)
                                        {
                                            case "recommend":
                                            case "recommend something":
                                            case "recommend me something":
                                                foreach (Item beverage in beverages)
                                                {
                                                    Console.WriteLine($"We have {beverage.Name}. {beverage.Description}");
                                                }
                                                drink = Extentions.PromtForInput("'Any of those sound good?'\n").ToLower();

                                                break;
                                            case "nevermind":
                                            case "nothing":
                                                Console.WriteLine("'Huu-mans' the Ferengi mumbles.");
                                                Console.ReadKey();
                                                return;
                                        }

                                        // Check if ordered drink is available.
                                        foreach (Item beverage in beverages)
                                        {
                                            if (drink == beverage.GetNameLowercase())
                                            {
                                                RemoveItem("latinum");
                                                Inventory.Add(beverage);
                                            }
                                        }

                                        Console.Clear();
                                        Extentions.UI(Name, Department, Strenght, MaxHealth, Health);
                                        currentLocation.ShowLocation();
                                        Console.WriteLine("You buy a drink!");
                                        Console.WriteLine("You have a nice relaxing evening at Quarks. You return to your quarters, happy and exicited for your first day of duty tomorrow!");
                                        Console.ReadKey();
                                        TakeDamage(Health);
                                        return;
                                    }

                                    // Go to your quarters and sleep
                                    

                                    return;
                                }
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine($"You don't have {input.Substring(command.Length + 1)} in your inventory.");
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
                    if (Inventory.Exists(x => x.GetNameLowercase() == input.Substring(command.Length + 1)))
                    {
                        foreach (Item item in currentLocation.Items)
                        {
                            if (item.GetNameLowercase() == input.Substring(command.Length + 1))
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
            string inventoryContent = "Inventory:\n";
            foreach (Item item in Inventory)
            {
                inventoryContent += $"- {item.Name}\n";
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
        public void MoveLocation(string input, string[] validCommands, string message, List<Location> locations)
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
