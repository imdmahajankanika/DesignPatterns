using Microsoft.VisualStudio.TestTools.UnitTesting;
using MapReduce;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MapReduceTests
{
    [TestClass]
    public class MapReduceTests
    {
        [TestMethod]
        // Test reduce procedure by adding data from different dictionaries containing number as key and its count as value
        // Expected result:- Occurence for same keys in different dictionaries will be combined
        public void Test_occurences_of_element()
        {
            var data1 = new Dictionary<int, int>();
            data1.Add(1, 1);
            data1.Add(2, 1);
            data1.Add(3, 1);
            var data2 = new Dictionary<int, int>();
            data2.Add(4, 2);
            data2.Add(3, 6);
            var data3 = new Dictionary<int, int>();
            data3.Add(1, 1);
            data3.Add(4, 1);
            data3.Add(2, 4);
            List<Dictionary<int, int>> res = new List<Dictionary<int, int>>();
            res.Add(data1);
            res.Add(data2);
            res.Add(data3);
            Dictionary<int, int> Final_Res = MainProgram.Reduce(res);
            
            // Count for key 4 will be 3
            Assert.AreEqual(3, Final_Res.ElementAt(3).Value);
            // Count for key 1 will be 2
            Assert.AreEqual(2, Final_Res.ElementAt(0).Value);
            // Count for key 3 will be 7
            Assert.AreEqual(7, Final_Res.ElementAt(2).Value);
            // Count for key 2 will be 5
            Assert.AreEqual(5, Final_Res.ElementAt(1).Value);

        }

        [TestMethod]
        // Expected result:- We have given 6 key-value pairs as input, but output will be 4 key-value pairs as the same keys will be combined
        public void Test_count_of_total_elements()
        {
            var data1 = new Dictionary<int, int>();
            data1.Add(1, 1);
            data1.Add(2, 1);
            data1.Add(3, 1);
            var data2 = new Dictionary<int, int>();
            data2.Add(4, 2);
            data2.Add(3, 6);
            data2.Add(2, 2);
            List<Dictionary<int, int>> res = new List<Dictionary<int, int>>();
            res.Add(data1);
            res.Add(data2);
            Dictionary<int, int> Final_Res = MainProgram.Reduce(res);

            // As there are 4 different keys, final result count will be 4
            Assert.IsTrue(Final_Res.Count == 4);

        }
    }

}

