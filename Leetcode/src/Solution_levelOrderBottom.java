import java.util.ArrayList;
import java.util.List;

public class Solution_levelOrderBottom {
	  
	public static void main(String[] args) {
		TreeNode node=new TreeNode(1);
		TreeNode node2=new TreeNode(2);
		node.right=node2;
		Solution_levelOrderBottom solution=new Solution_levelOrderBottom();
		System.out.println(solution.levelOrderBottom(node));
		
	}
	   public List<List<Integer>> levelOrderBottom(TreeNode root) {
	     
		   boolean isLeafNode=true;
		  List<List<TreeNode>> result= new ArrayList<>(); 
		  if(root!=null){
			  List<TreeNode> rootList=new ArrayList<>();
			  rootList.add(root);
			  result.add(rootList);
		  }else{
			  return new  ArrayList<List<Integer>> ();
		  }
		  
		 do{
			  isLeafNode=true;
            List<TreeNode> nodeList= new ArrayList<>();
            List<TreeNode> lastList=result.get(result.size()-1);
            for(TreeNode node:lastList){
            	if(node.left!=null){
                	isLeafNode=false;
                	nodeList.add(node.left);
                }
                if(node.right!=null){
                	isLeafNode=false;
                	nodeList.add(node.right);
                }	
            }
            if(nodeList.size()>0)
            result.add(nodeList);
		 }while(!isLeafNode);
		 
		 List<List<Integer>> intResult=new ArrayList<>();
		 for(int i=0;i<result.size();i++){
			 List<Integer> subArray=new ArrayList<>();
			 for(TreeNode node:result.get(i)){
				 subArray.add(node.val);
			 }
			 
			 intResult.add(subArray);
			 
		 }
			 
		 
		   return intResult;
	    }
	   
}
