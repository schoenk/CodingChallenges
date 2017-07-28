<Query Kind="Program" />

// Given 2 sorted arrays, A and B, where A is long enough to hold the
// contents of A and B, write a function to copy the contents of B
// into A without using any buffer or additional memory.
// both are sorted and we are going to merge one of them into the other
// without using sort of external buffers or temporary variables or 
// things like that.

// eg. A = {1, 3, 5, 0, 0, 0}
//     B = {2, 4, 6}
// {1, 2, 3, 4, 5, 6}

void Main()
{
	int[] one = new int[] { 1, 3, 5, 0, 0, 0 };
	int[] two = new int[] { 2, 4, 6};
	one.Dump();
	MergeArrays(one, two);
	one.Dump();
	
	// one is the longer one with space for other elements
	// it starts at the end of array and compare the last 2 elements
	void MergeArrays(int[] a, int[] b)
	{
		if(a.Length == 0 || b.Length == 0) return;
		
		int endArray = a.Length - 1;
		int bCurr = b.Length - 1;
		int aCurr = a.Length - b.Length - 1;

		while (bCurr >= 0)
		{
			if (aCurr < 0 || b[bCurr] > a[aCurr])
			{
				a[endArray] = b[bCurr];
				bCurr--;
			}
			else
			{
				a[endArray] = a[aCurr];
				aCurr--;
			}
			endArray--;
		}
	}
}