using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure_DS9
{
    class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Extentions.ConsoleStartScreen();

            Game game = new Game();
            game.Start();

            game.GameLoop();

            Console.ReadKey();
        }
    }

}