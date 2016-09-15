
public class RemoveLinkedListElements {

	public ListNode removeElements(ListNode head, int val) {

		
		ListNode before = null;
		while (head != null && head.val == val) {
			head = head.next;
		}
		ListNode result = head;
		while (head != null) {
			if (head.val == val) {
				before.next = head.next;
				head = before.next;
			} else {
				before = head;
				head = head.next;
			}
		}

		return result;

	}
}
