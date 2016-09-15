import java.util.ArrayList;
import java.util.List;

public class RecoverBinarySearchTree {
	public static void main(String[] args) {
		 
		TreeNode t1=new TreeNode(0);
		t1.left=new TreeNode(1);
		recoverTree(t1);
	}
	public static  void recoverTree(TreeNode root) {

		parents = new ArrayList<>();
		TreeNode firstWrong = getWrongNodeParent(root, null);
		TreeNode secondWrong = getWrongNodeParent(root, firstWrong);
		TreeNode parent1 = parents.get(0);
		TreeNode parent2 = parents.get(1);

		TreeNode temp;
		temp = firstWrong.left;
		firstWrong.left = secondWrong.left;
		secondWrong.left = temp;

		temp = firstWrong.right;
		firstWrong.right = secondWrong.right;
		secondWrong.right = temp;

		if (parent1.left != null && parent1.left.val == firstWrong.val) {
			if (parent2.left != null && parent2.left.val == secondWrong.val) {
				parent1.left = secondWrong;
				parent2.left = firstWrong;
			} else {
				parent1.left = secondWrong;
				parent2.right = firstWrong;
			}
		} else {
			if (parent2.left != null && parent2.left.val == secondWrong.val) {
				parent1.right = secondWrong;
				parent2.left = firstWrong;
			} else {
				parent1.right = secondWrong;
				parent2.right = firstWrong;
			}
		}

	}

	private static List<TreeNode> parents;

	private static TreeNode getWrongNodeParent(TreeNode root, TreeNode firstNode) {

		if (root == null)
			return null;
		if (root.left != null && root.left.val > root.val) {
			if (firstNode == null || root.left.val != firstNode.val) {
				parents.add(root);
				return root.left;
			}
		}
		if (root.right != null && root.right.val < root.val) {
			if (firstNode == null || root.right.val != firstNode.val) {
				parents.add(root);
				return root.right;
			}
		}
		TreeNode wrongNode = getWrongNodeParent(root.left, firstNode);
		if (wrongNode != null)
			return wrongNode;
		return getWrongNodeParent(root.right, firstNode);

	}
}
