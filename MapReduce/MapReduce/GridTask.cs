using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MapReduce
{
    class GridTask
    {
        private int[] row_array;
        private Dictionary<int, int> results;
        public GridTask(int[] row_array)
        {
            this.row_array = row_array;
            results = new Dictionary<int, int>();
        }
        public void Execute()
        {
            int rows = row_array.Length;

            for (int i = 0; i < rows; i++)
            {
                int val = row_array[i];

                if (results.ContainsKey(val))
                {
                    results[val] = results[val] + 1;
                }
                else
                {
                    results[val] = 1;
                }
            }
            
        }
        public Dictionary<int, int> Shuffled_Results()
        {
            foreach (var item in results)
                Console.Write(item+" ");
            Console.WriteLine();
            return results;
        }
    }
}