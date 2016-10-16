
public class RemoveDuplicatesfromSortedListII {
	public static void main(String[] args) {
		ListNode l1=new ListNode(1);
		ListNode l2=new ListNode(2);
		ListNode l3=new ListNode(2);
		l1.next=l2;
		l2.next=l3;
		deleteDuplicates(l1);
	}
	public static ListNode deleteDuplicates(ListNode head) {

		ListNode before=null;
		ListNode cur=head;
		if(cur==null) return null;
		boolean girdi=false;
		while(cur.next!=null&&cur.next.val==cur.val){
			girdi=true;
			cur=cur.next;
		}
		if(girdi){
			head=cur.next;
		}
		if(head==null) return null;
		before=head;
		cur=cur.next;
		while(cur!=null&&cur.next!=null){
			while(cur!=null&&cur.next!=null&&cur.val==cur.next.val){
				cur=cur.next;
			}
			before.next=cur.next;
			before=before.next;
			cur=cur.next;
		}
		
		return head;
		
	}
}
