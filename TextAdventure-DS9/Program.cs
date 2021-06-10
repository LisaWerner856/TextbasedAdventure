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

            Game game = new Game();

            game.Start();
            while (game.isRunning)
            {
                game.Update();
            }

        }

        public string[] DoAction(string input)
        {
            int divider = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ':')
                {
                    divider = i;
                    Console.WriteLine($"Input i = {input[i]}, i = {i}, lenght:{input.Length}");

                }
            }

            string command = input.Substring(0, divider);
            string target = input.Substring(divider + 1, input.Length - (divider + 1));
            Console.WriteLine(input.Length);
            Console.WriteLine(input.ToCharArray().Length);
            Console.WriteLine("command = " + command);
            Console.WriteLine($"input = {input}");
            Console.WriteLine("location = " + target);

            Console.ReadKey();
            return new string[] { command, target };
        }
    }

}