<Query Kind="Expression" />

class Node
{ 
	private int value;
	private Node left;
	private Node right;
}

class BinaryTree
{ 
	private Node root;
	private int count;
	
	public BinaryTree()
	{
		root = null;
		count = 0;
	}
	
	// In-order traversal means to visit the left branch, then the
	// current node, and finally, the right branch.
	// When performed on a binary search tree, it visits the nodes
	// in ascending order. Hence the name "in-order"
	public void printInOrderTraversal()
	{
		if (root != null)
		{
			printInOrderTraversal(root.left);
			Console.Write(root.value + " ");
			printInOrderTraversal(root.right);
		}
	}
	
	// Pre-order traversal visits the current node before its child
	// nodes. Hence the name pre-order. The root is always the first
	// node visited.
	public void printPreOrderTraversal()
	{
		if (root != null)
		{
			Console.Write(root.value + " ");
			printPreOrderTraversal(root.left + " ");
			printPreOrderTraversal(root.right + " ");
		}
	}
	
	// Post-order traversal, the root is always the last node visited
	// it visits the current node after its child nodes. Hence the name post-order.
	public void printPostOrderTraversal()
	{
		if (root != null)
		{
			printPostOrderTraversal(root.left);
			printPostOrderTraversal(root.right);
			Console.Write(root.value + " ");
		}
	}

	// Given a tree, write a function that prints out the nodes
	// of the tree in level order. eg. traverse(tree): 1 2 3 4 5 6 7
	//       1                 
	//    2     3
	//  4  5   6  7
	public void printLevelOrderRecursive()
	{
		if (root != null)
		{
			Queue<int> myQueue = new Queue<int>();
			myQueue.Enqueue(root.value);
			printLevelOrderHelper(myQueue, root);

			while (myQueue.Count != 0)
			{
				Console.Write(myQueue.Dequeue() + " ");
			}
		}
	}

	pubic void printLevelOrderHelperRecursive(Queue myQueue, Node node)
	{
		if (node.left != null)
		{
			myQueue.Enqueue(node.left.value);
		}
		if (node.right != null)
		{
			myQueue.Enqueue(node.right.value);
		}
		printLevelOrderHelper(myQueue, node.left);
		printLevelOrderHelper(myQueue, node.right);
	}
	
	public void printLevelOrder()
	{
		if (root != null)
		{
			printLevelOrderHelper(root);
		}
	}
	
	public void printLevelOrderHelper(Node root)
	{
		Queue<Node> toVisit = new Queue<Node>();
		toVisit.Enqueue(root);

		while (toVisit.Count != 0)
		{
			Node curr = toVisit.Dequeue();
			Console.Write(curr.value + " ");
			if (curr.left != null)
			{
				toVisit.Enqueue(curr.left);
			}
			if (curr.right != null)
			{
				toVisit.Enqueue(curr.right);
			}
		}
	}
}