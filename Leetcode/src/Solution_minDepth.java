import java.util.ArrayList;
import java.util.List;

public class Solution_minDepth {
	public int minDepth(TreeNode root) {

		List<List<TreeNode>> nodeList = new ArrayList<>();
		if (root != null) {
			List<TreeNode> rootList = new ArrayList<>();
			rootList.add(root);
			nodeList.add(rootList);
		} else {
			return 0;
		}
		int result = 1;
		boolean breakLoop = false;
		while (!breakLoop) {
			List<TreeNode> current = nodeList.get(nodeList.size() - 1);
			List<TreeNode> newNodes = new ArrayList<>();
			
			for (TreeNode node : current) {
				breakLoop = true;
				if (node.left != null) {
					breakLoop = false;
					newNodes.add(node.left);
				}

				if (node.right != null) {
					breakLoop = false;
					newNodes.add(node.right);
				}
				if (breakLoop) {
					break;
				}

			}

			if (!breakLoop) {
				nodeList.add(newNodes);
				result++;
			}

		}

		return result;
	}

}
