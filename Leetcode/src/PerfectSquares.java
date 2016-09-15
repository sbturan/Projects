public class PerfectSquares {
	public static void main(String[] args) {
		PerfectSquares ps = new PerfectSquares();
		System.out.println(ps.numSquares(13));
	}

	public int numSquares(int n) {

		int[] calculated = new int[n + 1];
		calculated[0] = 0;
		return getMin(calculated, n);
	}

	private static int getMin(int[] dp, int x) {
		if (dp[x] != 0)
			return dp[x];

		if ((Math.sqrt(x) % 1) == 0) {
			dp[x] = 1;
			return 1;
		}
		int i = 1;
		int min = Integer.MAX_VALUE;
		while (i * i < x) {
			int minValue = 1 + getMin(dp, x - (i * i));
			min = Math.min(minValue, min);
			i++;
		}
		dp[x] = min;
		return min;

	}

}
