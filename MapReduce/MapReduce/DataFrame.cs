using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MapReduce
{
    // Random Data frame received in input
    class DataFrame
    {
        public int[,] CreateMatrix(int rows, int columns)
        {
            int[,] arr = new int[rows, columns];
            // Using object of Random class for generating random numbers
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arr[i, j] = rnd.Next(20); // Selecting non-negative random integer that is less than the specified maximum(20)
                }
            }
            return arr;
        }
        public void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Adjust the spacing for two digit numbers
                    if (matrix[i, j] > 9)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
        public int[] Get_Row(int row_num, int[,] matrix)
        {
            int[] row = new int[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                row[i] = matrix[row_num, i];
                Console.Write(row[i] + " ");
            }
            Console.WriteLine();
            return row;
        }


    }
}