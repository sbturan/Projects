import java.util.ArrayList;
import java.util.Collections;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class BinaryTreeZigzagLevelOrderTraversal {

	public List<List<Integer>> zigzagLevelOrder(TreeNode root) {
		Queue<TreeNode> treeNodeList = new LinkedList<TreeNode>();
		int end=0;
		if (root != null)
			{
			treeNodeList.add(root);
			end++;
			}

		List<List<Integer>> result = new ArrayList<>();
		int begin = 0;
		while (!treeNodeList.isEmpty()) {

			List<Integer> currentList = new ArrayList<>();
			int curend=0;
			while (!treeNodeList.isEmpty() && begin < end) {
				TreeNode currrent = treeNodeList.poll();
				currentList.add(currrent.val);
				if (currrent.left != null) {
					treeNodeList.add(currrent.left);
					curend++;
				}
				if (currrent.right != null) {
					treeNodeList.add(currrent.right);
					curend++;
				}

				begin++;
			}
			result.add(currentList);
            end+=curend;
		}

		for (int i1 = 1; i1 < result.size(); i1 = i1 + 2) {
			Collections.reverse(result.get(i1));
		}

		return result;
	}

}
