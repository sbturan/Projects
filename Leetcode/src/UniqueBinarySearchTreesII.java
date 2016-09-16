import java.util.ArrayList;
import java.util.List;

public class UniqueBinarySearchTreesII {
	  public List<TreeNode> generateTrees(int n) {
	        if (n < 1)
	            return new ArrayList<>();
	        
	        List<TreeNode>[] template = new ArrayList[n+1];
	        List<TreeNode> zero = new ArrayList<>();
	        zero.add(null);
	        template[0] = zero;
	        
	        for (int i = 1; i <= n; i++) {
	            List<TreeNode> tmp = new ArrayList<>();
	            for (int j = 0; j < i; j++) {
	                for (TreeNode left_root : template[j]) {
	                    for (TreeNode right_root: template[i-1-j]) {
	                        TreeNode root = new TreeNode(j+1);
	                        root.left = generator(left_root, 0);
	                        root.right = generator(right_root, j+1);
	                        tmp.add(root);
	                    }
	                }
	            }
	            template[i] = tmp;
	        }
	        
	        return template[n];
	    }
	    
	    private TreeNode generator(TreeNode root, int offset) {
	        if (root == null)
	            return root;
	        TreeNode _root = new TreeNode(root.val + offset);
	        _root.left = generator(root.left, offset);
	        _root.right = generator(root.right, offset);
	        return _root;
	}
}
