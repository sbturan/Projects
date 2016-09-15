import java.util.HashMap;

import javax.print.attribute.HashAttributeSet;

public class WordPattern {
	public static void main(String[] args) {
		 
		System.out.println(wordPattern("abba", "dog dog dog dog"));
	} 
	
	public static boolean wordPattern(String pattern, String str) {
		HashMap<Character, String> map = new HashMap<>();
		String[] split = str.split(" ");
		int index = 0;
		if (split.length != pattern.length())
			return false;

		for (String s : split) {
			char pCharAt = pattern.charAt(index);
			if (map.get(pCharAt) == null&&!map.containsValue(s)) {
				map.put(pCharAt, s);
			} else if (!s.equals(map.get(pCharAt))) {
				return false;
			}
			index++;

		}

		return true;

	}
}
