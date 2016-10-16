public class PartitionEqualSubsetSum {
	public boolean canPartition(int[] nums) {
		int sum = 0;
		for (int n : nums)
			sum += n;
		return 0 == (sum & 1) && helper(nums, 0, (sum >> 1));
	}

	private boolean helper(int[] nums, int begin, int target) {
		if (target <= 0 || begin >= nums.length)
			return 0 == target;
		return helper(nums, begin + 1, target - nums[begin]) || helper(nums, begin + 1, target);
	}
}
