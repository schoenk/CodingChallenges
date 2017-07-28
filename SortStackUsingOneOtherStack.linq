<Query Kind="Program" />

// Given a stack, sort the elements in the stack using no more than
// one additional stack

void Main()
{
	Stack<int> myStack = new Stack<int>();
	myStack.Push(1);
	myStack.Push(2);
	myStack.Push(3);
	myStack.Push(4);
	myStack.Dump();
	
	Stack<int> sortedStack = SortStack(myStack);
	sortedStack.Dump();

	Stack<int> SortStack(Stack<int> original)
	{
		if(original == null || original.Count <= 1) return original;
		
		Stack<int> sorted = new Stack<int>();
		sorted.Push(original.Pop());	// 1st element

		while (original.Count > 0)
		{
			int temp = original.Pop();
					
					while (sorted.Count != 0 && temp > sorted.Peek())
					{
						original.Push(sorted.Pop());
					}
					sorted.Push(temp);
		}
		return sorted;
	}
}
