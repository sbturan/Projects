
public class StringtoInteger {
	public static void main(String[] args) {
		System.out.println(myAtoi("-2147483648"));
	}

	public static int myAtoi(String str) {
		char[] charArray = str.toCharArray();
		if (charArray.length == 0)
			return 0;
		int i = 0;
		while (i < charArray.length && charArray[i] == ' ') {
			i++;
		}
		if (i >= charArray.length) {
			return 0;
		}

		int sign = 1;

		// if(i<charArray.length-1)
		// if(charArray[i]=='+'&&charArray[i+1]=='-'
		// ||charArray[i+1]=='+'&&charArray[i]=='-') return 0;
		if (!Character.isDigit(charArray[i]) && charArray[i] != '+' && charArray[i] != '-')
			return 0;
		if (charArray[i] == '+') {
			i++;
			if (i >= charArray.length) {
				return 0;
			}
			if (!Character.isDigit(charArray[i]))
				return 0;
		}

		if (charArray[i] == '-') {
			sign = -1;
			i++;
		}
		if (i >= charArray.length) {
			return 0;
		}
		if (!Character.isDigit(charArray[i]))
			return 0;

		double result = charArray[i++] - '0';
		while (i < charArray.length) {
			if (!Character.isDigit(charArray[i]))
				return returnVal(sign, result);

			result = result * 10.0 + (charArray[i] - '0');
			i++;
		}
		return returnVal(sign, result);

	}

	private static int returnVal(int sign, double result) {
	    if(sign*result>Integer.MAX_VALUE) return Integer.MAX_VALUE;
	    if(sign*result<Integer.MIN_VALUE) return Integer.MIN_VALUE;
		return  (int) (result * sign);
	}
}
