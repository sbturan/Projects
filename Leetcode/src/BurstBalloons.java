
public class BurstBalloons {
	public static void main(String[] args) {
		BurstBalloons b = new BurstBalloons();
		System.out.println(b.maxCoins(new int[] { 7, 9, 8, 0, 7, 1, 3, 5, 5, 2, 3, 3 }));
	}
	public int maxCoins(int[] iNums) {
	    int[] nums = new int[iNums.length + 2];
	    int n = 1;
	    for (int x : iNums) if (x > 0) nums[n++] = x;
	    nums[0] = nums[n++] = 1;


	    int[][] memo = new int[n][n];
	    return burst(memo, nums, 0, n - 1);
	}

	public int burst(int[][] memo, int[] nums, int left, int right) {
	    if (left + 1 == right) return 0;
	    if (memo[left][right] > 0) return memo[left][right];
	    int ans = 0;
	    for (int i = left + 1; i < right; ++i)
	        ans = Math.max(ans, nums[left] * nums[i] * nums[right] 
	        + burst(memo, nums, left, i) + burst(memo, nums, i, right));
	    memo[left][right] = ans;
	    return ans;
	}

//	public int maxCoins(int[] nums) {
//
//		int i = 0;
//		while (i < nums.length) {
//			if (nums[i] == 0)
//				nums[i] = -1;
//			i++;
//		}
//		return maxCoins2(nums);
//
//	}
//	public int maxCoins2(int[] nums) {
//		int max = 0;
//		for (int i = 0; i < nums.length; i++) {
//			if (nums[i] != -1) {
//				int total = 0;
//				int temp = nums[i];
//				total += burst(nums, i);
//				total += maxCoins(nums);
//				nums[i] = temp;
//				max = Math.max(max, total);
//				
//			}
//			
//		}
//		return max;
//
//	}
//
//	private int burst(int[] nums, int i) {
//		int left = 1;
//		int k = i - 1;
//		while (k > -1 && nums[k] == -1) {
//			k--;
//		}
//		if (k > -1)
//			left = nums[k];
//		int right = 1;
//		k = i + 1;
//		while (k < nums.length && nums[k] == -1)
//			k++;
//		if (k < nums.length)
//			right = nums[k];
//		left = left * right * nums[i];
//		nums[i] = -1;
//		return left;
//	}
}
