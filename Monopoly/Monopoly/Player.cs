using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace Monopoly
{
    interface IPlayer
    {
        string Name { get; set; }
        int TurnsInJail { get; set; }
        bool IsInJail { get; }
        int Rev { get; set; } // No. of revisits back to 0, if a player reaches position 39 and still needs to move forward
        int Pos { get; set; } // Board positions between 0-39
        void Execute();
        void MoveAction(int numberOfSteps);
        void VisitJail();
    }

    public class Player : IPlayer
    {
        private string name;
        private int turnsInJail;
        private bool isInJail;
        private int rev;
        private int pos;
        private int no_of_turns;

        public Player()
        {

            isInJail = false;
            rev = 0;
            pos = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int TurnsInJail
        {
            get { return turnsInJail; }
            set { turnsInJail = value; }
        }
        public bool IsInJail
        {
            get { return isInJail; }

        }
        public int Rev
        {
            get { return rev; }
            set { rev = value; }
        }
        public int Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public int set_turns
        {
            get { return no_of_turns; }
            set { no_of_turns = value; }
        }
        public int[] RollDice()
        {
            // Each player has to roll two dices
            //Random rand = new Random();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int dice1 = rand.Next(1, 7);
            int dice2 = rand.Next(1, 7);
            int[] array = new int[2];
            array[0] = dice1;
            array[1] = dice2;
            return array;
        }
        public void MoveAction(int steps)
        {

            if ((pos + steps) > 39)          // If a player reaches position 39 and still needs to move forward, he'll continue from position 0
            {
                pos = pos + steps - 40;
                rev = rev + 1;              // Increment the board positions revisits for the player
            }
            else
            {
                pos += steps;
            }
        }

        // Player moved to jail
        public void VisitJail()
        {
            pos = 10;
            isInJail = true;
            turnsInJail = 0;
            Console.WriteLine("\nPlayer " + name + " moved to 'InJail' cell at position " + pos);
        }


        public void Execute()
        {
            // Threads starting game execution

            for (int j = 0; j < no_of_turns; j++)
            {
                // Player i's turn to roll dices
                int[] Dices_result;
                int MoveCount;
                int ConsecutiveDoubles = 0;
                do
                {
                    Dices_result = RollDice();
                    //  Move forward by a number of positions equal to the sum of the numbers obtained on the two dices
                    MoveCount = Dices_result[0] + Dices_result[1];
                    if (Dices_result[0] == Dices_result[1])
                    {
                        ConsecutiveDoubles++;
                    }
                    if (ConsecutiveDoubles >= 3)
                    {
                        Console.WriteLine("\nPlayer '" + name + "' rolled a double for the third time in a single turn");
                        VisitJail();
                    }
                    //  Move forward by MoveCount, if not in jail condition is met
                    if (IsInJail == false)
                    {
                        MoveAction(MoveCount);
                        //If at the end of a basic move, the player lands on Go To Jail(position 30), then he immediately moves to the position Visit Only / In Jail and is in jail.
                        if (pos == 30)
                        {
                            Console.WriteLine("\nPlayer " + name + " lands on 'Go To Jail' cell, at position " + pos);
                            VisitJail();
                        }
                    }
                    // While in jail, player doesn't move until below conditions are met
                    if (IsInJail == true)
                    {
                        if (Dices_result[0] == Dices_result[1] || TurnsInJail >= 3)
                        {
                            MoveAction(MoveCount);
                            turnsInJail = 0;
                        }
                        else
                        {
                            turnsInJail++;
                        }
                    }


                } while (Dices_result[0] == Dices_result[1] && ConsecutiveDoubles < 3);
                ConsecutiveDoubles = 0;
            }
        }
    }

    public static class Init
    {
        public static Player CreatePlayer()
        {
            return new Player();
        }
    }
}
