
public class MaximumSubarray {
	public static void main(String[] args) {
		MaximumSubarray m = new MaximumSubarray();
		System.out.println(m.maxSubArray(new int[] { -2, -1 }));
	}

	public int maxSubArray(int[] nums) {

		int max = nums[0];
		int lastSum = nums[0];
		for (int i = 1; i < nums.length; i++) {
			lastSum = Math.max( nums[i],  nums[i] + lastSum);
			max=Math.max(max, lastSum);
		}
		return max;

	}
}
