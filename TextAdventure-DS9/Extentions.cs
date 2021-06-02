using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace TextAdventure_DS9
{
    public static class Extentions
    {
        /// <summary>
        /// Into text with the title and author.
        /// </summary>
        private static string[] intro = new string[] { "A Deep Space 9 Textadventure Game", "C# Eindopdracht", "CrazyPumpkin" };

        /// <summary>
        /// ASCII art. String array.
        /// </summary>
        private static string[] ASCII = new string[]
            {       
                // ASCII Art: Orbital Space Station(Terok Nor - Deep Space 9) - Joe Reiss
                    @"                __                ___               ___                ",
                    @"              ,' ,'              |   |              `. `.              ",
                    @"            ,' ,'                |===|                `. `.            ",
                    @"           / //                  |___|                  \\ \           ",
                    @"          / //                   |___|                   \\ \          ",
                    @"         ////                    |___|                    \\\\         ",
                    @"        /  /                    ||   ||                    \  \        ",
                    @"       /  /                     ||   ||                     \  \       ",
                    @"      /| |                      ||   ||                      | |\      ",
                    @"      || |                     | : o : |                     | ||      ",
                    @"     |  \|                     | .===. |                     |/  |     ",
                    @"     |  |\                    /| (___) |\                    /|  |     ",
                    @"    |__||.\         .-.      // /,_._,\ \\      .-.         /.||__|    ",
                    @"    |__||_.\        `-.\    //_ [:(|):] _\\    /.-'        /._||__|    ",
                    @" __/|  ||___`._____ ___\\__/___/_ ||| _\___\__//___ _____.'___||_ |\__ ",
                    @"/___//__________/.-/_____________|.-.|_____________\-.\__________\\___\",
                    @"\___\\__\\\_____\`-\__\\\\__\____|_-_|____/_//_____/-'/__//______//__//",
                    @"   \|__||__..'         //  \ _ \__|||__/ _ /  \\         `..__||__|/   ",
                    @"    |__||_./        .-'/    \\   |(|)|   //    \`-.        \..||__|    ",
                    @"    |  || /         `-'      \\   \'/   //      `-'         \ ||  |    ",
                    @"     |  |/                    \| :(-): |/                    \|  |     ",
                    @"     |  /|                     | : o : |                     |\  |     ",
                    @"      || |                     | |___| |                     | ||      ",
                    @"      \| |                      ||   ||                      | |/      ",
                    @"       \  \                     ||   ||                     /  /       ",
                    @"        \  \                    ||___||                    /  /        ",
                    @"         \\\\                    |___|                    ////         ",
                    @"          \ \\                   |___|                   // /          ",
                    @"           \ \\                  |   |                  // /           ",
                    @"            `. `.                |===|                ,' ,'            ",
                    @"              `._`.              |___|              ,'_,'              ",
                    @"ASCII Art: Orbital Space Station (Terok Nor - Deep Space 9) - Joe Reiss"
            };

        /// <summary>
        /// ASCII Character for a double line.
        /// </summary>
        private static char horizontalEdges = (char)9552;

        /// <summary>
        /// Returns a capitalized string.
        /// </summary>
        /// <param name="text">String to capitalize.</param>
        /// <returns></returns>
        public static string CapitalizeString(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                char[] letters = text.ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                return new string(letters);
            }
            else
            {
                return text;
            }
        }

        /// <summary>
        /// Centers a string in a new line.
        /// </summary>
        /// <param name="text">String</param>
        public static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        /// <summary>
        /// Centers an array. Each item on a new line. 
        /// </summary>
        /// <param name="text">Array of strings</param>
        public static void CenterText(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text[i].Length / 2)) + "}", text[i]));
            }
        }

        /// <summary>
        /// Initialize the console. Set the size and display the ASCII art and the intro text.
        /// </summary>
        /// <param name="width">Optional: The width of the console window. Default value is 150</param>
        /// <param name="height">Optional: The height of the console window. Default value is 45</param>
        public static void ConsoleStartScreen(int width = 150, int height = 45)
        {
            // Set the console size.
            Console.SetWindowSize(width, height);

            // Display the ASCII.
            CenterText(ASCII);
            Console.WriteLine(); // adds one line of spacing

            // Write the intro text.
            CenterText(intro);

            // Press enter to continue
            Continue();
            Console.Clear();
        }

        /// <summary>
        /// Check if the user pressed a certain input to continue.
        /// </summary>
        /// <param name="pressToContinue">Key that needs to be pressed</param>
        public static void Continue(ConsoleKey pressToContinue = ConsoleKey.Enter, string pressToContinueMessage = "Press Enter to continue.")
        {
            if (Console.ReadKey(true).Key != pressToContinue)
            {
                Console.WriteLine(pressToContinueMessage);
                Continue();
            }
        }

        /// <summary>
        /// Draws a symbol along the width of the console. 
        /// </summary>
        /// <param name="symbol">Which symbol to draw</param>
        private static void DrawLine(char symbol)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(symbol);
            }
        }

        /// <summary>
        /// UI to display the player's information.
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerDepartment"></param>
        /// <param name="playerCurrentHealth"></param>
        /// <param name="playerMaxHealth"></param>
        public static void UI(string playerName, string playerDepartment, int playerStrength, int playerMaxHealth, int playerCurrentHealth)
        {
            DrawLine(horizontalEdges);
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 6) + (playerDepartment.Length / 2)) + "}", CapitalizeString(playerName)));
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 6) + (playerDepartment.Length / 2)) + "} Department", CapitalizeString(playerDepartment)));
            string strength = $"Strength: {playerStrength}";
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 6) + (strength.Length / 2)) + "}", strength));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 6) + (playerCurrentHealth.ToString().Length / 2)) + "}/{1} HP", playerCurrentHealth, playerMaxHealth));
            DrawLine(horizontalEdges);
        }

        /// <summary>
        /// Writes an input promt. Checks if the users input is not empty.
        /// </summary>
        /// <param name="prompt">Promt message</param>
        /// <returns></returns>
        public static string PromtForInput(string prompt)
        {
            Console.WriteLine();
            Console.Write(prompt);
            string input = Console.ReadLine().ToLower();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.Write("Invalid input! Your name can't be empty.");
                Continue();
                return PromtForInput(prompt);
            }
        }

    }
}
