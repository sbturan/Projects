
public class RemoveDuplicatesfromSortedArrayII {
	public int removeDuplicates(int[] nums) {
        if(nums.length<3) return nums.length;
		int j = 0;
		int count = 0;
		int current = nums[0];
		for (int i = 0; i < nums.length - 3; i++) {
			if (current == nums[i])
				count++;
			else {
				current = nums[i];
				count = 1;
			}
			if (count > 2) {
				continue;
			}
			nums[j++]=nums[i];

		}
		
		return j;
	}
}
