
public class NumberofSegmentsinaString {
	public static void main(String[] args) {
		NumberofSegmentsinaString n=new NumberofSegmentsinaString();
		System.out.println(n.countSegments("  "));
	}
	public int countSegments(String s) {
		int result = 0;
		char[] charArray = s.toCharArray();
		int i = 0;
		while (i < charArray.length) {
			int charcount = 0;
			while (i < charArray.length && charArray[i] != ' ') {
				i++;
				charcount++;
			}
			if (charcount > 0) {
				result++;
			}
			while (i < charArray.length && charArray[i] == ' ') {
				i++;
			}
		}

		return result;
	}
}
