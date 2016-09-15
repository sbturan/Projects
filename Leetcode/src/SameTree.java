
public class SameTree {
	public boolean isSameTree(TreeNode p, TreeNode q) {
 
		if(p==null&&q==null) return true;
		if(p==null||q==null) return false;
		if(p.val!=q.val) return false;
	    boolean sameTree = isSameTree(p.left, q.left);
	    if(!sameTree) return false;
	    return isSameTree(p.right, q.right);
  		
 		
		
	}
}
