using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Program
    {
        private Random randomNumber = new Random();

        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Extentions.ConsoleSetup();
            Console.ReadKey();
            //Console.Clear();

            //Game game = new Game(CreatePlayer());
            //Console.Clear();
            //game.GameLoop();

            //Console.ReadKey();
            string WaterState(int tempInFahrenheit) =>
    tempInFahrenheit switch
    {
        (> 32) and (< 212) => "liquid",
        < 32 => "solid",
        > 212 => "gas",
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
    };
        }



        //private static Player CreatePlayer()
        //{
        //    // Get players name
            

        //    string playerProfession = SelectProfession(departments);
        //    return new Player(playerName, playerProfession, strenght);
        //}

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
                    Console.WriteLine("You selected command!");
                    return departments[0];

                case "2":
                case "operations department":
                case "operationsdepartment":
                    Console.WriteLine("You selected operations!");
                    return departments[1];

                case "3":
                case "sciences":
                case "sciences department":
                case "sciencesdepartment":
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
    }

}