
public class PartitionList {
	public static void main(String[] args) {
		ListNode l1=new ListNode(2);
		ListNode l2=new ListNode(1);
		l1.next=l2;
				ListNode partition = partition(l1, 2);
				System.out.println(partition.val);
	}
	public static ListNode partition(ListNode head, int x) {

		ListNode result = null;
		ListNode firstCur = null;
		ListNode secongPart = null;
		ListNode secondCur = null;
		ListNode cur = head;
		while (cur != null) {
			if (cur.val < x) {
				if (result == null) {
					result = cur;
					firstCur = result;
				} else {
					firstCur.next = cur;
					firstCur = cur;
				}
			} else {
				if (secongPart == null) {
					secongPart = cur;
					secondCur = secongPart;
				} else {
					secondCur.next = cur;
					secondCur = cur;
				}
			}
			cur=cur.next;
		}
		if(secondCur!=null)
		secondCur.next=null;
		if(firstCur!=null)
		firstCur.next=null;
		if(result==null) return secongPart;
		firstCur.next=secongPart;
		return result;

	}
}
