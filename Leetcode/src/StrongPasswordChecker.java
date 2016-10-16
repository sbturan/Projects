
public class StrongPasswordChecker {
	public static void main(String[] args) {
		StrongPasswordChecker sp = new StrongPasswordChecker();
		System.out.println(sp.strongPasswordChecker("1234567890123456Baaaaa"));
	}

	public int strongPasswordChecker(String s) {
		boolean lowerLetter = false;
		boolean upperLetter = false;
		boolean digit = false;
		int repeatcount = 0;
		int lastRepeatIndex = -1;
		char[] charArray = s.toCharArray();
		for (int i = 0; i < charArray.length; i++) {
			if (i < charArray.length - 2) {
				if (i > lastRepeatIndex && charArray[i] == charArray[i + 1] && charArray[i + 1] == charArray[i + 2]) {// count
																														// repetitions
																														// in
																														// different
																														// positions
					lastRepeatIndex = i + 2;
					repeatcount++;
				}
			}
			int cur = (int) charArray[i];
			if (cur > 64 && cur < 91) {
				upperLetter = true;
			} else if (cur > 96 && cur < 123) {
				lowerLetter = true;
			} else if (cur > 47 && cur < 58) {
				digit = true;
			}
		}
		int result = 0;
		if (!lowerLetter) // needs lower case letter
			result++;
		if (!upperLetter) // needs upper case letter
			result++;
		if (!digit) // needs a digit
			result++;
		boolean repeatRemoved = false;
		if (result < repeatcount) { // if changes before(for lower,uppercases
									// and digits) are not enough for disrupt
									// repetition series
			repeatRemoved = true;
			result += repeatcount - result;
		}
		if (s.length() < 6) {
			int dif = 6 - s.length();
			result = Math.max(result, dif);
		} else if (s.length() > 20) {

			int dif = s.length() - 20;
			if (!repeatRemoved) {// if we won't remove any char is repeated
									// remove extra chars basically
				result += dif;
			} else if (dif - repeatcount > 0)
				result += dif - repeatcount;// for example if we will remove 4
											// repeated chars, and there are 5
											// extra chars than add 1 to result
		}

		return result;

	}
}
