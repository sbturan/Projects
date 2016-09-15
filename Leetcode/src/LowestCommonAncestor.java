public class LowestCommonAncestor {
 	public static void main(String[] args) {
    
	}

	public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
      
		while(true){
			if(root.val==q.val||root.val==p.val||(root.val-p.val)*(root.val-q.val)<0) return root;
			if(root.val>q.val) root=root.left;
			else root=root.right;
  		}
		
	}


}
