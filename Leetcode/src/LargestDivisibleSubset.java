import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class LargestDivisibleSubset {
	public static void main(String[] args) {
		System.out.println(largestDivisibleSubset(new int[]{2,4,1,8}));
	}
	public static List<Integer> largestDivisibleSubset(int[] nums) {
		  List<Integer> res = new ArrayList<Integer>();
	        if (nums == null || nums.length == 0) return res;
	        Arrays.sort(nums);
	        int[] dp = new int[nums.length];
	        int[] pre = new int[nums.length];
	        for (int i = 0; i < nums.length; i++) {
	            dp[i] = 1;
	            pre[i] = i;
	        }
	        int maxIndex = 0, max = 1;
	        for (int i = 1; i < nums.length; i++) {
	            for (int j = i - 1; j >= 0; j--) {
	                if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i]) {
	                    dp[i] = dp[j] + 1;
	                    pre[i] = j;
	                    if (dp[i] > max) {
	                        max = dp[i];
	                        maxIndex = i;
	                    }                        
	                }
	            }
	        }
	        int cur = maxIndex;
	        while (pre[cur] != cur) {
	            res.add(nums[cur]);
	            cur = pre[cur];
	        }
	        res.add(nums[cur]);
	        return res;
	}
}
