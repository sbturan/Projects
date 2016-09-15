import java.util.Arrays;

public class HouseRobber {
	public int rob(int[] nums) {

		int[] maxes = new int[nums.length];
		Arrays.fill(maxes, -1);
		return Math.max(getMax(0, maxes, nums), getMax(1, maxes, nums)); 

	}

	private int getMax(int i, int[] maxes, int[] nums) {
	if (i >= nums.length)
			return 0;
		else if (i == nums.length - 1)return nums[i];
		if (maxes[i] != -1)
			return maxes[i];
		maxes[i] = nums[i] + Math.max(getMax(i + 2, maxes, nums), getMax(i + 3, maxes, nums));
		return maxes[i];

	}
	 
	 
}
