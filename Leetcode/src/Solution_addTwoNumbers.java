
public class Solution_addTwoNumbers {
	public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
		int cc=0;
		int firstResult=l1.val+l2.val;
		
		if(firstResult>=10){
			cc=1;
			firstResult=firstResult-10;
		}
		ListNode before=new ListNode(firstResult);
		ListNode first=before;
		while(true){
			if(l1!=null)
			l1=l1.next;
			if(l2!=null)
			l2=l2.next;
			if(l1==null&&l2==null) break;
			int currentResult=cc;
			if(l1!=null)
				currentResult+=l1.val;
			if(l2!=null)
				currentResult+=l2.val;
			if(currentResult>=10){
				int cc2=currentResult%10;
				cc=(currentResult-cc2)/10;
				currentResult=cc2;
				
			}else{
				cc=0;
			}
			
			ListNode currentNode=new ListNode(currentResult);
			before.next=currentNode;
			before=currentNode;
		}
		
		if(cc!=0){
			ListNode last=new ListNode(cc);
			before.next=last;
		}
		return first;
	}
}
