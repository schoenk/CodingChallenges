<Query Kind="Program" />

void Main()
{
	LinkedList myList = new LinkedList();
	myList.addAtEnd(1);
	myList.addAtEnd(2);
	myList.addAtEnd(3);
	myList.addAtEnd(3);
	myList.addAtEnd(2);
	myList.addAtEnd(1);
	myList.printList();
	Console.WriteLine("Palindrome = " + myList.Palindrome());
	//myList.deleteFirstInstancesOf(1);
	myList.deleteAllInstancesOf(1);
	myList.printList();
	Console.WriteLine("n to last element = " + myList.FindNtoLast(5));
	Console.WriteLine();

	LinkedList myList2 = new LinkedList();
	myList2.addAtStart(4);
	myList2.addAtStart(5);
	myList2.addAtStart(1);
	myList2.addAtStart(2);
	myList2.addAtStart(6);
	myList2.addAtStart(3);
	myList2.printList();
	myList2.PrintReversedList();
	Node secondHalf = myList2.divideListInTwoHalves();
	LinkedList myList4 = new LinkedList(secondHalf);
	myList2.printList();
	myList4.printList();
	Console.WriteLine();
	
	myList2.printList();
	Console.WriteLine("n to last element = " + myList2.FindNtoLast(2));
	Console.WriteLine();

	myList2.printList();
	myList2.reverseList();
	myList2.printList();
	Console.WriteLine();

	myList2.deleteAllInstancesOf(1);
	myList2.printList();

	myList2.reverseList();
	myList2.printList();
	Console.WriteLine();
	
	LinkedList myList3 = new LinkedList();
	myList3.printList();
	Console.WriteLine("n to last element = " + myList3.FindNtoLast(3));
}

// LinkList - May 25th, 2017
// Assuming that head contains the first element
//  Head   Node2  Node3
//  1 -->  2 -->  3 -->

class Node
{
	public int value { get; set; }
	public Node next { get; set; }

	public Node() { }

	public Node(int value)
	{
		this.value = value;
		next = null;
	}
}

class LinkedList
{
	Node head;

	public LinkedList() { }
	public LinkedList(Node head)
	{
		this.head = head;
	}

	public void addAtEnd(int value)
	{
		Node toAdd = new Node(value);

		if (head == null)
		{
			head = toAdd;
		}
		else
		{
			Node curr = head;
			while (curr.next != null)
			{
				curr = curr.next;
			}
			curr.next = toAdd;
		}
	}

	public void addAtStart(int value)
	{
		Node toAdd = new Node(value);
		if (head == null)
		{
			head = toAdd;
		}
		else
		{
			toAdd.next = head;
			head = toAdd;
		}
	}

	// Given a linked list, write a function that prints the nodes of the list in reverse order
	// eg. printReversedList() of 1 --> 2 --> 3 --> null
	// null <-- 3 <-- 2 <-- 1
	public void PrintReversedList()
	{
		PrintHelper(head);
		Console.WriteLine();
	}

	private void PrintHelper(Node curr)
	{
		if (curr == null)
		{
			Console.Write("null");
			return;
		}
		PrintHelper(curr.next);
		Console.Write(" <-- " + curr.value);
	}

	// Given a linked list, write a function to determine whether
	// the list is a palindrome. eg
	// palindrome(1 -> 2 -> 3) = false
	// palindrome(1 -> 2 -> 1) = true
	public bool Palindrome()
	{
		if(head == null) return false;     			// empty
		else if (head.next == null) return true;    // one-node
		else if (head.next.next == null)			// two-node
		{
			if(head.value == head.next.value) return true;   
		}
		else
		{
			List<int> values = new List<int>();
			Node prev = head;
			Node curr = head.next;
			bool increasing, stillIncreasing;

			if (prev.value < curr.value)
			{
				increasing = true;
				stillIncreasing = true;
			}
			else
			{
				increasing = false;
				stillIncreasing = false;
			}

			while (curr.next != null)
			{
				values.Add(prev.value);
				curr = curr.next;
				prev = prev.next;
				
				if(prev.value < curr.value) increasing = true;
				else if (prev.value > curr.value) increasing = false;
				else
				{
					if(increasing) increasing = false;
					else increasing = true;
				}

				if (increasing != stillIncreasing)
				{
					if (prev.value == curr.value)
					{
						curr = curr.next;
					}
					for (int i = values.Count - 1; i >= 0; i--)
					{
						if (curr == null) return false;	// too short at the right end
						if (curr.value != values[i]) return false;
						curr = curr.next;
					}
					if(curr != null) return false;		// too long at the right end
					return true;
				}
			}
		}
		
		return false;
	}

	// Given a linked list, write a function that divides it into 
	// two halves. This funciton should modify the original list 
	// and then return a pointer to the second half of the list.
	public Node divideListInTwoHalves()
	{
		if (head == null)
		{
			Console.WriteLine("Couldn't divide in two. List was empty.");
		}
		else if(head.next == null)
		{
			Console.WriteLine("Couldn't divide in two. List contains only one node.");
		}
		else
		{
			Node curr = head.next;
			Node half = head;
			bool moveHalf = false;
			while (curr != null)
			{
				curr = curr.next;
				if (moveHalf)
				{
					half = half.next;
					moveHalf = false;
				}
				else
				{
					moveHalf = true;
				}
			}
			Node toReturn = half.next;
			half.next = null;
			return toReturn;
		}
		return null;
	}

	public void reverseList()
	{
		Node left = head;
		Node flip = null;
		Node right = null;

		// empty list
		if (head == null)
		{
			Console.WriteLine("Couldn't reverse. List was empty");
		}
		else
		{
			flip = head.next;

			// List with one node
			if (flip == null)
			{
				return;
			}
			else
			{
				right = flip.next;

				// List with two nodes
				if (right == null)
				{
					head = flip;
					head.next = left;
					left.next = null;
				}
				else
				{
					// Makes that tail.next = null
					// In list with 3+ nodes
					flip.next = left;
					left.next = null;

					while (right != null)
					{
						// Reposition the pointers
						left = flip;
						flip = right;
						right = right.next;

						flip.next = left;
					}
					head = flip;
				}
			}
		}
	}

	public void deleteAllInstancesOf(int value)
	{
		if (head == null)
		{
			Console.WriteLine("Couldn't delete. List was empty");
		}
		else
		{
			while (head != null && head.value == value)
			{
				head = head.next;
			}

			if (head != null)
			{
				Node curr = head.next;
				Node prev = head;
				while (curr != null)
				{
					if (curr.value == value)
					{
						prev.next = curr.next;
						curr = curr.next;
					}
					else
					{
						prev = curr;
						curr = curr.next;
					}
				}
			}
		}
	}

	public void deleteAllInstancesOf_2(int value)
	{
		Node curr = head;
		Node prev = null;
		if (curr == null)
		{
			Console.WriteLine("Couldn't delete. List was empty");
		}
		else
		{
			do
			{
				if (curr.value == value)
				{
					if (prev != null)
					{
						prev.next = curr.next;
					}
					else
					{
						head = curr.next;
					}
					curr = curr.next;
				}
				else
				{
					prev = curr;
					curr = curr.next;
				}
			} while (curr != null);
		}
	}

	public void deleteFirstInstancesOf(int value)
	{
		if (head == null)
		{
			Console.WriteLine("Couldn't delete. List was empty");
		}
		else if (head.value == value)
		{
			head = head.next;
		}
		else
		{
			Node curr = head.next;
			Node prev = head;
			while (curr != null)
			{
				if (curr.value == value)
				{
					prev.next = curr.next;
					return;
				}
				else
				{
					prev = curr;
					curr = curr.next;
				}
			}
		}
	}

	public void printList()
	{
		if (head == null)
		{
			Console.WriteLine("Couldn't print. Linked List is empty");
		}
		else
		{
			Node curr = head;
			while (curr != null)
			{
				Console.Write(curr.value + " --> ");
				curr = curr.next;
			}
			Console.WriteLine("null");
		}
	}
	
	public int FindNtoLast(int n)
	{
		int foundValue = Int32.MaxValue;
		if (head == null)
		{
			Console.WriteLine("Couldn't find n-To-Last, Linked list is empty");
			return Int32.MaxValue;
		}
		else
		{
			int visitedNodes = 0;
			Node nToLast = head;
			Node last = head;
			while (last.next != null)
			{
				if (visitedNodes < n)
				{
					last = last.next;
					visitedNodes++;
				}
				else
				{
					last = last.next;
					nToLast = nToLast.next;
				}
			}

			if (visitedNodes == n)
			{
				foundValue = nToLast.value;
			}
		}
		if (foundValue == Int32.MaxValue)
		{
			Console.WriteLine("Linked list is smaller than " + n);
		}
		return foundValue;
	}
}