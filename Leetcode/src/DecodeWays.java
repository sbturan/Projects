import java.util.Arrays;

public class DecodeWays {
	public static void main(String[] args) {
		DecodeWays d = new DecodeWays();
		System.out.println(d.numDecodings(
				"1168963884134125126536966946586868418993819971673459188478711546479621135253876271366851168524933185"));
	}

	public int numDecodings(String s) {
		int dp[] = new int[s.length()];
		Arrays.fill(dp, -1);
		return helper(s, dp, 0);
	}

	public int helper(String s, int[] dp, int index) {

		if (index >= s.length()) {
			{
				return 0;
			}
		}
		if (dp[index] != -1)
			return dp[index];
		int first = (int) s.charAt(index) - '0';
		int result = 1;

		if (first > 0 && index < s.length() - 1)
			result = helper(s, dp, index + 1);
		else if (first < 1) {
			dp[index] = 0;
			return 0;
		}
		if (index < s.length() - 1) {
			first = (first * 10) + (int) s.charAt(index + 1) - '0';
			if (first < 27) {
				if (index < s.length() - 2) {
					result += helper(s, dp, index + 2);
				} else {
					result += 1;
				}
			}
		}
		dp[index] = result;
		return result;
	}

}
