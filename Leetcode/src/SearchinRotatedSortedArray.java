
public class SearchinRotatedSortedArray {
	public static void main(String[] args) {
		SearchinRotatedSortedArray a = new SearchinRotatedSortedArray();
		System.out.println(a.search(new int[] { 1, 3, 5 }, 3));
	}

	public int search(int[] nums, int target) {
		if (nums.length == 0)
			return -1;
		int i = 1;
		while (i < nums.length - 1 && nums[i - 1] < nums[i]) {
			i++;
		}
		int firstResult = binarySearch(0, i - 1, nums, target);
		if (firstResult != -1)
			return firstResult;
		return binarySearch(i, nums.length - 1, nums, target);
	}

	private int binarySearch(int start, int end, int[] array, int target) {
		if (start > end)
			return -1;
		int mid = (start + end) / 2;
		if (array[mid] == target)
			return mid;
		if (array[mid] < target)
			return binarySearch(mid + 1, end, array, target);
		return binarySearch(start, mid - 1, array, target);
	}
}
