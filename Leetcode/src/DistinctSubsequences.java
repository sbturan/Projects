import java.util.HashMap;
import java.util.LinkedList;
import java.util.Map;

public class DistinctSubsequences {
	public static void main(String[] args) {
		DistinctSubsequences d = new DistinctSubsequences();
		/*
		 * "adbdadeecadeadeccaeaabdabdbcdabddddabcaaadbabaaedeeddeaeebcdeabcaaaeeaeeabcddcebddebeebedaecccbdcbcedbdaeaedcdebeecdaaedaacadbdccabddaddacdddc"
		 * "bcddceeeebecbc"
		 */
		System.out.println(d.numDistinct(
				"adbdadeecadeadeccaeaabdabdbcdabddddabcaaadbabaaedeeddeaeeb"
						+ "cdeabcaaaeeaeeabcddcebddebeebedaecccbdcbcedbdaeaedcdebeec" + "daaedaacadbdccabddaddacdddc",
				"bcddceeeebecbc"));
	}

	public int numDistinct(String s, String t) {
		if (t.length() > s.length())
			return 0;
		int[] count = new int[t.length()];
		char[] arrt = t.toCharArray();
		char[] arrs = s.toCharArray();
		Map<Character, LinkedList<Integer>> m = new HashMap<Character, LinkedList<Integer>>();
		LinkedList<Integer> temp = null;
		int i = 0;
		// keep a list of indexes of the same character
		for (char c : arrt) {
			temp = m.get(c);
			if (temp == null) {
				temp = new LinkedList<Integer>();
				m.put(c, temp);
			}
			temp.addFirst(i++);
		}
		// count[i] = count[i]+count[i-1]
		for (char c : arrs) {
			temp = m.get(c);
			if (temp != null) {
				for (int k : temp) {
					if (k == 0) {
						count[k]++;
					} else {
						count[k] += count[k - 1];
					}
				}
			}
		}
		return count[t.length() - 1];
	}
}
