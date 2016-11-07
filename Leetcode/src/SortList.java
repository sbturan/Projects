import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class SortList {
	public static void main(String[] args) throws IOException {
		SortList s = new SortList();
		BufferedReader br = new BufferedReader(new FileReader("test"));
		String[] readLine = br.readLine().split(",");
		br.close();
		ListNode head = new ListNode(Integer.valueOf(readLine[0]));
		ListNode cur = head;
		for (int i = 1; i < readLine.length; i++) {
			ListNode n = new ListNode(Integer.valueOf(readLine[i]));
			cur.next = n;
			cur = n;
		}
		ListNode sortList = s.sortList(head);
		while (sortList != null) {
			System.out.println(sortList.val + " ");
			sortList = sortList.next;

		}
	}

	public ListNode sortList(ListNode head) {
		if (head == null || head.next == null)
			return head;

		// step 1. cut the list to two halves
		ListNode prev = null, slow = head, fast = head;

		while (fast != null && fast.next != null) {
			prev = slow;
			slow = slow.next;
			fast = fast.next.next;
		}

		prev.next = null;

		// step 2. sort each half
		ListNode l1 = sortList(head);
		ListNode l2 = sortList(slow);

		// step 3. merge l1 and l2
		return merge(l1, l2);
	}

	ListNode merge(ListNode l1, ListNode l2) {
		ListNode l = new ListNode(0), p = l;

		while (l1 != null && l2 != null) {
			if (l1.val < l2.val) {
				p.next = l1;
				l1 = l1.next;
			} else {
				p.next = l2;
				l2 = l2.next;
			}
			p = p.next;
		}

		if (l1 != null)
			p.next = l1;

		if (l2 != null)
			p.next = l2;

		return l.next;
	}
}
