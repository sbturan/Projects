public class Solution_isBalancedTree {
	
	public static void main(String[] args) {
		Solution_isBalancedTree s= new Solution_isBalancedTree();
		TreeNode node1=new TreeNode(1);
		TreeNode node2=new TreeNode(2);
		TreeNode node3=new TreeNode(3);
		node1.right=node2;
		node2.right=node3;
		System.out.println(s.isBalanced(node1));
	}
	public boolean isBalanced(TreeNode root) {
		
		if(findHeight(root)==-1)
			return false;
		else return true;
		
	}
	
	private static int findHeight(TreeNode node){
		
		if(node==null){
			return 0;
		}
		int rightHeight=findHeight(node.right);
		if(rightHeight==-1) return -1;
		int leftHeight=findHeight(node.left);
		if(leftHeight==-1) return -1;
		
		if(rightHeight-leftHeight>1||rightHeight-leftHeight<-1){
			return -1;
		}
		if(rightHeight>leftHeight)
			return rightHeight+1;
		
		return leftHeight+1;
		
	}
}
