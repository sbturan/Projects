import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class BinaryTreeRightSideView {
	public List<Integer> rightSideView(TreeNode root) {
		
		List<Integer> result=new ArrayList<>();
		if(root==null) return result;
        
		Queue<TreeNode> q=new LinkedList<>();
		q.add(root);
		while(!q.isEmpty()){
			int size=q.size();
			TreeNode curNode=null;
			while(size>0){
				size--;
				curNode=q.poll();
				if(curNode.left!=null) q.add(curNode.left);
				if(curNode.right!=null) q.add(curNode.right);
			}
			result.add(curNode.val);
		}
		
		return result;
		
	}

}
