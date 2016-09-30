import java.util.LinkedList;
import java.util.Queue;

public class SymmetricTree {
	public static void main(String[] args) {
		 TreeNode t1 = new TreeNode(1);
		 TreeNode t2 = new TreeNode(2);
		 TreeNode t3 = new TreeNode(2);
		 TreeNode t4 = new TreeNode(3);
		 TreeNode t5 = new TreeNode(4);
		 TreeNode t6 = new TreeNode(4);
		 TreeNode t7 = new TreeNode(3);
		 t1.left = t2;
		 t1.right = t3;
		 t2.left = t4;
		 t2.right = t5;
		 t3.left = t6;
		 t3.right = t7;
//		TreeNode t1 = new TreeNode(1);
//		TreeNode t2 = new TreeNode(2);
//		t1.left = t2;
		System.out.println(isSymmetric(t1));
	}

	public static boolean isSymmetric2(TreeNode root) {
		Queue<TreeNode> queue=new LinkedList<TreeNode>();
        if(root==null) return true;
        queue.add(root.left);
        queue.add(root.right);
        while(!queue.isEmpty()){
        	TreeNode t1=queue.poll();
        	TreeNode t2=queue.poll();
        	if(t1==null&&t2==null) continue;
        	if(t1==null||t2==null) return false;
        	if(t1.val!=t2.val) return false;
        	queue.add(t1.left);
        	queue.add(t2.right);
        	queue.add(t1.right);
        	queue.add(t2.left);
        }
        
        return true;
	}
	public static boolean isSymmetric(TreeNode root) {
      
		if(root==null) return true;
		return helper(root.left, root.right);
	}
	
	private static boolean helper(TreeNode n1,TreeNode n2){
		
		if(n1==null&&n2==null) return true;
		if(n1==null||n2==null) return false;
		return (n1.val==n2.val)&&helper(n1.left, n2.right)&&helper(n1.right, n2.left);
		
	}
	
}
