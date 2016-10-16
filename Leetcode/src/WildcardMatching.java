import java.util.LinkedList;
import java.util.Queue;

public class WildcardMatching {
	public static void main(String[] args) {
		WildcardMatching w = new WildcardMatching();
		/*
		 * "abefcdgiescdfimde" "ab*cd?i*de"
		 */
		System.out.println(w.isMatch("ab", "*?*?*"));
	}

	public boolean isMatch(String s, String p) {
		int saved_p = -1, saved_s = -1;
		int indexP = 0;
		for (int indexS = 0; indexS < s.length();) {

			if (indexP < p.length() && (s.charAt(indexS) == p.charAt(indexP) || p.charAt(indexP) == '?')) {
				// match to a single character
				indexP++;
				indexS++;
			} else if (indexP < p.length() && p.charAt(indexP) == '*') {
				// go into the * state, we need to save the P next position and
				// save S next position
				// when any mismatch happen, we can revert the search to it
				// previous state '*'
				saved_p = indexP;
				// move the saved_s, next time it should skip current one
				saved_s = indexS + 1;
				indexP++;
			} else if (saved_p != -1) {
				// means not match, we need to revert
				indexP = saved_p;
				indexS = saved_s;
			} else {
				// means not match, but not wildcard
				return false;
			}
		}
		// examine the left char in the pattern
		// they should all be '*' if any char left
		for (int index = indexP; index < p.length(); index++) {
			if (p.charAt(index) != '*') {
				return false;
			}
		}
		return true;
	}
}
