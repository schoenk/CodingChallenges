<Query Kind="Program" />

// Making Change: Given an input x, write a function to
// determine the minimum number of coins required to make
// that exact amount of change.

void Main()
{
	int total = 32;
	int[] memo = new int[total];
	for (int i = 0; i < total; i++)
	{
		memo[i] = -1;
	}
	
	int[] americanCoins = new int[]{ 1, 5, 10, 25};
	int[] marteCoins = new int[]{1, 3, 4};
	Console.WriteLine(FindChangeOf(total, americanCoins));
	Console.WriteLine(FindChangeOfOptimal(total, americanCoins, memo));

	int FindChangeOf(int amount, int[] coins)
	{
		if (amount == 0)
		{
			return 0;
		}
		
		// = amount if all coins are $1
		int minCoinCount = amount;
		
		// find the number of coins I can get by taking
		// the path of substracting each coin in the array
		for (int i = 0; i < coins.Length; i++)
		{
			// Go ahead only if coin is < than the amount
			if (amount - coins[i] >= 0)
			{
				// Find how many coins I will get to then compare it
				// with the minimum up there before the for loop
				int numOfCoins = FindChangeOf(amount - coins[i], coins);
				if (minCoinCount > numOfCoins + 1)
				{
					minCoinCount = numOfCoins + 1;
				}
			}
		}
		return minCoinCount;
	}
	
	// Array memory would be of size "amount" since it would store the 
	// minCoinCount for each amount < amount. Ex. 32 would store the 
	// min of 32, 31, 30, 29...10, 9, 8...3, 2, 1.
	// So that we don't compute them again, but instead just retrieve them.
	int FindChangeOfOptimal(int amount, int[] coins, int[] memory)
	{
		if (amount == 0)
		{
			return 0;
		}

		// = amount if all coins are $1
		int minCoinCount = amount;

		// find the number of coins I can get by taking
		// the path of substracting each coin in the array
		for (int i = 0; i < coins.Length; i++)
		{
			// Go ahead only if coin is < than the amount
			if (amount - coins[i] >= 0)
			{
				// Find how many coins I will get to then compare it
				// with the minimum up there before the for loop
				int numOfCoins;
				if (memory[amount - coins[i]] >= 0)
				{
					numOfCoins = memory[amount - coins[i]];
				}
				else
				{
					numOfCoins = FindChangeOfOptimal(amount - coins[i], coins, memory);
					memory[amount - coins[i]] = numOfCoins;
				}
				if (minCoinCount > numOfCoins + 1)
				{
					minCoinCount = numOfCoins + 1;
				}
			}
		}
		return minCoinCount;
	}
}