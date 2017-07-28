<Query Kind="Program" />

class Node
{
	public int value { get; set;}
	public Node left { get; set;}
	public Node right { get; set;}

	public Node() {}
	
	public Node(int n)
	{
		value = n;
		left = null;
		right = null;
	}
}

class BinaryTree
{ 
	Node root { get; set;}
	int count { get; set;}
	
	public BinaryTree()
	{
		root = null;
		count = 0;
	}

	// Given a binary tree, write a function to test if the tree
	// is a binary search tree.
	public bool isBST()
	{
		return isBST(root, Int32.MinValue, Int32.MaxValue);
	}
	
	public bool isBST(Node n, int min, int max)
	{
		if (n == null)
		{
			return true;
		}
		if(n.value < min || n.value > max) return false;
		return isBST(n.left, min, n.value) && isBST(n.right, n.value + 1 , max);
	}
}