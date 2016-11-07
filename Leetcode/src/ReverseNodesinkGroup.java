
public class ReverseNodesinkGroup {
	public static void main(String[] args) {
		int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
		ListNode head = new ListNode(array[0]);
		ListNode cur = head;
		for (int i = 1; i < array.length; i++) {
			cur.next = new ListNode(array[i]);
			cur = cur.next;
		}
		ReverseNodesinkGroup r = new ReverseNodesinkGroup();
		ListNode reverseKGroup = r.reverseKGroup(head, 3);
		while (reverseKGroup != null) {
			System.out.print(reverseKGroup.val + " ");
			reverseKGroup = reverseKGroup.next;
		}
	}

	public ListNode reverseKGroup(ListNode head, int k) {
		if (head == null)
			return null;

		ListNode result = null;

		ListNode cur = head;
		int lenght = 0;
		while (cur != null) {
			cur = cur.next;
			lenght++;
		}
		if (lenght == 1 || k > lenght)
			return head;
		cur = head;
		int count = lenght / k;
		ListNode next = null;
		ListNode tt = null;
		while (count > 0) {
			int c = k;
			while (c > 0) {
				ListNode temp = cur.next;
				cur.next = next;
				next = cur;
				cur = temp;
				c--;
			}

			head.next = cur;
			if (tt != null) {
				tt.next = next;
			}
			tt = head;
			if (result == null)
				result = next;
			next = null;
			cur = head.next;
			head = cur;
			count--;
		}

		return result;
	}
}
