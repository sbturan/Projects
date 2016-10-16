import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class BinaryTreePreorderTraversal {
	public static void main(String[] args) {
		TreeNode n1 = new TreeNode(1);
		TreeNode n2 = new TreeNode(2);
		TreeNode n3 = new TreeNode(3);
		TreeNode n4 = new TreeNode(4);
		TreeNode n5 = new TreeNode(5);
		TreeNode n6 = new TreeNode(6);
		TreeNode n7 = new TreeNode(7);
		TreeNode n8 = new TreeNode(8);
		n1.left = n2;
		n1.right = n3;
		n2.left = n4;
		n2.right = n5;
		n3.left = n6;
		n3.right = n7;
		n4.right = n8;
		System.out.println(preorderTraversal(n1));
	}

	public static List<Integer> preorderTraversal(TreeNode root) {
		List<Integer> result = new ArrayList<>();

		List<TreeNode> arrayList = new ArrayList<>();
		int index = 0;
		if (root == null)
			return result;
		arrayList.add(root);
		result.add(root.val);
		while (index < arrayList.size()) {
			TreeNode current = arrayList.get(index);
			if (current.left != null) {
				arrayList.add(index + 1, current.left);
				result.add(index + 1, current.left.val);
			}
			if (current.right != null) {
				if (current.left == null) {
					arrayList.add(index + 1, current.right);
					result.add(index + 1, current.right.val);
				} else {
					arrayList.add(index + 2, current.right);
					result.add(index + 2, current.right.val);
				}
			}
			index++;
		}

		return result;

	}

}
