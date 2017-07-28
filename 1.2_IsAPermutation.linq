<Query Kind="Program" />

// Given two strings, write a method to decide if one is a
// permutation of the other

void Main()
{
	string one = "jhu.66.";
	string two = ".h6ju6.";
	
	Console.WriteLine(IsAPermutation(one, two));
	Console.WriteLine(IsAPermutation2(one, two));

	bool IsAPermutation(string first, string second)	// O(n*a) where a is the alphabet length
	{
		if(first.Length != second.Length) return false;

		int[] alphabet = new int[256];
		for (int i = 0; i < first.Length; i++)
		{
			alphabet[(int)first[i]]++;
			alphabet[(int)second[i]]--;
		}
		
		for (int i = 0; i < alphabet.Length; i++)
		{
			if(alphabet[i] != 0) return false;
		}
		return true;
	}

	bool IsAPermutation2(string first, string second)	// O(n log n)
	{
		if(first.Length != second.Length) return false;
		
		char[] sample1 = first.ToCharArray();
		char[] sample2 = second.ToCharArray();
		Array.Sort(sample1);
		Array.Sort(sample2);
		sample1.Dump();
		sample2.Dump();
		for (int i = 0; i < first.Length; i++)
		{
			if(sample1[i] != sample2[i]) return false;
		}
		return true;
	}
}
