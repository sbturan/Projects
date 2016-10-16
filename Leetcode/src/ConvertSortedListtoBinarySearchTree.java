import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.LinkedList;

public class ConvertSortedListtoBinarySearchTree {
	public static void main(String[] args) {
		ConvertSortedListtoBinarySearchTree c=new ConvertSortedListtoBinarySearchTree();
		ListNode l=new ListNode(0);
		c.sortedListToBST(l);
	}
	 public TreeNode sortedListToBST(ListNode head) {
	   
		 if(head==null) return null;
	   int size=0;
	   ListNode cur=head;
	   while(cur!=null){
		   size++;
		   cur=cur.next;
	   }
	   int[] array=new int[size];
	   size=0;
	   cur=head;
	   while(cur!=null){
		   array[size++]=cur.val;
		   cur=cur.next;
	   }
	   
	   return helper(array, 0, array.length);
	   
	 }
	 private TreeNode helper(int[] array,int begin,int end){
		 if(begin>end) return null;
		 if(begin==end) return new TreeNode(array[begin]);
		 TreeNode node=new TreeNode(array[(begin+end)/2]);
		 node.left=helper(array, begin, begin+end/2);
		 node.right=helper(array, begin+end/2,end);
		 return node;
	 }
	 
	 
}
