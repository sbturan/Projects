
public class DeleteNodeinaBST {
	public static void main(String[] args) {

		Integer[] array = new Integer[] { 0 };
		TreeNode root = Tools.arrayToTree(array);
		DeleteNodeinaBST dst = new DeleteNodeinaBST();
		TreeNode deleteNode = dst.deleteNode(root, 0);
		

	}

	public TreeNode deleteNode(TreeNode root, int key) {
		if (root == null)
			return root;
		if (root.val > key)
			root.left = deleteNode(root.left, key);
		else if (root.val < key)
			root.right = deleteNode(root.right, key);
		else { 
			if (root.left == null)
				return root.right;
			else if (root.right == null)
				return root.left;
			root.val = getMin(root.right);
			root.right = deleteNode(root.right, root.val);
		}
		return root;
	}

	private int getMin(TreeNode root) {
		int min = root.val;
		while (root.left != null) {
			root = root.left;
			min = root.val;
		}
		return min;
	}

}
