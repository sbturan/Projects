public class BinarySearchTreeIterator {

	public class BSTIterator {

		class TreeNodeWParent {
			TreeNode node;
			TreeNodeWParent parent;
		}

		TreeNodeWParent next = null;

		public BSTIterator(TreeNode root) {
			if (root != null) {
				TreeNodeWParent rootP = new TreeNodeWParent();
				rootP.node = root;
				rootP.parent = null;
				findNext(rootP);
			}

		}

		private void findNext(TreeNodeWParent node) {
			if (node.node.left == null) {
				next = node;
				return;
			}
			TreeNodeWParent cur = node;
			while (cur.node.left != null) {
				TreeNodeWParent left = new TreeNodeWParent();
				left.node = cur.node.left;
				cur.node.left = null;
				left.parent = cur;
				next = left;
				cur = left;
			}
		}

		/** @return whether we have a next smallest number */
		public boolean hasNext() {
			if (next == null)
				return false;
			return true;
		}

		/** @return the next smallest number */
		public int next() {
			if (next == null)
				return -1;
			int retVal = next.node.val;
			TreeNodeWParent keep = next;
			if (next.node.right != null) {
				TreeNodeWParent nextP = new TreeNodeWParent();
				nextP.node = next.node.right;
				next.node.right = null;
				nextP.parent = next;
				findNext(nextP);
			} else {
				TreeNodeWParent cur = next;
				while (cur.parent != null) {
					if (cur.parent.node != null) {
						next.parent = cur.parent;
						break;
					} else {
						cur = cur.parent;
					}
				}
				if (next.parent != null && next.parent.node != null) {
					TreeNodeWParent nextP = new TreeNodeWParent();
					nextP.node = next.parent.node;
					nextP.parent = next.parent.parent;
					if (next.parent.node.left == next.node) {
						next.parent.node.left = null;
					} else if (next.parent.node.right == next.node) {
						next.parent.node.right = null;
					}

					findNext(nextP);

				} else {
					next = null;
				}

			}
			keep.node = null;
			return retVal;
		}
	}
}
