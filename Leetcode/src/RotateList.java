
public class RotateList {
	public static void main(String[] args) {
		RotateList r=new RotateList();
		ListNode l=new ListNode(1);
	   System.out.println(r.rotateRight(l, 1));
	}
	public ListNode rotateRight(ListNode head, int k) {
      ListNode last=head;
      if(head==null||k==0) return head;
      int count=1;
      while(last.next!=null){
    	  count++;
    	  last=last.next;
      }
      int t=count-k;
      ListNode first=head;
      ListNode beforeFirst=head;
      while(t>1){
    	  beforeFirst=first;
    	  first=first.next;
    	  t--;
      }
      if(beforeFirst!=null)
      beforeFirst.next=null;
      last.next=head;
      return first; 
	}
}
