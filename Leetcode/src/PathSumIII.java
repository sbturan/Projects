import java.util.HashMap;

public class PathSumIII {
	public static void main(String[] args) {
		TreeNode root=Tools.arrayToTree(new Integer[]{10,5,-3,3,2,null,11,3,-2,null,1});
		PathSumIII p=new PathSumIII();
		System.out.println(p.pathSum(root, 8));
	}
	 public int pathSum(TreeNode root, int sum) {
	        HashMap<Integer, Integer> preSum = new HashMap<>();
	        preSum.put(0,1);
	        return helper(root, 0, sum, preSum);
	    }
	    
	    public int helper(TreeNode root, int sum, int target, HashMap<Integer, Integer> preSum) {
	        if (root == null) {
	            return 0;
	        }
	        
	        sum += root.val;
	        int res = preSum.getOrDefault(sum - target, 0);
	        preSum.put(sum, preSum.getOrDefault(sum, 0) + 1);
	        
	        res += helper(root.left, sum, target, preSum) + helper(root.right, sum, target, preSum);
	        preSum.put(sum, preSum.get(sum) - 1);
	        return res;
	    }
}
