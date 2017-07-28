<Query Kind="Program" />

// 1.1 IS UNIQUE: Implement an algorithm to determine if a string
// has all unique characters. What if you cannot use additional
// data structures?

void Main()
{
	string test1 = "!abcdef1";
	Console.WriteLine(IsUnique(test1));
	Console.WriteLine(IsUniqueTwo(test1));
	Console.WriteLine(IsUniqueThree(test1));

	bool IsUnique(string word)
	{
		if(word.Length > 256) return false;
		
		HashSet<char> set = new HashSet<char>();
		for (int i = 0; i < word.Length; i++)
		{
			if (set.Contains(word[i])) return false;
			set.Add(word[i]);
		}
		return true;
	}

	bool IsUniqueTwo(string word)
	{
		if(word.Length > 256) return false;
		
		for (int curr = 0; curr < word.Length; curr++)
		{
			for (int mover = 0; mover < word.Length; mover++)
			{
				if (curr != mover)
				{
					if (word[curr] == word[mover]) return false;
				}
			}
		}
		return true;
	}

	bool IsUniqueThree(string word)
	{	
		if(word.Length > 256) return false;
		
		BitArray hasSeenLetter = new BitArray(256);

		for (int i = 0; i < word.Length; i++)
		{
			if(hasSeenLetter[(int)word[i]]) return false;
			hasSeenLetter[(int)word[i]] = true;
		}
		return true;
	}
}
