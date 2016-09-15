import java.util.HashMap;

public class IsomorphicStrings {

	public static void main(String[] args) {

		System.out.println(isIsomorphic("ab", "aa"));
	}

	public static boolean isIsomorphic(String s, String t) {

		HashMap<Character, Character> map = new HashMap<>();
		char[] split = t.toCharArray();
		int index = 0;
		if (split.length != s.length())
			return false;

		for (Character sa : split) {
			char pCharAt = s.charAt(index);
			if (map.get(pCharAt) == null && !map.containsValue(sa)) {
				map.put(pCharAt, sa);
			} else if (!sa.equals(map.get(pCharAt))) {
				return false;
			}
			index++;

		}

		return true;
	}

}
