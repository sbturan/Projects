
public class IntegerReplacement {

	public static void main(String[] args) {
		IntegerReplacement i = new IntegerReplacement();
		System.out.println(i.integerReplacement(1234));
	}

	public int integerReplacement(int n) {

		return helper(n, 0);
	}

	private int helper(int n, int count) {
		if(n==Integer.MAX_VALUE) return 32;
		if (n == 1)
			return count;
		if (n % 2 == 0)
			return helper(n >>1, count + 1);

		int val1 = helper((n + 1)>>1, count + 2);
		int val2 = helper((n -1 )>>1, count + 2);
		return Math.min(val1, val2);

	}
}
