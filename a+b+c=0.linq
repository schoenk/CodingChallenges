<Query Kind="Program" />

// Given a list of integers, write a function that returns all sets
// of 3 numbers in the list, a, b, and c, so that a + b + c = 0.
// eg. ThreeSum({-1, 0, 1, 2, -1, -4})
// [-1, -1, 2]
// [-1,  0, 1]

void Main()
{
	int[] info = new int[]{-1, 0, 1, 2, -1, -4, -1};
	List<int[]> answer = new List<int[]>();
	answer = ThreeSum(info);
	answer.Dump();

	List<int[]> ThreeSum(int[] data)
	{
		List<int[]> results = new List<int[]>();
		
		if (data.Length < 3)
		{
			Console.WriteLine("Couldn't find (a + b + c = 0). List of integers is too small");
		}
		else
		{
			Array.Sort(data);
			data.Dump();
			int a = 0;
			int left = 1;
			int right = data.Length - 1;
			int prevLeft = Int32.MinValue;
			int prevRight = Int32.MaxValue;

			while (a < data.Length - 3)
			{
				if (a == 0 || data[a] > data[a - 1])
				{
					while (left < right)
					{
						if (data[a] + data[left] + data[right] == 0)
						{
							if (prevLeft == data[left])
							{
								left++;
							}
							else if (prevRight == data[right])
							{
								right--;
							}
							else
							{
								int[] setToAdd = new int[] { data[a], data[left], data[right] };
								results.Add(setToAdd);
								prevLeft = data[left];
								prevRight = data[right];
								left++;
							}
						}
						else if (data[left] + data[right] < data[a] * -1)
						{
							left++;
						}
						else if (data[left] + data[right] > data[a] * -1)
						{
							right--;
						}
					}
				}
				a++;
				left = a + 1;
				right = data.Length - 1;
			}
		}
		
		return results;
	}
}