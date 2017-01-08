public class AddandSearchWord_DataStructureDesign {

	public static void main(String[] args) {
		AddandSearchWord_DataStructureDesign a = new AddandSearchWord_DataStructureDesign();
		WordDictionary w = a.new WordDictionary();
		w.addWord("at");
		w.addWord("and");
		w.addWord("an");
		w.addWord("add");
		System.out.println(w.search("a"));
		System.out.println(w.search(".at"));
		w.addWord("bat");
		System.out.println(w.search(".at"));
		System.out.println(w.search("an."));
		System.out.println(w.search("a.d."));
		System.out.println(w.search("b."));
		System.out.println(w.search("a.d"));
		System.out.println(w.search("."));
	}


	public class WordDictionary {
		public class MyString {
			char[] value;

			public MyString(String s) {
				value = s.toCharArray();
			}

			public int compareTo(String b) {
				int len1 = value.length;
				int len2 = b.length();
				int lim = Math.min(len1, len2);
				char v1[] = value;
				char v2[] = b.toCharArray();

				int k = 0;
				while (k < lim) {
					char c1 = v1[k];
					char c2 = v2[k];
					if (c2 != '.' && c1 != c2) {
						return c1 - c2;
					}
					k++;
				}
				return len1 - len2;
			}
		}

		class TrieNode {
			// Initialize your data structure here.
			MyString value;
			TrieNode left;
			TrieNode rigth;

			public TrieNode() {

			}
		}
		TrieNode root;

		public void addWord(String word) {
			if (root == null) {
				root = new TrieNode();
				root.value = new MyString(word);
				return;
			}
			TrieNode cur = root;
			while (true) {
				if (cur.value.compareTo(word) > 0) {
					if (cur.left == null) {
						TrieNode left = new TrieNode();
						left.value = new MyString(word);
						cur.left = left;
						return;
					}
					cur = cur.left;
				} else {
					if (cur.rigth == null) {
						TrieNode rigth = new TrieNode();
						rigth.value = new MyString(word);
						cur.rigth = rigth;
						return;
					}
					cur = cur.rigth;
				}
			}
		}

		// Returns if the word is in the data structure. A word could
		// contain the dot character '.' to represent any one letter.
		public boolean search(String word) {
			TrieNode cur = root;
			while (true) {
				if (cur == null)
					return false;
				int compareTo = cur.value.compareTo(word);
				if (compareTo == 0)
					return true;
				if (compareTo < 0) {
					cur = cur.left;
				} else {
					cur = cur.rigth;
				}

			}
		}
	}
	



	// Your WordDictionary object will be instantiated and called as such:
	// WordDictionary wordDictionary = new WordDictionary();
	// wordDictionary.addWord("word");
	// wordDictionary.search("pattern");
}
