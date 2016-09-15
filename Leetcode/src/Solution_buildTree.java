import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

public class Solution_buildTree {
	 public static void main(String[] args) {
		int[] inorder=new int[]{1,2,3,4};  //{4,8,2,9,5,10,1,6,11,3,12,7};
		int[] postorder=new int[]{3,4,2,1};//{8,4,9,10,5,2,11,6,12,7,3,1};
		
	
		if(buildTree(inorder, postorder)!=null)
		System.out.println(buildTree(inorder, postorder).val);
	}
	 static Map<Integer,Integer> inorderIndex=new HashMap<>();
	 static Map<Integer,Integer> postorderIndex=new HashMap<>();
	 public static TreeNode buildTree(int[] inorder, int[] postorder) {
	      if(inorder.length==0) return null;
	      
	      
	      
	      for (int i=0;i<postorder.length ;i++ ) {
			postorderIndex.put(postorder[i],i);
		}
	      
	      for (int i=0;i<inorder.length ;i++ ) {
	    	  inorderIndex.put(inorder[i],i);
			}
	      
	      
		 
		 return findRoot(inorder,postorder);
	    }
	 
	 public static TreeNode findRoot(int[] inorder, int[] postorder){
		 if(inorder==null||inorder.length==0) return null;
		 if(inorder.length==1){
			 TreeNode root=new TreeNode(inorder[0]);
			 return root;
		 }
		 
		 TreeNode root= new TreeNode(postorder[postorder.length-1]);
		 
		 if(inorder[inorder.length-1]==root.val){
			 root.right=null;
		 }else{
			 int from=inorderIndex.get(root.val)-inorderIndex.get(inorder[0])+1;
			 
			 int to= inorder.length;  //inorderIndex.get(inorder[inorder.length-1])-inorderIndex.get(inorder[0]);
			 root.right=findRoot(Arrays.copyOfRange(inorder, from, to), Arrays.copyOfRange(postorder, from-1, to-1));
		 }
		 if(inorder[0]==root.val){
			 root.left=null;
		 }else{
			 int from=0;
			 int to=inorderIndex.get(root.val)-inorderIndex.get(inorder[0]);
			 root.left=findRoot(Arrays.copyOfRange(inorder, from, to), Arrays.copyOfRange(postorder, from, to));
		 }
		 
		 
		 return root;
		 }
	   
		
	
}
