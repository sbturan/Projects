import java.util.ArrayList;
import java.util.List;

public class CombinationSumIII {
	public static void main(String[] args) {
		CombinationSumIII c = new CombinationSumIII();
		System.out.println(c.combinationSum3(3, 9));
	}

	public List<List<Integer>> combinationSum3(int k, int n) {
		List<List<Integer>> result = new ArrayList<>();
		rcrsv(result, new ArrayList<Integer>(), k, n, 1);
		return result;
	}

	private void rcrsv(List<List<Integer>> result, List<Integer> cur, int k, int target, int index) {
		if (target == 0 && k == 0) {
			result.add(new ArrayList<Integer>(cur));
			return;
		}
		if (target <= 0 || k == 0)
			return;
		for (int i = index; i < 10; i++) {
			cur.add(i);
			rcrsv(result, cur, k - 1, target - i, i + 1);
			cur.remove(cur.size() - 1);
		}
	}
}
