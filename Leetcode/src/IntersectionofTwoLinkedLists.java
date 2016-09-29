public class IntersectionofTwoLinkedLists {
	public ListNode getIntersectionNode(ListNode headA, ListNode headB) {

		int le1 = 0, le2 = 0;
		ListNode l1 = headA;
		ListNode l2 = headB;
		while (l1 != null) {
			l1 = l1.next;
			le1++;
		}
		while (l2 != null) {
			l2 = l2.next;
			le2++;
		}
		l1 = headA;
		l2 = headB;
		if (le1 > le2) {
			while (le1 > le2) {
				l1 = l1.next;
				le1--;
			}
		} else {
			while (le2 > le1) {
				l2 = l2.next;
				le2--;
			}
		}

		while (l1 != null && l1.val != l2.val) {
			l1 = l1.next;
			l2 = l2.next;
		}

		return l1;
        
//		Set<Integer> set=new HashSet<>();
//		while(headA!=null){
//			set.add(headA.val);
//			headA=headA.next;
//		}
//		while(headB!=null){
//			if(set.contains(headB.val)){
//              return headB;				
//			}
//			headB=headB.next;
//		}
//		return null;
		
	}
}
