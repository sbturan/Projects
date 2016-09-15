import java.util.Random;

public class LinkedListRandomNode {

	
	public class Solution {

	    /** @param head The linked list's head.
	        Note that the head is guaranteed to be not null, so it contains at least one node. */
		ListNode node;
		int length=1;
		Random rd=new Random();
	    public Solution(ListNode head) {
	        this.node=head;
	        ListNode temp=head;
	        int count=0;
	        while(temp.next!=null){
	        	temp=temp.next;
	        	count++;
	        }
	        this.length=count;
	    }
	    
	    /** Returns a random node's value. */
	    public int getRandom() {
         
         int current=rd.nextInt(length);
         ListNode retVal=node;
         while(current>=0){
        	 retVal=retVal.next;
        	 current--;
         }
         return retVal.val ;
         
	    }
	}
}
