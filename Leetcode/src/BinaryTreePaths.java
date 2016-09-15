import java.util.ArrayList;
import java.util.List;

public class BinaryTreePaths {
	 public List<String> binaryTreePaths(TreeNode root) {
	     result=new ArrayList<>();
	     helper(root,"");
	     return result;
		 
	 }
	 List<String> result;
	 
	 private void helper(TreeNode root, String current){
		 if(root.left==null&&root.right==null){
			 current=current.concat(root.val+"");
			 result.add(new String(current));
			 current=current.substring(0,current.length()-1);
			 return;
		 }
		 current=current.concat(root.val+"->");
		 if(root.left!=null)
			 helper(root.left,current);
		 if(root.right!=null)
			 helper(root.right,current);
		 
		 current=current.substring(0,current.length()-3);
		 
		 
		 
	 } 
}
