import java.util.ArrayList;
import java.util.List;

public class LowestCommonAncestorofaBinaryTree {
	public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
		List<TreeNode> list1=new ArrayList<>();
		List<TreeNode> list2=new ArrayList<>();
		findAncestores(list1, root, p);
		findAncestores(list2, root, q);
		for(int i=list1.size()-1;i>-1;i--){
			if(list2.contains(list1.get(i))){
				return list1.get(i);
			}
		}
		return null;
	}
	
	private boolean findAncestores(List<TreeNode> list, TreeNode root,TreeNode t){
		if(root.val==t.val){
			list.add(root);
			return true;
		}
		if(root.left!=null){
			list.add(root.left);
			boolean r = findAncestores(list, root.left, t);
			if(r){
				return true;
			}
			   list.remove(list.size()-1);
		}
	 
		if(root.right!=null){
			list.add(root.right);
			if(findAncestores(list, root.right, t)){
				return true;
			}
			list.remove(list.size()-1);
		}
		
		return false;
	}
}
