
public class PalindromeLinkedList {
	public static void main(String[] args) {
		ListNode l1=new ListNode(1);
		ListNode l2=new ListNode(2);
		ListNode l3=new ListNode(2);
		ListNode l4=new ListNode(1);
		l1.next=l2;
		l2.next=l3;
		l3.next=l4;
		System.out.println(isPalindrome(l1));
	}
	public static boolean isPalindrome(ListNode head) {
        if(head==null||head.next==null) return true;
        if(head.next.next==null) return head.next.val==head.val;
		ListNode cur1=head;
		ListNode cur2=head;
		int lenght=0;
		ListNode before=null;
		while(cur2!=null&&cur2.next!=null){
			lenght++;
			before=cur1;
			cur1=cur1.next;
			cur2=cur2.next.next;
		}
		
		while(cur1.next!=null){
			ListNode temp=cur1.next;
			cur1.next=before;
			before=cur1;
			cur1=temp;
		}
		cur1.next=before;
		ListNode h=head;
		while(lenght>-1){
			if(cur1.val!=h.val) return false;
			cur1=cur1.next;
			h=h.next;
			lenght--;
		}
		
		return true;
		
	}
}
