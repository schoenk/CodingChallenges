<Query Kind="Program" />

// Given a string, write a function to compress it by shortening
// every sequence of the same character to that character followed
// by the number of repetitions. If the compressed string is longer
// than the original, you should return the original string
// Ex.
// compress("a") = a
// compress("aaa") = a3
// compress("aaabbb") = a3b3
// compress("aaabccc") = a3b1c3

void Main()
{
	string wordToCompress = "banana";
	Console.WriteLine(Compress(wordToCompress));
	
	// can compress non in order strings ex. banana
	string Compress(String word)
	{
		if(word.Length <= 1) return word;
		
		string result = "";
		word = word.ToLower();
		Dictionary<char, int> abcUsage = new Dictionary<char, int>();

		for (int c = 0; c < word.Length; c++)
		{
			if (word[c] != ' ')
			{
				if (!abcUsage.ContainsKey(word[c]))
				{
					abcUsage.Add(word[c], 1);
				}
				else
				{
					abcUsage[word[c]]++;
				}
			}
		}

		foreach (char c in abcUsage.Keys)
		{
			result += c;
			
			// gets or sets the value associated with the specified key
			result += abcUsage[c];
		}

		if (word.Length < result.Length)
		{
			return word;
		}
		
		return result;
	}

	// compress only in order strings
	string Compress2(string s)
	{
		if(s.Length <= 1) return s;
		
		string result = "";
		int sum = 1;

		for (int i = 0; i < s.Length - 1; i++)
		{
			if (s[i] != ' ')
			{
				if (s[i] == s[i + 1])
				{
					sum++;
				}
				else
				{
					result = result + s[i] + sum;
					sum = 1;
				}
			}
		}
		result = result + s[s.Length - 1] + sum;

		if (s.Length < result.Length) return s;
		return result;
	}
}
