import java.util.ArrayList;
import java.util.List;

public class PathSumII {
	public List<List<Integer>> pathSum(TreeNode root, int sum) {
		   result=new ArrayList<List<Integer>>();
		
		helper(root, sum, new ArrayList<Integer>());

		return result;
	}

	static List<List<Integer>> result;
	private static void helper(TreeNode root, int sum, List<Integer> currentList) {
		if (root == null) {
			return;
		}

		currentList.add(root.val);
		if (root.right == null && root.left == null) {
			if (sum == root.val) {
				result.add(new ArrayList<>(currentList));

			}
			currentList.remove(currentList.size() - 1);
			return;
		}

		helper(root.right, sum - root.val, currentList);

		helper(root.left, sum - root.val, currentList);

		currentList.remove(currentList.size() - 1);
	}
}
