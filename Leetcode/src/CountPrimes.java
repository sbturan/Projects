public class CountPrimes {

	public static void main(String[] args) {
		CountPrimes cp = new CountPrimes();
		System.out.println(cp.countPrimes(5600));
	}


	public int countPrimes(int n) {
		// long start = System.currentTimeMillis();
		int primes[] = new int[n];
		if (n < 3)
			return 0;
		int value = 2;
		while (value * value < n) {
			if (primes[value] == 1) {
				value++;
				continue;
			}
			int k = value;
			while (k * value < n) {
				primes[k * value] = 1;
				k++;
			}
			value++;

		}
		int result = 0;
		for (int i = 2; i < n; i++) {
			if (primes[i] == 0) {
				System.out.print(i+" ");
				result++;
			}
		}
		System.out.println();
		// System.out.println(System.currentTimeMillis() - start);
		return result;
	}

}
