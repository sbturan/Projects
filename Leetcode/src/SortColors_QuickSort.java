public class SortColors_QuickSort {

	public static void main(String[] args) {
		int[] a = new int[] { 5, 8, 6, 1, 0, 565, 54, 84, 0, 232, 56, 56, 56, 56, 12, 1, 21, 2 };
		SortColors_QuickSort sc = new SortColors_QuickSort();
		for (int i : sc.quicksort(a, 0,a.length-1)) {
			System.out.print(i + " ");
		}
	}

	public void sortColors(int[] nums) {

		quicksort(nums,0,nums.length-1);
	}
	private int[] quicksort(int[] nums, int start, int end) {
		if (start >= end) {
			return nums;
		}
		int mid = start + (end - start) / 2;
		int pivot = choosePivot(nums[mid], nums[start], nums[end]);
		// int pivot = nums[mid];
		int i = start;
		int j = end;
		while (i <= j) {
			while (nums[i] < pivot) {
				i++;
			}
			while (nums[j] > pivot) {
				j--;
			}
			if (i <= j) {
				if (nums[i] != nums[j]) {
					swap(nums, i, j);
				}
				i++;
				j--;
			}
		}
			quicksort(nums, start, i - 1);
			quicksort(nums, i, end);
			return nums;
	}
	private int choosePivot(int a, int b, int c) {
		if (a > b) {
			if (c > a) {
				return a;
			} else if (c > b) {
				return c;
			} else {
				return b;
			}
		} else {
			if (c > b) {
				return b;
			} else if (c > a) {
				return c;
			} else {
				return a;
			}
		}
	}

	private void swap(int[] nums, int i, int j) {
		int tmp = nums[i];
		nums[i] = nums[j];
		nums[j] = tmp;
	}
	
//	private int[] quickSort(int[] array, int pivotIndex) {
//		int length = array.length;
//		if (length < 2)
//			return array;
//		int pivot = array[pivotIndex];
//		int[] a = new int[length];
//		int[] b = new int[length];
//		int f = 0, l = 0;
//		for (int i = 0; i < length; i++) {
//			if (i != pivotIndex) {
//				if (array[i] <= pivot) {
//
//					a[f] = array[i];
//					f++;
//				} else {
//					b[l] = array[i];
//					l++;
//				}
//			}
//		}
//
//		a = quickSort(Arrays.copyOf(a, f), f / 2);
//		b = quickSort(Arrays.copyOf(b, l), l / 2);
//		int i = 0;
//		for (int j = 0; j < f; j++) {
//			array[i++] = a[j];
//		}
//		array[i++] = pivot;
//		for (int j = 0; j < l; j++) {
//			array[i++] = b[j];
//		}
//		return array;
//
//	}
}
