import java.util.LinkedList;
import java.util.Queue;

public class ImplementStackUsingQueues {

	class MyStack {
		// Push element x onto stack.
		Queue<Integer> q = new LinkedList<>();
		Queue<Integer> q2 = new LinkedList<>();
		boolean addToFirst = true;

		public void push(int x) {
			Queue<Integer> first;
			Queue<Integer> second;
			if (addToFirst) {
				first = q;
				second = q2;

			} else {
				second = q;
				first = q2;
			}

			first.add(x);
			first.addAll(second);
			second.removeAll(second);
			addToFirst = false;

		}

		// Removes the element on top of the stack.
		public void pop() {
			if (!q.isEmpty()) {
				q.remove();
			} else {
				q2.remove();
			}
		}

		// Get the top element.
		public int top() {
			if (!q.isEmpty()) {
				return q.peek();
			} else {
				return q2.peek();
			}
		}

		// Return whether the stack is empty.
		public boolean empty() {
			return q.isEmpty() && q2.isEmpty();
		}
	}
}
