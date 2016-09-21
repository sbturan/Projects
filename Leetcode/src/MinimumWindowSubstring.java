import java.util.Arrays;
import java.util.HashSet;

public class MinimumWindowSubstring {
	public static void main(String[] args) {
		/*
		 * "caae" "cae"
		 */
		System.out.println(minWindow("caae", "cae"));
	}

	public static String minWindow(String s, String t) {

		char[] cs = s.toCharArray();
		char[] ct = t.toCharArray();
		int nnum = ct.length, cnum = 0; // nnum：Need the total number of letters
										// ,cnum:Records the number of letters
										// between start and end
		int[] need = new int[60];
		int[] count = new int[60];
		for (char c : ct) {
			need[c - 'A']++;
		}
		int start = 0;
		String mstr = new String();
		int min = Integer.MAX_VALUE;
		for (int i = 0; i < cs.length; i++) {
			if (need[cs[i] - 'A'] != 0) {
				if (count[cs[i] - 'A'] < need[cs[i] - 'A'])
					cnum++;
				count[cs[i] - 'A']++;
			}

			while (start < i && (count[cs[start] - 'A'] > need[cs[start] - 'A'] || need[cs[start] - 'A'] == 0)) {
				count[cs[start] - 'A']--;
				start++;
			}
			if (cnum == nnum && i - start < min) {
				mstr = s.substring(start, i + 1);
				min = i - start;
			}
		}
		return mstr;

	}
}
