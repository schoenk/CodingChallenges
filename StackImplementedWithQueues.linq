<Query Kind="Program" />

// Implement a stack with basic functionality (push and pop) using
// queues to store the data

void Main()
{
	Stack mystack = new Stack();
	mystack.push(1);
	mystack.print();
	mystack.push(2);
	mystack.print();
	mystack.push(3);
	mystack.print();
	mystack.pop();
	mystack.print();
}

class Stack
{ 
	private Queue<int> primary;
	private Queue<int> secondary;
	private int size;
	
	public Stack()
	{
		size = 0;
		primary = new Queue<int>();
		secondary = new Queue<int>();
	}
	
	public void push(int n)
	{
		if (primary.Count == 0)
		{
			secondary.Enqueue(n);
		}
		else
		{
			primary.Enqueue(n);
		}
		size++;
	}

	public int pop()
	{
		if (size != 0)
		{
			if (primary.Count == 0)
			{
				while (secondary.Count > 1)
				{
					primary.Enqueue(secondary.Dequeue());
				}
				return secondary.Dequeue();
			}
			else
			{
				while (primary.Count > 1)
				{
					secondary.Enqueue(primary.Dequeue());
				}
				return primary.Dequeue();
			}
		}
		return -1;
	}

	public void print()
	{
		int[] stack1 = primary.ToArray();
		int[] stack2 = secondary.ToArray();
		
		Console.WriteLine("primary :");
		foreach (int n in stack1)
		{
			Console.WriteLine(n);
		}
		Console.WriteLine("Secondary :");
		foreach (int n in stack2)
		{
			Console.WriteLine(n);
		}
	}
}