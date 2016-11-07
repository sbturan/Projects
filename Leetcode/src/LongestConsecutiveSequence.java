import java.util.HashSet;

public class LongestConsecutiveSequence {
	public static void main(String[] args) {
		/* [2147483646,-2147483647,0,2,2147483644,-2147483645,2147483645] */
		int[] arr = new int[] { 2147483646,-2147483647,0,2,2147483644,-2147483645,2147483645 };
		System.out.println(longestConsecutive(arr));
	}

	public static int longestConsecutive(int[] nums) {

		HashSet<Integer> set = new HashSet<Integer>();
		for (int i : nums) {
			set.add(i);
		}
		int result = 0;
		for (int i : nums) {
			int cur = i;
			int curMax = 0;
			while (set.contains(cur )) {
				curMax++;
				set.remove(cur );
				cur++;
			}
			cur=i-1;
			while (set.contains(cur )) {
				curMax++;
				set.remove(cur );
				cur--;
			}
			result = Math.max(result, curMax);
		}

		return result;

	}
}
