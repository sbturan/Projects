
public class GuessNumberHigherorLowerII {
	public int getMoneyAmount(int n) {
		int[][] dp = new int[n + 1][n + 1];

		return helper(dp, 1, n);
	}

	public int helper(int[][] dp, int left, int right) {
		if (dp[left][right] != 0) {
			return dp[left][right];
		}

		if (left >= right) {
			return 0;
		} else if (left >= right - 2) {
			return right - 1;
		}

		int mid = left + (right - left) / 2, min = Integer.MAX_VALUE, i;

		for (i = mid; i < right; i++) {
			min = Math.min(min, i + Math.max(helper(dp, i + 1, right), helper(dp, left, i - 1)));
		}

		dp[left][right] = min;

		return min;
	}
}
