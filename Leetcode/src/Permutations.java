import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Permutations {
	public static void main(String[] args) {
		Permutations p = new Permutations();
		long currentTimeMillis = System.currentTimeMillis();
		System.out.println(p.permute(new int[] { 1, 1, 2, 3, 4, 5, 6, 7 }));
		System.out.println(System.currentTimeMillis() - currentTimeMillis);
	}

	public List<List<Integer>> permute(int[] nums) {
		int[] used = new int[nums.length];
		List<List<Integer>> result = new ArrayList<>();
		List<Integer> current = new ArrayList<>();
		helper(nums, used, result, current);
		return result;
	}

	private void helper(int[] nums, int[] used, List<List<Integer>> result, List<Integer> current) {
		if (current.size() == nums.length) {
			result.add(new ArrayList<>(current));
		}
		for (int i = 0; i < nums.length; i++) {
			if (used[i] == 0) {
				used[i] = 1;
				current.add(nums[i]);
				helper(nums, used, result, current);
				current.remove(current.size() - 1);
				used[i] = 0;
			}

		}

	}

}
