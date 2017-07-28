<Query Kind="Program" />

// 4.1 ROUTE BETWEEN NODES: Given a directed graph, design an
// algorithm to find out whether ther is a route between two nodes.

class DirectedGraph
{
	public List<Node> graphNodes { get; set;}
	
	public DirectedGraph()
	{
		graphNodes = new List<Node>();
	}

	public bool IsThereARouteBetween(int from, int to)
	{
		Queue<int> myQueue = new Queue<int>();
		myQueue.Enqueue(from);
		//return isThereARouteHelper(to, myQueue);
		return IsThereARouteHelper(from, to);
	}
	
	// Breath-first search
	public bool isThereARouteHelper(int to, Queue<int> myQueue)
	{
		while (myQueue.Count > 0)
		{
			int currNode = myQueue.Dequeue();
			if (!graphNodes[FindIndex(currNode)].visited)
			{
				graphNodes[FindIndex(currNode)].visited = true;
				if (currNode == to) return true;

				List<int> fromAdjList = graphNodes[FindIndex(currNode)].adjList;
				if (fromAdjList.Count > 0)
				{
					foreach (int nodeName in fromAdjList)
					{
						myQueue.Enqueue(nodeName);
					}
				}
			}
		}
		return false;
	}
	
	// Depth-first search
	public bool IsThereARouteHelper(int from, int to)
	{
		if (!graphNodes[FindIndex(from)].visited)
		{
			graphNodes[FindIndex(from)].visited = true;
			List<int> fromAdjList = graphNodes[FindIndex(from)].adjList;
			if (fromAdjList.Count > 0)
			{
				foreach (int nodeName in fromAdjList)
				{
					if (nodeName == to) return true;
					if (IsThereARouteHelper(nodeName, to)) return true;
				}
			}
		}
		return false;
	}

	public void AddNode(int n)
	{
		Node newNode = new Node(n);
		graphNodes.Add(newNode);
	}
	
	public void AddConnection(int from, int to)
	{
		int index = FindIndex(from);
		if (index == -1)
		{
			Node fromNode = new Node(from);
			fromNode.adjList.Add(to);
			graphNodes.Add(fromNode);
		}
		else
		{
			graphNodes[index].adjList.Add(to);
		}
	}

	public void AddRange(int from, int[] connections)
	{
		int index = FindIndex(from);
		if (index == -1)
		{
			Node fromNode = new Node(from);
			foreach (int to in connections)
			{
				fromNode.adjList.Add(to);
			}
			graphNodes.Add(fromNode);
		}
		else
		{
			foreach (int to in connections)
			{
				graphNodes[index].adjList.Add(to);
			}
		}
	}
	
	// if such nodeName isn't found, then returns -1
	public int FindIndex(int nodeName)
	{
		for (int i = 0; i < graphNodes.Count; i++)
		{
			if(graphNodes[i].nodeName == nodeName) return i;
		}
		return -1;
	}
}

class Node
{
	public int nodeName { get; set; }
	public bool visited;
	public List<int> adjList { get; set;}
	
	public Node()
	{
		visited = false;
		adjList = new List<int>();
	}
	
	public Node(int n)
	{
		nodeName = n;
		visited = false;
		adjList = new List<int>();
	}
}

void Main()
{
	DirectedGraph myGraph = new DirectedGraph();
	myGraph.AddConnection(0, 2);
	myGraph.AddNode(1);
	myGraph.AddConnection(2, 1);
	int[] nodesFor3 = new int[]{ 0, 2, 4, 5};
	myGraph.AddRange(3,nodesFor3);
	myGraph.AddNode(4);
	myGraph.AddNode(5);
	myGraph.AddConnection(6, 3);
	myGraph.Dump();


	Console.WriteLine("Is there a route from 6 to 5: " + myGraph.IsThereARouteBetween(6, 5));
	//Console.WriteLine("Is there a route from 1 to 3: " + myGraph.IsThereARouteBetween(1, 3));
	//Console.WriteLine("Is there a route from 5 to 3: " + myGraph.IsThereARouteBetween(5, 3));
	//Console.WriteLine("Is there a route from 4 to 0: " + myGraph.IsThereARouteBetween(4, 0));
	//Console.WriteLine("Is there a route from 1 to 6: " + myGraph.IsThereARouteBetween(1, 6));
	//Console.WriteLine("Is there a route from 6 to 1: " + myGraph.IsThereARouteBetween(6, 1));
	//Console.WriteLine("Is there a route from 0 to 1: " + myGraph.IsThereARouteBetween(0, 1));
	//Console.WriteLine("Is there a route from 0 to 6: " + myGraph.IsThereARouteBetween(0, 6));
}
