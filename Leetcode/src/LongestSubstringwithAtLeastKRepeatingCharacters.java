import java.util.Arrays;
import java.util.HashMap;

public class LongestSubstringwithAtLeastKRepeatingCharacters {
	public static void main(String[] args) {
		LongestSubstringwithAtLeastKRepeatingCharacters l = new LongestSubstringwithAtLeastKRepeatingCharacters();
		System.out.println(l.longestSubstring("aaabb", 3));
	}

	public int longestSubstring(String s, int k) {
		// HashMap<Integer, int[]> map = new HashMap<>();
		int[][] map = new int[s.length()+1][26];
		char[] charArray = s.toCharArray();
		for (int i = 0; i < charArray.length; i++) {
			int[] orDefault;
			
				orDefault = map[i];
			

			int[] cur = Arrays.copyOf(orDefault, 26);
			cur[(int) (charArray[i] - 'a')] += 1;
			map[i+1] = cur;
		}
		int result = 0;
		for (int i = charArray.length - 1; i > -1; i--) {
			for (int j = 0; j <= i - k + 1; j++) {
				int[] last = map[i+1];
				int[] first;
					first = map[j ];
				boolean founded = true;
				for (int index = 0; index < last.length; index++) {
					if (last[index] != 0) {
						if (last[index] - first[index] > 0 && last[index] - first[index] < k) {
							founded = false;
							break;
						}
					}
				}
				if (founded) {
					result = Math.max(result, i - j + 1);
					if (result == charArray.length)
						return result;
				}
			}
		}
		return result;
	}
}
