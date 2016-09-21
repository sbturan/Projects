import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class SubstringwithConcatenationofAllWords {
	public static void main(String[] args) {
		/**
		 * "wordgoodgoodgoodbestword" ["word","good","best","good"]
		 */
		System.out.println(findSubstring("wordgoodgoodgoodbestword", new String[] { "word", "good", "best", "good" }));
	}

	public static List<Integer> findSubstring(String s, String[] words) {
		List<Integer> result = new ArrayList<Integer>();

		if (words.length == 0)
			return result;
		int oneWordLength = words[0].length();
		int wordsTotalLength = oneWordLength * words.length;

		HashMap<String, Integer> map = new HashMap<>();
		for (String ss : words) {
			map.put(ss, map.getOrDefault(ss, 0) + 1);
		}
		for (int i = 0; i < s.length() - wordsTotalLength + 1; i++) {
			if (check(oneWordLength, new HashMap<>(map), s.substring(i, i + wordsTotalLength))) {
				result.add(i);
			}
		}

		return result;

	}

	private static boolean check(int oneWordLength, HashMap<String, Integer> map, String substring) {

		for (int i = 0; i < substring.length() - oneWordLength + 1; i = i + oneWordLength) {
			String current = substring.substring(i, i + oneWordLength);
			if (!map.containsKey(current) || map.get(current) == 0)
				return false;
			map.put(current, map.get(current) - 1);
		}

		return true;
	}

}
