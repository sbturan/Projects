
public class ValidateBinarySearchTree {
	public boolean isValidBST(TreeNode root) {

		return helper(root, Integer.MAX_VALUE, Integer.MIN_VALUE);
	}

	private boolean helper(TreeNode node, int max, int min) {
		if (node == null) {
			return true;
		}

		return node.val > min && node.val < max && helper(node.left, node.val, min)
				&& helper(node.right, max, node.val);

	}
}
