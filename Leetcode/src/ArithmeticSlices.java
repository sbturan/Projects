
public class ArithmeticSlices {
	public static void main(String[] args) {
		System.out.println(numberOfArithmeticSlices(new int[]{1,2,3,4,8,9,10}));
	}
	public static int numberOfArithmeticSlices(int[] A) {
		if (A.length < 3)
			return 0;
		int total = 0;
		for (int i = 0; i < A.length - 2; i++) {
			if (((A[i] - A[i + 1]) * 2) == A[i] - A[i + 2]) {
				int j = i + 2;
				int dif = A[i] - A[i + 1];
				while (j < A.length-1 && (A[j] - A[j + 1]) == dif) {
					j++;
				}
					int temp = 0;
					for (int k = 3; k <= j - i + 1; k++) {
						temp += (j - i + 1) - k + 1;

					}
					total += temp;
				i=j;

			}
		}
		return total;
	}
}
