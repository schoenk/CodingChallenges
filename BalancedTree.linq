<Query Kind="Program" />

// Given a binary tree, write a function to determine wheter the 
// tree is balanced.

class Node
{
	public int value { get; set;}
	public Node left { get; set;}
	public Node right { get; set;}
	
	public Node(int value)
	{
		this.value = value;
		left = null;
		right = null;
	}
}

class BalancedTree
{
	Node root;
	int count;
	
	BalancedTree()
	{
		root = null;
		count = 0;
	}
	
	bool IsBalancedTree()
	{
		if(NodeHeight(root) > -1) return true;
		return false;
	}

	int NodeHeight(Node root)
	{
		if (root == null) return 0;
		
		int h1 = NodeHeight(root.left);
		int h2 = NodeHeight(root.right);
			
		if (h1 == -1 || h2 == -1) return -1;
		if (Math.Abs(h1 - h2) > 1) return -1;
		if (h1 > h2) return h1 + 1;
		return h2 + 1;
	}
}