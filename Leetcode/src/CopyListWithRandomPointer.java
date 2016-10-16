import java.util.HashMap;

public class CopyListWithRandomPointer {

	public RandomListNode copyRandomList(RandomListNode head) {
		if (head == null)
			return null;
		HashMap<Integer, RandomListNode> map = new HashMap<>();// Node didn't
																// appear
		HashMap<Integer, RandomListNode> map2 = new HashMap<>();// Node appeared
																// before
		RandomListNode result = new RandomListNode(head.label);
		RandomListNode temp = result;

		while (head != null) {
			if (map2.containsKey(head.label))
				break;
			if (head.next != null) {
				RandomListNode next = map.get(head.next.label);
				if (next == null) {
					temp.next = new RandomListNode(head.next.label);
					map.put(temp.next.label, temp.next);
				} else {
					temp.next = next;
				}
			}
			if (head.random != null) {
				if (map2.containsKey(head.random.label)) {
					temp.random = map2.get(head.random.label);
				} else {
					RandomListNode random = new RandomListNode(head.random.label);
					map.put(random.label, random);
					temp.random = random;
				}
			}
			head = head.next;
			temp = temp.next;
		}

		return result;
	}
}

class RandomListNode {
	int label;
	RandomListNode next, random;

	RandomListNode(int x) {
		this.label = x;
	}
};
