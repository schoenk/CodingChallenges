<Query Kind="Program" />

// 4.2 MINIMAL TREE: Given a sorted (increasing order) array with unique integer
// elements, write an algorithm to create a binary search treee with minimal height.

class Node
{
	int value { get; set; }
	public Node left { get; set; }
	public Node right { get; set; }

	public Node() { }

	public Node(int n)
	{
		value = n;
		left = null;
		right = null;
	}
}

class BST
{
	public Node root { get; set; }
	public int count { get; set; }

	public BST() {}
	public BST(int[] data)
	{
		root = new Node();
		root = MinimalTree(data);
	}

	public Node MinimalTree(int[] data)
	{
			count = 0;
			return MinimalTreeHelper(data, 0, data.Length - 1);
	}

	public Node MinimalTreeHelper(int[] data, int start, int end)
	{
		if (end < start) return null;
		
		int rootNum = (start + end) / 2;
		Node root = new Node(data[rootNum]);
		count++;
		root.left = MinimalTreeHelper(data, start, rootNum - 1);
		root.right = MinimalTreeHelper(data, rootNum + 1, end);
		return root;
	}
}

void Main()
{
	int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
	BST myTree = new BST(elements);
	myTree.Dump();
}