
public class KthSmallestElementinaBST {

	public int kthSmallest(TreeNode root, int k) {
        
		helper(root, k);
		return result;
 	}
	
	private static int result=0;
	private static int  helper(TreeNode n,int k){
	   
		 if(n==null) return k;
	     k=helper(n.left, k);
	     if(k==1) {
	    	 result=n.val;
	    	 return -1;
	     }
	     if(k!=-1){
	    	 k--;
		     k=helper(n.right,k);	 
	     }
		  
	     return k;
	
	}
}
