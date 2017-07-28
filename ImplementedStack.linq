<Query Kind="Program" />

// Design a stack with a push, pop, and max function
// which returns the max value in the stack, all of
// which are run in O(1) time.

class Node
{
	public int value { get; set;} 
	public Node next { get; set;}
	public Node oldMax { get; set;}

	public Node() {}
	
	public Node(int n)
	{
		value = n;
		next = null;
		oldMax = null;
	}
}

class MaxStack
{ 
	Node stack;
	Node max;

	public MaxStack() {}

	public void Push(int n)
	{
		Node toAdd = new Node(n);
		
		if (stack == null)
		{
			stack = toAdd;
			max = toAdd;
		}
		else
		{
			toAdd.next = stack;
			stack = toAdd;
			if (max == null || toAdd.value > max.value)
			{
				toAdd.oldMax = max;
				max = toAdd;
			}
		}
	}

	public int Pop()
	{
		if (stack == null)
		{
			throw new NullReferenceException();
		}

		if (stack == max)
		{
			max = max.oldMax;
		}
		
		int valToReturn = stack.value;
		stack = stack.next;
		return valToReturn;
	}
	
	public int Max()
	{
		if (stack == null)
		{
			throw new NullReferenceException();
		}
		return max.value;
	}

	public void PrintStack()
	{
		if (stack == null)
		{
			Console.WriteLine("Couldn't print. Linked List is empty");
		}
		else
		{
			Node curr = stack;
			while (curr != null)
			{
				Console.Write(curr.value + " --> ");
				curr = curr.next;
			}
			Console.WriteLine("null");
			Console.WriteLine("Max = " + max.value);
			Console.WriteLine();
		}
	}
}

void Main()
{
	MaxStack myStack = new MaxStack();
	myStack.Push(1);
	myStack.Push(2);
	myStack.Push(3);
	myStack.PrintStack();
	myStack.Pop();
	myStack.Pop();
	myStack.PrintStack();
	myStack.Pop();
	myStack.PrintStack();
	myStack.Push(0);
	myStack.Push(1);
	myStack.PrintStack();
	
	myStack.Pop();
	myStack.PrintStack();
}