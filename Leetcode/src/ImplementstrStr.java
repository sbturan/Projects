
public class ImplementstrStr {
	public static void main(String[] args) {
		ImplementstrStr i = new ImplementstrStr();
		// "mississippi"
		// "issip"
		System.out.println(i.strStr("mississippi", "issip"));
	}

	public int strStr(String haystack, String needle) {
		if (needle == null || needle.length() == 0)
			return 0;
		char[] needleArray = needle.toCharArray();
		char[] haystackArray = haystack.toCharArray();
		for (int i = 0; i <= haystackArray.length - needleArray.length; i++) {
			if (haystackArray[i] == needleArray[0]) {
				int j = i;
				int k = 0;
				while (j < haystackArray.length && k < needleArray.length && haystackArray[j] == needleArray[k]) {
					j++;
					k++;
				}
				if (k == needleArray.length) {
					return i;
				}

			}
		}
		return -1;
	}
}
