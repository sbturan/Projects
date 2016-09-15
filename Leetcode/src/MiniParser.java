import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class MiniParser {

	public static void main(String[] args) {

	}

	public NestedInteger deserialize(String s) {
		if (s.charAt(0) != '[')
			return new NestedInteger(Integer.parseInt(s));
		NestedInteger cur = new NestedInteger();
		Stack<NestedInteger> stack = new Stack<>();
		for (int i = 1, start = 1; i < s.length(); ++i) {
			if (s.charAt(i) == '[') {
				stack.push(cur);
				cur = new NestedInteger();
				stack.peek().add(cur);
				start = i + 1;
			} else if (s.charAt(i) == ']' || s.charAt(i) == ',') {
				if (start < i)
					cur.add(new NestedInteger(Integer.parseInt(s.substring(start, i))));
				start = i + 1;
				if (s.charAt(i) == ']' && !stack.empty())
					cur = stack.pop();
			}
		}
		return cur;
	}

	/*
	 * Given s = "[123,[456,[789]]]",
	 * 
	 * Return a NestedInteger object containing a nested list with 2 elements:
	 * 
	 * 1. An integer containing value 123. 2. A nested list containing two
	 * elements: i. An integer containing value 456. ii. A nested list with one
	 * element: a. An integer containing value 789.
	 */

	// This is the interface that allows for creating nested lists.
	// You should not implement it, or speculate about its implementation
	public static class NestedInteger {
		// Constructor initializes an empty nested list.
		public NestedInteger() {
		}

		// Constructor initializes a single integer.
		public NestedInteger(int value) {
		}

		// @return true if this NestedInteger holds a single integer, rather
		// than a nested list.
		public boolean isInteger() {
			return false;
		}

		// @return the single integer that this NestedInteger holds, if it holds
		// a single integer
		// Return null if this NestedInteger holds a nested list
		public Integer getInteger() {
			return null;
		}

		// Set this NestedInteger to hold a single integer.
		public void setInteger(int value) {
		}

		// Set this NestedInteger to hold a nested list and adds a nested
		// integer to it.
		public void add(NestedInteger ni) {
		}

		// @return the nested list that this NestedInteger holds, if it holds a
		// nested list
		// Return null if this NestedInteger holds a single integer
		public List<NestedInteger> getList() {
			return null;
		}
	}

}
