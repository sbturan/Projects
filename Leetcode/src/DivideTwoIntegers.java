
public class DivideTwoIntegers {
	public static void main(String[] args) {
		/*-2147483648
		-1017100424*/
		System.out.println(divide(-1000, 3));
	}

	public static int divide(int i_dividend, int i_divisor) {
		int sign = 1;
		long dividend = (long) i_dividend;
		long divisor = (long) i_divisor;

		if (dividend < 0) {
			dividend = -dividend;
			sign = -sign;
		}

		if (divisor < 0) {
			divisor = -divisor;
			sign = -sign;
		}

		long cnt = helper(dividend, divisor);

		cnt = sign > 0 ? cnt : -cnt;

		if (cnt > Integer.MAX_VALUE)
			return Integer.MAX_VALUE;
		else if (cnt < Integer.MIN_VALUE)
			return Integer.MIN_VALUE;
		else
			return (int) cnt;
	}

	private static long helper(long dividend, long divisor) {
		if (dividend < divisor)
			return 0;
		long origin = divisor;
		long cnt = 1;
		while (divisor << 1 < dividend) {
			divisor <<= 1;
			cnt <<= 1;
		}
		if (divisor == dividend)
			return cnt;
		else {
			cnt += helper(dividend - divisor, origin);
		}
		return cnt;
	}

}
