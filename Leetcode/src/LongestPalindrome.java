
public class LongestPalindrome {
	public static void main(String[] args) {
		LongestPalindrome l=new LongestPalindrome();
		System.out.println(l.longestPalindrome("ccc"));
	}
	public int longestPalindrome(String s) {
		int[] array = new int[58];
		char[] charArray = s.toCharArray();
		for (int i = 0; i < charArray.length; i++) {
			array[((int) charArray[i]) - 65] += 1;
		}
		boolean oneChar = false;
		int result = 0;
		for (int i : array) {
			result+=i-1+((i % 2)^1);
			oneChar = oneChar||i % 2 == 1;
				
		}
		if(oneChar) result++;
		return result;
	}
}
