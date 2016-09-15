import java.util.Arrays;

public class HouseRobberII {
	public static void main(String[] args) {
		HouseRobberII h = new HouseRobberII();
		int nums[] = new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
		System.out.println(h.rob(nums));
	}

	public int rob(int[] nums) {

		int[] maxes = new int[nums.length];
		Arrays.fill(maxes, -1);
		int max=Math.max(getMax(1, maxes, nums), getMax(2, maxes, nums));
		maxes = new int[nums.length];
		Arrays.fill(maxes, -1);
		if(nums.length>2)nums[nums.length-1]=0;
		return Math.max(getMax(0, maxes, nums), max);

	}

	private int getMax(int i, int[] maxes, int[] nums) {
		if (i >= nums.length)
			return 0;
		if (maxes[i] != -1)
			return maxes[i];
		maxes[i] = nums[i] + Math.max(getMax(i + 2, maxes, nums), getMax(i + 3, maxes, nums));
		return maxes[i];

	}

}
