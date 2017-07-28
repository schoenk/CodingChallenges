<Query Kind="Program" />

// Given two strings, write a function to determine whether
// they are anagrams.
// first method solves it by saving occurrence of letters in an array
// second method solves it by saving occurence of letters in a dictionary(hashTable)

void Main()
{
	string first = "cinema";
	string second = "iceman";
	Console.WriteLine(areAnagrams(first, second));

	string first2 = "anna madrigal";
	string second2 = "a girl and a man";
	Console.WriteLine(areAnagrams(first2, second2));
	Console.WriteLine();
	Console.WriteLine(areAnagramsDictionary(first, second));
	Console.WriteLine(areAnagramsDictionary(first2, second2));

	bool areAnagrams(string one, string two)
	{
		// there are 256 char in the ascii table
		int[] abcUsage = new int[256];
		one = one.ToLower();
		two = two.ToLower();

		for (int i = 0; i < one.Length; i++)
		{
			int asciiCode = one[i];
			
			// Skip spaces
			if (asciiCode != 32)
			{
				abcUsage[asciiCode]++;
			}
		}

		for (int i = 0; i < two.Length; i++)
		{
			int asciiCode = two[i];

			// Skip spaces
			if (asciiCode != 32)
			{
				abcUsage[asciiCode]--;
			}
		}

		for (int i = 0; i < abcUsage.Length; i++)
		{
			if(abcUsage[i] != 0) return false;
		}
		return true;
	}

	bool areAnagramsDictionary(string one, string two)
	{
		Dictionary<char, int> abcUsage = new Dictionary<char, int>();
		one = one.ToLower();
		two = two.ToLower();

		for (int i = 0; i < one.Length; i++)
		{
			if (one[i] != ' ')
			{
				if (!abcUsage.ContainsKey(one[i]))
				{
					abcUsage.Add(one[i], 1);
				}
				else
				{
					abcUsage[one[i]] = abcUsage[one[i]] + 1;
				}
			}
		}

		for (int i = 0; i < two.Length; i++)
		{
			if (two[i] != ' ')
			{
				if (!abcUsage.ContainsKey(two[i]))
				{
					return false;
				}
				abcUsage[two[i]] = abcUsage[two[i]] - 1;
			}
		}

		foreach (int value in abcUsage.Values)
		{
			if (value != 0)
			{
				return false;
			}
		}
		return true;
	}
}
