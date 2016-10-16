
public class SearchinRotatedSortedArrayII {
	public boolean search(int[] nums, int target) {
		if (nums.length == 0)
			return false;
		int i = 1;
		while (i < nums.length - 1 && nums[i - 1] <= nums[i]) {
			i++;
		}
		boolean firstResult = binarySearch(0, i - 1, nums, target);
		if (firstResult)
			return firstResult;
		return binarySearch(i, nums.length - 1, nums, target);
	}

	private boolean binarySearch(int start, int end, int[] array, int target) {
		if (start > end)
			return false;
		int mid = (start + end) / 2;
		if (array[mid] == target)
			return true;
		if (array[mid] < target)
			return binarySearch(mid + 1, end, array, target);
		return binarySearch(start, mid - 1, array, target);
	}
}
