using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            //For colored look
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Welcome to ");
            DisplayInColor("Monopoly ", "Red", false);
            Console.Write("game!\n");
            //Make sure that the number of players is valid. We can change the range, if required
            Console.Write("\nChoose a number of players (2 - 8):- ");
            int NumberOfPlayers = GetValidInt(2, 8);
            Console.WriteLine("\nEnter name of the players:- ");
            List<Player> players = new List<Player>();
            GetUniqueNames(players, NumberOfPlayers);
            Game game = new Game(players);
            Console.Write("\nChoose the number of turns before the end:- ");
            int no_of_turns;
            try
            {
                no_of_turns = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("INVALID input...");
                Console.Write("Enter Integer input:- ");
                no_of_turns = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\n*********************************************\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write(" _-*");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" Monopoly");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" *-_");
            Console.WriteLine("__________________");
            Console.ForegroundColor = ConsoleColor.White;
            game.PlayTurns(no_of_turns);
            Console.ReadKey();
        }
        public static void DisplayInColor(string str, string color, bool WriteLineFull)
        {
            //This function writes in colors (text,color,writeline or write)
            switch (color)
            {
                case "Cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "Yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            if (WriteLineFull)
                Console.WriteLine(str);
            else
                Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static int GetValidInt(int min, int max)
        {
            //Make sure that the number of players is valid
            int input;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("INVALID input...");
                Console.Write("Enter Integer input (2-8):- ");
                input = Convert.ToInt32(Console.ReadLine());
            }
            while (!(input >= min && input <= max))
            {
                Console.Write("Oh! It seems you have entered an");
                DisplayInColor(" INVALID ", "Red", false);
                Console.WriteLine("number. Please enter the input again...");
                input = int.Parse(Console.ReadLine());
            }
            return input;
        }

        public static void GetUniqueNames(List<Player> players, int NumberOfPlayers)
        {
            //Obtain a unique name for each player

            bool Dup_Names = true;
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.Write($"\nPlayer ");
                DisplayInColor($"#{i + 1}", "Yellow", false);
                Console.Write(": Enter name:- ");
                players.Add(Init.CreatePlayer());
                players[i].Name = Console.ReadLine();
                Dup_Names = true;
                if (i != 0)
                {
                    while (Dup_Names)
                    {
                        Dup_Names = false;
                        for (int k = i - 1; k >= 0; k--)
                            if (players[i].Name == players[k].Name)
                            {
                                Console.WriteLine("\nPlease enter a name that isn't already in use... \n");
                                players[i].Name = Console.ReadLine();
                                Dup_Names = true;
                                break;
                            }
                    }
                }
            }
        }
    }
}