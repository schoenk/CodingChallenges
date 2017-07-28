<Query Kind="Program" />

void Main()
{
	int[] array1 = new int[]{10, 5, 2, 7, 4, 9, 12, 1, 8, 6, 11, 3};
	array1.Dump();
	MergeSort(array1);
	array1.Dump();

	void MergeSort(int[] sequence)
	{
		int[] sorted = new int[sequence.Length];
		MergeSortHelper(sorted, sequence, 0, sequence.Length -1);
	}

	void MergeSortHelper(int[] sorted, int[] sequence, int left, int right)
	{
		if (left >= right)
		{
			return;
		}
		
		int midIndex = (left + right) / 2;
		MergeSortHelper(sorted, sequence, left, midIndex);
		MergeSortHelper(sorted, sequence, midIndex + 1, right);
		
		Merge(sorted, sequence, left, right);
	}

	void Merge(int[] temp, int[] array, int leftStart, int rightEnd)
	{
		int leftEnd = (leftStart + rightEnd) / 2;
		int rightStart = leftEnd + 1;
		int size = rightEnd - leftStart + 1;
		
		int left = leftStart;
		int right = rightStart;
		int index = leftStart;

		// This may leave the right or left side with remaining larger 
		// numbers. That we would later copy to the array
		while (left <= leftEnd && right <= rightEnd)
		{
			if (array[left] <= array[right])
			{
				temp[index] = array[left];
				left++;
			}
			else
			{
				temp[index] = array[right];
				right++;
			}
			index++;
		}
		
		// if there were leftover remaining larger numbers in on of the arrays,
		// this will copy those numbers from the array to the temp.
		Array.Copy(array, left, temp, index, leftEnd - left + 1);
		Array.Copy(array, right, temp, index, rightEnd - right + 1);
		
		// Then, we copied what we just sort from temp to array
		Array.Copy(temp, leftStart, array, leftStart, size);
	}
}
