import java.util.Arrays;

public class SortColors_QuickSort {

	public static void main(String[] args) {
		int[] a = new int[] { 5, 8, 6, 1, 0, 565, 54, 84, 0, 232, 56, 56, 56, 56, 12, 1, 21, 2 };
		SortColors_QuickSort sc = new SortColors_QuickSort();
		for (int i : sc.quickSort(a, a.length / 2)) {
			System.out.print(i + " ");
		}
	}

	public void sortColors(int[] nums) {

		quickSort(nums, nums.length / 2);
	}

	private int[] quickSort(int[] array, int pivotIndex) {
		int length = array.length;
		if (length < 2)
			return array;
		int pivot = array[pivotIndex];
		int[] a = new int[length];
		int[] b = new int[length];
		int f = 0, l = 0;
		for (int i = 0; i < length; i++) {
			if (i != pivotIndex) {
				if (array[i] <= pivot) {

					a[f] = array[i];
					f++;
				} else {
					b[l] = array[i];
					l++;
				}
			}
		}

		a = quickSort(Arrays.copyOf(a, f), f / 2);
		b = quickSort(Arrays.copyOf(b, l), l / 2);
		int i = 0;
		for (int j = 0; j < f; j++) {
			array[i++] = a[j];
		}
		array[i++] = pivot;
		for (int j = 0; j < l; j++) {
			array[i++] = b[j];
		}
		return array;

	}
}
