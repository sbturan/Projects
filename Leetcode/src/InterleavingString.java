
public class InterleavingString {
	public static void main(String[] args) {
		InterleavingString s = new InterleavingString();
		/*
		 * "bbbbbabbbbabaababaaaabbababbaaabbabbaaabaaaaababbbababbbbbabbbbababbabaabababbbaabababababbbaaababaa"
		 * "babaaaabbababbbabbbbaabaabbaabbbbaabaaabaababaaaabaaabbaaabaaaabaabaabbbbbbbbbbbabaaabbababbabbabaab"
		 * "babbbabbbaaabbababbbbababaabbabaabaaabbbbabbbaaabbbaaaaabbbbaabbaaabababbaaaaaabababbababaababbababbbababbbbaaaabaabbabbaaaaabbabbaaaabbbaabaaabaababaababbaaabbbbbabbbbaabbabaabbbbabaaabbababbabbabbab"
		 */
		System.out.println(s.isInterleave("a", "", "a"));

	}

	public boolean isInterleave(String s1, String s2, String s3) {
		if (s1.length() + s2.length() != s3.length()) {
			return false;
		}
		char[] c1 = s1.toCharArray();
		char[] c2 = s2.toCharArray();
		char[] c3 = s3.toCharArray();
		return helper(c1, c2, c3, 0, 0, 0, new boolean[c1.length + 1][c2.length + 1]);
	}

	private boolean helper(char[] s1, char[] s2, char[] s3, int i1, int i2, int i3, boolean[][] dp) {
		if (i3 >= s3.length)
			return true;
		if (dp[i1][i2])
			return false;

		boolean res = (i1 < s1.length && s1[i1] == s3[i3] && helper(s1, s2, s3, i1 + 1, i2, i3 + 1, dp))
				|| (i2 < s2.length && s2[i2] == s3[i3] && helper(s1, s2, s3, i1, i2 + 1, i3 + 1, dp));

		if (!res)
			dp[i1][i2] = true;
		return res;

	}

}
