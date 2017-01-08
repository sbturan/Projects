
public class PalindromeNumber {
	public static void main(String[] args) {
		PalindromeNumber p = new PalindromeNumber();
		System.out.println(p.isPalindrome(455254));
	}

	public boolean isPalindrome(int x) {
		if (x < 0)
			return false;
		int digitCount = (int) (Math.log10(x) + 1);

		int divider = (int) Math.pow(10, digitCount - 1);
		while (digitCount > 0) {
			if (!checkLastAndFirst(x, digitCount, divider)) {
				return false;
			}
			x = x % divider;
			x = x / 10;
			digitCount -= 2;
			divider /= 100;
		}
		// 52332
		// 623326
		// 784487
		return true;
	}

	private boolean checkLastAndFirst(int x, int digitCount, int divider) {
		if (digitCount == 1)
			return true;
		if (x % 10 != (int) (x / divider))
			return false;
		return true;
	}
}
