
public class FlattenBinaryTreeToLinkedList {
	public static void main(String[] args) {
		FlattenBinaryTreeToLinkedList f = new FlattenBinaryTreeToLinkedList();
		TreeNode t1 = new TreeNode(1);
		TreeNode t2 = new TreeNode(2);
		TreeNode t3 = new TreeNode(3);
		t1.left = t2;
		t2.left = t3;
		f.flatten(t1);
		System.out.println();
	}

	public void flatten(TreeNode root) {
		if (root == null)
			return;
		flatten(root.left);
		TreeNode cur = root.left;
		if (cur != null) {
			while (cur.right != null) {
				cur = cur.right;
			}
			cur.right = root.right;
			root.right = root.left;
			root.left = null;
			flatten(cur.right);
		} else
			flatten(root.right);
	}

}
