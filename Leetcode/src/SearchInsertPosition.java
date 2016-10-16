
public class SearchInsertPosition {
	public int searchInsert(int[] nums, int target) {

		return binarySearch(0, nums.length-1, nums, target);
	}
	private int binarySearch(int start,int end,int[] nums,int target){
		if(start>end){
			return end+1;
		}
		int mid=(start+end)/2;
		if(nums[mid]==target){
			return mid;
		}
		if(nums[mid]>target){
			return binarySearch(start,mid-1, nums, target);
		}
		return binarySearch(mid+1, end, nums, target);
	}
}
