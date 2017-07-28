<Query Kind="Program" />

// Output numbers from 1 to n. If the number is deivisible by 3,
// replace it with "Fizz". If it is divisible by 5, replace it with
// "Buzz". If it is divisible by 3 and 5 replace it with "FizzBuzz".

	void Main()
	{
		FizzBuzz(16);

		void FizzBuzz(int n)
		{
			if (n < 1 || n > 100)
			{
				return;
			}
			else
			{
				for (int i = 1; i <= n; i++)
				{
					if (i % 3 != 0 && i % 5 != 0)
					{
						Console.Write(i);
					}
					else
					{
						if (i % 3 == 0)
						{
							Console.Write("Fizz");
						}
						if (i % 5 == 0)
						{
							Console.Write("Buzz");
						}
					}
					Console.WriteLine();
				}
			}
		}
	}