import java.util.Hashtable;

public class LRUCache {
   public static void main(String[] args) {
	LRUCache cache=new LRUCache(2);
	int[] keys=new int[]{3,4};
	for(int i:keys){
		cache.set(i, 4);
	}
	
	cache.get(3);
	cache.set(5, 4);
	for(int i: keys){
		System.out.println(i+" "+cache.get(i));
	}
	
}
	class DLinkedNode {
		int key;
		int value;
		DLinkedNode pre;
		DLinkedNode post;
	}

	/**
	 * Always add the new node right after head;
	 */
	private void addNode(DLinkedNode node) {
		node.pre = head;
		node.post = head.post;

		head.post.pre = node;
		head.post = node;
	}

	/**
	 * Remove an existing node from the linked list.
	 */
	private void removeNode(DLinkedNode node) {
		DLinkedNode pre = node.pre;
		DLinkedNode post = node.post;

		pre.post = post;
		post.pre = pre;
	}

	/**
	 * Move certain node in between to the head.
	 */
	private void moveToHead(DLinkedNode node) {
		this.removeNode(node);
		this.addNode(node);
	}

	// pop the current tail.
	private DLinkedNode popTail() {
		DLinkedNode res = tail.pre;
		this.removeNode(res);
		return res;
	}

	private Hashtable<Integer, DLinkedNode> cache = new Hashtable<Integer, DLinkedNode>();
	private int count;
	private int capacity;
	private DLinkedNode head, tail;

	public LRUCache(int capacity) {
		this.count = 0;
		this.capacity = capacity;

		head = new DLinkedNode();
		head.pre = null;

		tail = new DLinkedNode();
		tail.post = null;

		head.post = tail;
		tail.pre = head;
	}

	public int get(int key) {

		DLinkedNode node = cache.get(key);
		if (node == null) {
			return -1; // should raise exception here.
		}

		// move the accessed node to the head;
		this.moveToHead(node);

		return node.value;
	}

	public void set(int key, int value) {
		DLinkedNode node = cache.get(key);

		if (node == null) {

			DLinkedNode newNode = new DLinkedNode();
			newNode.key = key;
			newNode.value = value;

			this.cache.put(key, newNode);
			this.addNode(newNode);

			++count;

			if (count > capacity) {
				// pop the tail
				DLinkedNode tail = this.popTail();
				this.cache.remove(tail.key);
				--count;
			}
		} else {
			// update the value.
			node.value = value;
			this.moveToHead(node);
		}

	}
}

// public class LRUCache {
//
// int[] values;
// int[] keys;
// int[] gen; // some generation of value
// int size;
// int lastGen;
//
// public LRUCache(int capacity) {
// values = new int[capacity];
// keys = new int[capacity];
// gen = new int[capacity];
// size = 0;
// lastGen = 0;
// }
//
// public int get(int key) {
// int val = -1;
// for (int i = 0; i < size && val == -1; i++)
// if (keys[i] == key) {
// val = values[i];
// // update generation to least recently used
// gen[i] = ++lastGen;
// }
//
// return val;
// }
//
// public void set(int key, int value) {
// int ind = -1;
// boolean inserted = false;
// for (int i = 0; i < size && !inserted; i++) {
// if (keys[i] == key) {
// inserted = true;
// ind = i;
// }
// }
//
// if (!inserted) {
// if (size == keys.length) {
// int min = Integer.MAX_VALUE;
// for (int i = 0; i < size; i++) {
// if (gen[i] < min) {
// ind = i;
// min = gen[i];
// }
// }
// } else {
// ind = size;
// size++;
// }
// }
// keys[ind] = key;
// values[ind] = value;
// gen[ind] = ++lastGen;
// }
// }