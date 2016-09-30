public class WordSearch {
	public boolean exist(char[][] board, String word) {

		if (word.length() == 0)
			return true;
		char[] charArray = word.toCharArray();
		for (int i = 0; i < board.length; i++) {
			for (int j = 0; j < board[0].length; j++) {
				if (helper(i, j,0,charArray,board)) {
					return true;
				}
			}
		}
		return false;
	}

	boolean helper(int x, int y, int index,char[] chars, char[][] board) {
		if (index==chars.length)
			return true;
		if (x < 0 || y < 0 || x >= board.length || y >= board[0].length)
			return false;
		char c = chars[index];
		if (board[x][y] != c)
			return false;
		board[x][y] = '$';
		Boolean result = helper(x + 1, y,index+1,chars, board) || helper(x - 1, y,index+1,chars, board)
				|| helper(x, y + 1,index+1,chars, board)
				|| helper(x, y - 1, index+1,chars, board);
		board[x][y] = c;
		return result;
	}
}
