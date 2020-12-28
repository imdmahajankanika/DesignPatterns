using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace MapReduce
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            int size = 5;
            // Creating a matrix of random integers as input
            DataFrame df = new DataFrame();
            int[,] rnd_mat = df.CreateMatrix(size, size);
            // Print the generated matrix of random numbers
            Console.WriteLine("Created a {0}x{1} matrix of random integers as input...", size, size);
            Console.WriteLine("***************************************************");
            df.DisplayMatrix(rnd_mat);

            // Create tasks to be executed by threads/nodes on random data input for map and reduce procedure
            GridTask[] tsk = new GridTask[rnd_mat.GetLength(0)];
            Thread[] thread = new Thread[rnd_mat.GetLength(0)];

            // Creating tasks for splitting and mapping procedure
            for (int i = 0; i < rnd_mat.GetLength(0); i++)
            {
                Console.WriteLine("\nPerforming Splitting and Mapping...\n");
                tsk[i] = new GridTask(df.Get_Row(i, rnd_mat));
                thread[i] = new Thread(new ThreadStart(tsk[i].Execute));
                thread[i].Start();
            }

            // Wait until all the threads are terminated
            foreach (Thread t in thread)
            {
                t.Join();
            }

            // Shuffling all the results after execution of tasks by each node/thread
            Console.WriteLine("\nShuffling...");
            Console.WriteLine("***********************");
            List<Dictionary<int, int>> res = new List<Dictionary<int, int>>();
            for (int i = 0; i < rnd_mat.GetLength(0); i++)
            {
                res.Add(tsk[i].Shuffled_Results());

            }

            // Performing reduce method
            Console.WriteLine("\nReducing...");
            Console.WriteLine("***********************");
            Dictionary<int, int> Final_Res = Reduce(res);
            foreach (var item in Final_Res)
                Console.WriteLine(item);
            // Sorting the final result
            var res_list = Final_Res.Keys.ToList();
            res_list.Sort();
            Console.WriteLine("\nFinal result...");
            Console.WriteLine("***********************");
            // Finally, emit each number and count
            foreach (var item in res_list)
            {
                Console.WriteLine("Item : {0}, Count : {1}", item, Final_Res[item]);
            }
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

        }

        public static Dictionary<int, int> Reduce(List<Dictionary<int, int>> dictionaries)
        {
            Dictionary<int, int> final = new Dictionary<int, int>();
            foreach (Dictionary<int, int> dict in dictionaries)
            {
                foreach (var item in dict)
                {
                    if (final.ContainsKey(item.Key))
                        final[item.Key] += item.Value;
                    else
                        final[item.Key] = item.Value;
                }
            }
            return final;
        }
    }
}