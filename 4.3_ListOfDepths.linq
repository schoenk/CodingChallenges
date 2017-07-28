<Query Kind="Program" />

// 4.3 LIST OF DEPTHS: Given a binary tree, design an algorithm which creates
// a linked list of all the node at each depth (e.g., if you have a tree with
// depth D, you'll have D linked lists). 

class Node
{
	public int value { get; set; }
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

	public BST() 
	{
		root = new Node();
		count = 0;
	}
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
	
	public Dictionary<int, LinkedList<int>> ListOfDepths()
	{
		Dictionary<int, LinkedList<int>> results = new Dictionary<int, LinkedList<int>>();
		if(root == null) return null;
		LinkedList<int> level0List = new LinkedList<int>();
		results.Add(0, level0List);
		ListOfDepthsHelper(root, 0, results);
		
		return results;
	}

	public void ListOfDepthsHelper(Node n, int level, Dictionary<int, LinkedList<int>> list)
	{
		if(n == null) return;
		list[level].AddLast(n.value);
		LinkedList<int> nextLevel = new LinkedList<int>();
		if (!list.ContainsKey(level + 1))
		{
			list.Add(level + 1, nextLevel);
		}
		ListOfDepthsHelper(n.left, level + 1, list);
		ListOfDepthsHelper(n.right, level + 1, list);
	}
}

void Main()
{
	int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
	BST myTree = new BST(elements);
	myTree.Dump();
	
	Dictionary<int, LinkedList<int>> result = myTree.ListOfDepths();
	result.Dump();
}
