<Query Kind="Program" />

// QuickSort Algorithm - May 26th, 2017
void Main()
{
	int[] array1 = new int[] { 15, 3, 9, 8, 5, 2, 7, 1, 6};
	array1.Dump();
	QuickSort(array1);  // when I pass it, I modify it, right?
	    // or I'm creating a brand new copy. so that I need to return the
		// modify array at the end?
	array1.Dump();

	void QuickSort(int[] sequence)
	{
		QuickSortHelper(sequence, 0, sequence.Length - 1);
	}
	
	void QuickSortHelper(int[] sequence, int leftIndex, int rightIndex)
	{
		if(leftIndex >= rightIndex) return;
		
		int pivot = sequence[(leftIndex + rightIndex) / 2];
		int startOfLeft = leftIndex;
		int startOfright = rightIndex;

		while (leftIndex <= rightIndex)
		{
			while (sequence[leftIndex] < pivot)
			{
				leftIndex++;
			}
			while (sequence[rightIndex] > pivot)
			{
				rightIndex--;
			}

			if (leftIndex < rightIndex)
			{
				int toSwap = sequence[leftIndex];
				sequence[leftIndex] = sequence[rightIndex];
				sequence[rightIndex] = toSwap;
				leftIndex++;
				rightIndex--;
			}
		}
		QuickSortHelper(sequence, startOfLeft, leftIndex - 1);
		QuickSortHelper(sequence, rightIndex + 1, startOfright);
	}
}