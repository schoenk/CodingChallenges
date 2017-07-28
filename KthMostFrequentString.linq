<Query Kind="Program" />

// Given a list of strings, write a function to find the
// kth most frequently recurring string

class Word
{
	public string word { get; set; }
	public int freq { get; set;}
	
	public Word(string word, int freq)
	{
		this.word = word;
		this.freq = freq;
	}
}

void Main()
{
	List<string> myList = new List<string>
	{
		"hello", "world", "foo", "but", "me", "two",
		"hello", "world", "foo", "but", "me",
		"hello", "world", "foo", "but",
		"hello", "world", "foo",
		"hello", "world",
		"hello"
	};
	
	KthMostFrequent(myList, 4);

	int KthMostFrequent(List<string> list, int k)
	{
		// mostfrequent at index 0
		// kth most frequent at index k-1
		Word[] freqArray = new Word[k];
		Dictionary<string, int> dictionary = new Dictionary<string, int>();

		for (int i = 0; i < list.Count; i++)
		{
			string word = list[i];
			if (!dictionary.ContainsKey(word))
			{
				dictionary.Add(word, 1);
			}
			else
			{
				dictionary[word]++;
			}
		}
		
		int iteration = dictionary.Count;
		foreach (KeyValuePair<string, int> key in dictionary.OrderBy(x => x.Value))
		{
			Console.WriteLine(key.Key + key.Value);
			if (iteration == k)
			{
				Console.WriteLine(k + "th most frequent string is: " + key.Key);
			}
			iteration--;
		}
//			int freq = dictionary[word];
//			for (int j = 0; j < freqArray.Length; j++)
//			{
//				Word toAdd = new Word(word, freq);
//				if (freqArray[j] == null)
//				{
//					freqArray[j] = toAdd;
//					break;
//				}
//				else if (freqArray[j].freq < freq && freqArray[j].word != word)
//				{
//					freqArray[j] = toAdd;
//					break;
//				}
//			}
//		}
		
		//Console.WriteLine(freqArray[k - 1].word);
		//freqArray.Dump();
		
		return 0;
	}
}