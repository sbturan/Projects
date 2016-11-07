
public class ConvertSortedArraytoBinarySearchTree {
   public TreeNode sortedArrayToBST(int[] nums) {
     
	   return helper(nums, 0,nums.length-1);
   }
   
   private TreeNode helper(int[] nums,int start,int end){
	    
	   if(start>end||start<0||end>nums.length-1) return null;
	   int mid=(start+end)/2;
	   TreeNode head=new TreeNode(nums[mid]);
	   head.left=helper(nums,start, mid-1);
	   head.right=helper(nums,mid+1, end);
	   return head;
	   
   }
}
