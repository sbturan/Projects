import java.util.Arrays;
import java.util.List;

public class CountofSmallerNumbersAfterSelf {
	class TreeNode {
		int smallCount;
		int val;
		TreeNode left;
		TreeNode right;

		public TreeNode(int count, int val) {
			this.smallCount = count;
			this.val = val;
		}
	}

	public List<Integer> countSmaller(int[] nums) {
		TreeNode root = null;
		Integer[] ret = new Integer[nums.length];
		if (nums == null || nums.length == 0)
			return Arrays.asList(ret);
		for (int i = nums.length - 1; i >= 0; i--) {
			root = insert(root, nums[i], ret, i, 0);
		}
		return Arrays.asList(ret);
	}

	public TreeNode insert(TreeNode root, int val, Integer[] ans, int index, int preSum) {
		if (root == null) {
			root = new TreeNode(0, val);
			ans[index] = preSum;
		} else if (root.val > val) {
			root.smallCount++;
			root.left = insert(root.left, val, ans, index, preSum);
		} else {
			root.right = insert(root.right, val, ans, index, root.smallCount + preSum + (root.val < val ? 1 : 0));
		}
		return root;
	}

}
