<Query Kind="Program" />

void Main()
{
	List<List<int>> list = new List<List<int>>
	{
		new List<int>{1, 2, 3},
		new List<int>{4, 5},
		new List<int>{6, 7, 8} };
		
	//PrintAllCombinations(list);
	PrintConvinationsRecursive(list);

	void PrintAllCombinations(List<List<int>> hints)
	{		
		for (int one = 0; one < hints[0].Count; one++)
		{
			for (int two = 0; two < hints[1].Count; two++)
			{
				for (int three = 0; three < hints[2].Count; three++)
				{
					Console.Write(hints[0][one]);
					Console.Write(hints[1][two]);
					Console.WriteLine(hints[2][three]);
				}
			}
		}
	}

	void PrintConvinationsRecursive(List<List<int>> hints)
	{
		if (hints.Count == 0)
		{
			Console.WriteLine("List of hints is empty");
		}
		else 
		{
			PrintConvinationsHelper(hints, 0, 0, 0);
		}
	}

	void PrintConvinationsHelper(List<List<int>> hints, int index0, int index1, int index2)
	{
		if (index0 < hints[0].Count && index1 < hints[1].Count && index2 < hints[2].Count)
		{
			Console.Write(hints[0][index0]);
			Console.Write(hints[1][index1]);
			Console.WriteLine(hints[2][index2]);
		}

		if (index2 >= hints[2].Count - 1)
		{
			if (index1 >= hints[1].Count - 1)
			{
				if (index0 >= hints[0].Count - 1)
				{
					return;
				}
				else
				{
					PrintConvinationsHelper(hints, index0 + 1, 0, 0);
				}
			}
			else
			{
				PrintConvinationsHelper(hints, index0, index1 + 1, 0);
			}
		}
		else
		{
			PrintConvinationsHelper(hints, index0, index1, index2 + 1);
		}
	}
}
