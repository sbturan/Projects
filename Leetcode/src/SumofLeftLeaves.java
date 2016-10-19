import java.util.LinkedList;
import java.util.Queue;

public class SumofLeftLeaves {
	public static void main(String[] args) {
		SumofLeftLeaves s = new SumofLeftLeaves();
		TreeNode t1 = new TreeNode(1);
		TreeNode t2 = new TreeNode(2);
		TreeNode t3 = new TreeNode(3);
		TreeNode t4 = new TreeNode(4);
		TreeNode t5 = new TreeNode(5);
		t1.left = t2;
		t2.left = t3;
		t3.left = t4;
		t4.left = t5;
		System.out.println(s.sumOfLeftLeavesIterative(t1));

	}

	public int sumOfLeftLeaves(TreeNode root) {
		return helper(root, 0);
	}

	private int helper(TreeNode t, int isLeft) {
		if (t == null)
			return 0;
		if (t.left == null && t.right == null) {
			return t.val * isLeft;
		}
		int result = 0;
		result += helper(t.left, 1);
		result += helper(t.right, 0);
		return result;
	}

	public int sumOfLeftLeavesIterative(TreeNode root) {

		int result = 0;
		Queue<TreeNode> q = new LinkedList<TreeNode>();
		if (root == null)
			return result;
		q.add(root);
		while (!q.isEmpty()) {
			TreeNode cur = q.poll();

			if (cur.left != null) {
				if (cur.left.left == null && cur.left.right == null) {
					result += cur.left.val;
				} else
					q.add(cur.left);
			}
			if (cur.right != null) {
				q.add(cur.right);
			}
		}
		return result;
	}
}
