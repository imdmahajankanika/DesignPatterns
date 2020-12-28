using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace Monopoly
{
    public class Game
    {
        private List<Player> players = new List<Player>();

        public Game(List<Player> Players)
        {
            players = Players;
        }
        public void PlayTurns(int no_of_turns)
        {
            int maxRev = 0;
            int topPos = 0;
            int topPlayer = -1;

            Thread[] thread = new Thread[players.Count];
            for (int i = 0; i < players.Count; i++)
            {
                // Set number of turns
                players[i].set_turns = no_of_turns;
            }
            // Start mulithreading for players
            for (int i = 0; i < players.Count; i++)
            {
                thread[i] = new Thread(new ThreadStart(players[i].Execute));
                thread[i].Start();
            }

            // Wait until all the threads are terminated
            foreach (Thread t in thread)
                t.Join();

            MainProgram.DisplayInColor("\nResults:-", "Red", false);
            Console.Write("\n*************************************************************");
            // Check for the player with latest position
            for (int i = 0; i < players.Count; i++)
            {
                if ((maxRev == players[i].Rev && topPos < players[i].Pos) || maxRev < players[i].Rev)
                {
                    topPlayer = i;
                    topPos = players[i].Pos;
                    maxRev = players[i].Rev;
                }

                Console.Write("\nPlayer ");
                MainProgram.DisplayInColor($"#{i + 1}, ", "Yellow", false);
                MainProgram.DisplayInColor(players[i].Name, "Red", false);
                Console.Write(":- Position:-");
                MainProgram.DisplayInColor($" {players[i].Pos}","Green",false);
                Console.Write(", Revisit(s) completed:-  ");
                MainProgram.DisplayInColor($"{players[i].Rev}", "Green", false);
            }

            Console.Write("\n\nPlayer ");
            MainProgram.DisplayInColor(players[topPlayer].Name, "Red", false);
            Console.Write(" WON!");
            Console.Write("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}