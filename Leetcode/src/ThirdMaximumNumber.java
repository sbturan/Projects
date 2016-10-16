import java.util.Arrays;
import java.util.HashSet;

public class ThirdMaximumNumber {
	public static void main(String[] args) {
		ThirdMaximumNumber t = new ThirdMaximumNumber();
		int[] array=new int[] { 1, 2, 2, 5, 3, 5 };
		System.out.println(t.findNthMax(5,array));
	}

	public int thirdMax(int[] is) {
		return findNthMax(3, is);
	}

	int conflictCount = 0;

	public int findNthMax(int n, int[] nums) {
		conflictCount=0;
		if (n > nums.length) {
			int max = nums[0];
			for (int i : nums)
				max = Math.max(max, i);
			return max;
		}
		if(n<1) return 0;
		HashSet<Integer> set = new HashSet<>();
		int[] firstN = new int[n];
		Arrays.fill(firstN, Integer.MIN_VALUE);
		for (int i : nums) {
			if (!set.add(i)) {
				conflictCount++;
			}
			firstN = insertNumber(n - 1, i, firstN);
		}
		n = Math.min(n, nums.length - conflictCount);
		return firstN[firstN.length - n];

	}

	private int[] insertNumber(int start, int x, int[] array) {

		for (int i = start; i > -1; i--) {
			if (array[i] == x) {
				return array;
			}
			if (x > array[i]) {
				int temp = array[i];
				array[i] = x;
				return insertNumber(start - 1, temp, array);
			}
		}

		return array;
	}
}
