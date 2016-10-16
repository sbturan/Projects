import java.util.Arrays;

public class RemoveKDigits {
	public static void main(String[] args) {
		/*
		 * "1234567890" 9
		 */
		RemoveKDigits r = new RemoveKDigits();
		System.out.println(r.removeKdigits("1234567890", 9));
	}

	public String removeKdigits(String num, int k) {

		if (num.length() == 0 || num.length() == k)
			return "0";
		if (k == 0)
			return num;
		char[] charArray = num.toCharArray();

		int remain = num.length() - k;
		int start = 0;
		StringBuffer sb = new StringBuffer();
		while (remain > 0) {

			int min = charArray[start] - '0';
			for (int i = start + 1; i <= charArray.length - remain; i++) {
				if (min > charArray[i] - '0') {
					min = charArray[i] - '0';
					start = i;
				}
				if (min == 0)
					break;
			}

			sb.append(min);
			start++;
			remain--;
		}

		int i = 0;
		while (i < sb.length() && sb.charAt(i) == '0') {
			i++;
		}
		if (i == sb.length())
			return "0";
		return sb.substring(i);

	}

}
