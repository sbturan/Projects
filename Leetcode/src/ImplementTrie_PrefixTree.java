public class ImplementTrie_PrefixTree {
	public static void main(String[] args) {
		String s="asd";
		System.out.println(s.matches("a.*"));
		System.out.println(s.matches("asd"));
	}
	class TrieNode {
		// Initialize your data structure here.
		String value;
		TrieNode left;
		TrieNode rigth;

		public TrieNode() {

		}
	}

	public class Trie {
		private TrieNode root;

		public Trie() {
			root = new TrieNode();
		}

		// Inserts a word into the trie.
		public void insert(String word) {
			if (word == null)
				return;
			if (root.value == null) {
				root.value = word;
				return;
			}

			TrieNode cur = root;
			while (true) {
				if (word.compareTo(cur.value) < 0) {
					if (cur.left == null) {
						TrieNode t = new TrieNode();
						t.value = new String(word);
						cur.left = t;
						return;
					}
					cur = cur.left;
				} else {
					if (cur.rigth == null) {
						TrieNode t = new TrieNode();
						t.value = new String(word);
						cur.rigth = t;
						return;
					}
					cur = cur.rigth;
				}
			}

		}

		// Returns if the word is in the trie.
		public boolean search(String word) {
			
			TrieNode cur = root;
			if(word==null||cur.value==null) return false;
			while (cur != null) {
				if (word.matches(cur.value)) {
					return true;
				}
				if (word.compareTo(cur.value) < 0) {
					cur = cur.left;
				} else {
					cur = cur.rigth;
				}
			}
			return false;
		}

		// Returns if there is any word in the trie
		// that starts with the given prefix.
		public boolean startsWith(String prefix) {
         return search(prefix.concat(".*"));
		}
	}
}
