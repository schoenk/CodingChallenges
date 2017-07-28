<Query Kind="Program" />

// Write a function that returns all permutations of a given list.
// eg. permutations({1, 2, 3})
// 1 2 3
// 1 3 2
// 2 1 3
// 2 3 1
// 3 1 2
// 3 2 1

void Main()
{
	string abcInfo = "abc";
	List<string> abcResult = PermutationsABC(abcInfo);
	abcResult.Dump();

	List<string> PermutationsABC(string data)
	{
		List<string> toReturn = new List<string>();
		PermutationsABCHelper("", data, toReturn);
		return toReturn;
	}

	void PermutationsABCHelper(string prefix, string suffix, List<string> results)
	{
		if (suffix.Length == 0)
		{
			results.Add(prefix);
		}
		else
		{
			for (int i = 0; i < suffix.Length; i++)
			{
				//PermutationsABCHelper(prefix + suffix[i], suffix.Substring(0, i) + suffix.Substring(i + 1, suffix.Length), results);
			}
		}
	}
	
	// harder one
	int[] info = new int[] { 1, 2, 3};
	List<int[]> result = Permutations(info);
	result.Dump();

	List<int[]> Permutations(int[] data)
	{
		List<int[]> toReturn = new List<int[]>();
		PermutationsHelper(data, 0, toReturn);
		return toReturn;
	}

	void PermutationsHelper(int[] data, int start, List<int[]> results)
	{
		if (start >= data.Length)
		{
			int[] toAdd = new int[data.Length];
			for (int k = 0; k < data.Length; k++)
			{
				toAdd[k] = data[k];
			}
			results.Add(toAdd);
		}
		else
		{
			for (int i = start; i < data.Length; i++)
			{
				Swap(data, start, i);
				PermutationsHelper(data, start + 1, results);
				Swap(data, start, i);
			}
		}
	}

	void Swap(int[] array, int i, int j)
	{
		int temp = array[i];
		array[i] = array[j];
		array[j] = temp;
	}
}