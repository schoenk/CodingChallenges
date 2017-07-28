<Query Kind="Program" />

// Given a node N, connected graph, find all sets of nodes that are connected to N and also to each other.

// (input)
// N->N1, N2, N3, N4 and N5
// N1->N2
// N3->N4
// N5->

// note: N1 to N5 could be connected to others nodes that are not connected to N

// 3 sets(output)
// { N1, N2}
// { N3, N4}
// { N5}

class DirectedGraph
{
	public List<Node> graphNodes { get; set;}
	
	public DirectedGraph()
	{
		graphNodes = new List<Node>();
	}
	
	public void AddNode(Node node)
	{
		graphNodes.Add(node);
	}
	
	public bool AddConnection(int from, int to)
	{
		int index = FoundIndexOf(from);
		if (index >= 0)
		{
			graphNodes[FoundIndexOf(from)].adjList.Add(to);
			return true;
		}
		return false;
	}

	public Answer FindSets(Node n)
	{
		Answer toReturn = new Answer();

		// < outNode, isPartOfaSet >
		Dictionary<int, bool> nConnections = new Dictionary<int, bool>();
		foreach (int node in n.adjList)
		{
			nConnections.Add(node, false);
		}
		foreach (int outNode in n.adjList)
		{
			List<int> set = new List<int>();
			set.Add(outNode);
			IsASet(outNode, nConnections, set);
			
			// if the set didn't start at nodeName: 1 then
			// this appends the rest of the set to the first set
			if (toReturn.sets.Count > 0 && set[set.Count - 1] == toReturn.sets[0][0])
			{
				// it doesn't add the last element in set as this is a duplicate
				for (int i = 0; i < set.Count - 1; i++)
				{
					toReturn.sets[0].Add(set[i]);
				}
			}
			else if (nConnections[outNode] == false)
			{
				toReturn.numbOfSets++;
				toReturn.sets.Add(set);
			}
		}
		if (toReturn.numbOfSets == 0)
		{
			bool allVisited = true;
			foreach (bool isPartOfaSet in nConnections.Values)
			{
				if(isPartOfaSet == false) allVisited = false;
			}
			if (allVisited == true)
			{
				toReturn.numbOfSets++;
				toReturn.sets.Add(n.adjList);
			}
		}
		return toReturn;
	}

	public void IsASet(int outNode, Dictionary<int, bool> nConnections, List<int> set)
	{
		int index = FoundIndexOf(outNode);
		if (index >= 0)
		{
			List<int> outNodeList = graphNodes[index].adjList;
			for (int i = 0; i < outNodeList.Count; i++)
			{
				if (nConnections.ContainsKey(outNodeList[i]) && nConnections[outNodeList[i]] == false)
				{
					nConnections[outNodeList[i]] = true;
					set.Add(outNodeList[i]);
					IsASet(outNodeList[i], nConnections, set);
				}
			}
		}
	}	

	// If nodeName is not found in graph it returns -1
	public int FoundIndexOf(int nodeName)
	{
		if (graphNodes.Count > 0)
		{
			for (int i = 0; i < graphNodes.Count(); i++)
			{
				if (graphNodes[i].nodeName == nodeName) return i;
			}
		}
		return -1;
	}
}

public class Node
{
	public int nodeName { get; set; }
	public List<int> adjList { get; set;}
	
	public Node()
	{
		adjList = new List<int>();
	}
	
	public Node(int n)
	{
		nodeName = n;
		adjList = new List<int>();
	}
	
	// Directed graphs are one-way edges
	public void addRangeToAdjList(int[] bNode)
	{
		foreach (int i in bNode)
		{
			adjList.Add(i);
		}
	}
}

class Answer
{ 
	public int numbOfSets;
	public List<List<int>> sets;
	
	public Answer()
	{
		sets = new List<List<int>>();
	}
}

void Main()
{
	DirectedGraph myGraph = new DirectedGraph();
	Node n = new Node(0);
	int[] nodesFor0 = new int[] { 1, 2, 3, 4, 5 };
	n.addRangeToAdjList(nodesFor0);

	Node n1 = new Node(1);
	int[] nodesFor1 = new int[] { 2 };
	n1.addRangeToAdjList(nodesFor1);

	Node n2 = new Node(2);
	int[] nodesFor2 = new int[] { 3 };
	n2.addRangeToAdjList(nodesFor2);

	Node n3 = new Node(3);
	int[] nodesFor3 = new int[] { 4 };
	n3.addRangeToAdjList(nodesFor3);

	Node n4 = new Node(4);
	int[] nodesFor4 = new int[] { 5 };
	n4.addRangeToAdjList(nodesFor4);

	Node n5 = new Node(5);
	n5.adjList.Add(1);
	
	myGraph.AddNode(n);
	myGraph.AddNode(n1);
	myGraph.AddNode(n2);
	myGraph.AddNode(n3);
	myGraph.AddNode(n4);
	myGraph.AddNode(n5);
	myGraph.Dump();

	Answer myAnswer = new Answer();
	myAnswer = myGraph.FindSets(n);
	myAnswer.Dump();
}

