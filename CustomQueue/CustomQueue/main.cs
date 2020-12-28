using System;

namespace MyCustomQueue
{
	public class MainProgram
	{
		public static void Main(string[] args)
		{
			CustomQueue<string> q = new CustomQueue<string>();
			// Enqueuing the 5 elements in the queue of type string
			q.Enqueue(new Node<string>("Hello,"));
			q.Enqueue(new Node<string>("World! "));
			q.Enqueue(new Node<string>("Welcome "));
			q.Enqueue(new Node<string>("to "));
			q.Enqueue(new Node<string>("C#"));
			Console.WriteLine("*******************************************");
			// Display the elements of a queue
			q.display();
			Console.WriteLine("*******************************************\n");
			// Show the top element in the queue
			q.peek();
			Console.WriteLine("\n*******************************************\n");
			// Dequeuing first element from the queue(FIFO)
			q.Dequeue();
			q.display();
			Console.WriteLine("*******************************************\n");
			// Dequeuing second element from the queue
			q.Dequeue();
			Console.WriteLine("*******************************************\n");
			// Show the top element in the queue
			q.peek();
			Console.WriteLine("\n*******************************************\n");
			q.display();
			Console.WriteLine("*******************************************\n");
			// Dequeuing third element from the queue
			q.Dequeue();
			q.display();
			Console.WriteLine("*******************************************\n");
			// Dequeuing fourth and fifth element from the queue
			q.Dequeue();
			q.Dequeue();
			Console.WriteLine("*******************************************\n");
			// Dequeuing again, but this time we will get null as the queue is empty
			q.Dequeue();
			Console.WriteLine("*******************************************\n");
			// Show the top element in the queue, as we have dequeued all 5 elements, queue will be empty
			q.peek();

		}
	}
}