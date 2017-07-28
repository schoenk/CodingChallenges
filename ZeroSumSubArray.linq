<Query Kind="Program" />

// Given an array, write a function to find any subarray that
// sums to zero, if one exists.
// eg. zeroSum({1, 2, -5, 1, 2, -1}) = [2, -5, 1, 2]

void Main()
{
	int[] info = new int[] { 1, 2, -5, 1, 2, -1 };
	List<List<int>> answer = ZeroSum(info);
	answer.Dump();

	List<List<int>> ZeroSum(int[] data)
	{
		if (data.Length > 0)
		{
			// 1st int = sum. 2nd int = index with that sum
			// Dictionary<sum, index>
			Dictionary<int, int> table = new Dictionary<int, int>();
			int sum = 0;
			List<List<int>> result = new List<List<int>>();
			
			for (int curr = 0; curr < data.Length; curr++)
			{
				sum += data[curr];
				if (sum == 0)
				{
					List<int> subList = new List<int>();
					for (int start = 0; start <= curr; start++)
					{
						subList.Add(data[start]);
					}
					result.Add(subList);
				}
				if (table.ContainsKey(sum))
				{
					List<int> subList = new List<int>();
					for (int start = table[sum] + 1; start <= curr; start++)
					{
						subList.Add(data[start]);
					}
					result.Add(subList);
				}
				else
				{
					table.Add(sum, curr);
				}
			}
		}
		return result;
	}
}