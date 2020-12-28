using System;
using System.Collections.Generic;

namespace MyCustomQueue
{
	public class CustomQueue<T>
	{
		public Node<T> head { get; set; }

		// Function to perform Enqueue opration

		public void Enqueue(Node<T> node, bool on_head = false)
		{
			// Creating Node<T> object

			Node<T> newItem = new Node<T>(node.data);

			if (head == null)
			{
				head = newItem;
			}
			else
			{
				if (on_head == true)
				// Add new element on the head of the queue    
				{
					Node<T> tmp = head;
					head = newItem;
					newItem.next = tmp;
				}

				else
				// Add new element on the end of the queue       
				{
					Node<T> curr = head;
					// Identify the end of the queue... 
					while (curr.next != null)
					{
						curr = curr.next;
					}
					// Add the new node on the end of the queue
					curr.next = newItem;
				}
			}
			Console.WriteLine("Enqueuing...");
			Console.WriteLine("'" + node.data + "'" + " :- added to the queue\n");
		}

		// Function to perform Dequeue opration on the queue
		public void Dequeue()
		{
			Console.WriteLine("Dequeuing...");
			if (head == null)
			{
				Console.WriteLine("Can't Dequeue, queue is empty\n");
			}
			else
			{
				Console.WriteLine("'" + head.data + "'" + " removed from the queue\n");
				Node<T> temp = head.next;
				head = null;
				head = temp;    // setting the next node as head
			}

		}
		// Function to get peek element from the queue
		public void peek(bool on_head = false)
		{
			if (head == null)
			{
				Console.WriteLine("No element at peek");
			}
			else
			{
				// Determine the first element of the queue
				Node<T> curr = head;
				Console.Write("Peak element:- " + "'"+curr.data+"'" + "\n");
			}
		}

		
		// Display the items in the queue
		public void display()
		{
			List<Node<T>> ln = new List<Node<T>>();
			Node<T> curr = head;

			while (curr != null)
			{
				ln.Add(curr);
				curr = curr.next;
			}

			if (ln.Count == 0)
			{
				Console.WriteLine("Queue is empty\n");
			}
			else
			{
				Console.WriteLine("Current queue elements :- ");
				foreach (Node<T> node in ln)
				{
					Console.Write(node.data + " | ");
				}
				Console.Write("\n\n");
			}
		}


	}
}
