using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCustomQueue;
namespace CustomQueueTest
{
    [TestClass]
    public class CustomQueueTest
    {
        [TestMethod]
        // Test case number: 1
        // Test empty queue
        // Head of the queue will be null
        public void Test_empty_queue()
        {
            CustomQueue<int> q1 = new CustomQueue<int>();
            Assert.AreEqual(null,q1.head);
        }

        [TestMethod]
        // Test case number: 2
        // Test if queue is not null after enqueuing opration
        public void Test_nonEmpty_queue()
        {
            CustomQueue<string> q = new CustomQueue<string>();
            q.Enqueue(new Node<string>("Ciao"));
            q.Enqueue(new Node<string>("Monde"));
            Assert.IsNotNull(q);
        }

        [TestMethod]
        // Test case number: 3
        // Test case values: push integer 1 and 2 into the queue
        // head should be 1 and head.next should be 2
        public void Test_Enqueued_input()
        {
            CustomQueue<int> q = new CustomQueue<int>();
            q.Enqueue(new Node<int>(1));
            q.Enqueue(new Node<int>(2));
            Assert.IsTrue(q.head.next.data.Equals(2));
        }

        [TestMethod]
        // Test case number: 4
        // Test Node data with given input
        public void Test_CreateNode_WithGivenData()
        {
            int data = 9;
            Node<int> node = new Node<int>(data);
            Assert.AreEqual(9, node.data);
        }
    }
}
