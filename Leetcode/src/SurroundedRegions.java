
public class SurroundedRegions {
	public static void main(String[] args) {
		SurroundedRegions s = new SurroundedRegions();
		char[][] board = new char[][] { { 'O', 'O', 'O' }, { 'O', 'O', 'O' }, { 'O', 'O', 'O' } };
		s.solve(board);
	}

	public void solve(char[][] board) {
		if (board.length == 0)
			return;
		boolean[][] notCapture = new boolean[board.length][board[0].length];
		boolean[][] visited = new boolean[board.length][board[0].length];
		for (int i = 0; i < board[0].length; i++) {
			travelZero(0, i, board, visited, notCapture);
		}
		for (int i = 0; i < board[0].length; i++) {
			travelZero(board.length - 1, i, board, visited, notCapture);
		}
		for (int i = 0; i < board.length; i++) {
			travelZero(i, board[0].length - 1, board, visited, notCapture);
		}
		for (int i = 0; i < board.length; i++) {
			travelZero(i, 0, board, visited, notCapture);
		}

		for (int i = 0; i < board.length; i++) {
			for (int j = 0; j < board[0].length; j++) {
				if (!notCapture[i][j]) {
					board[i][j] = 'X';
				}
			}
		}

	}

	private void travelZero(int i, int j, char[][] board, boolean[][] visited, boolean[][] notCapture) {
		// if(i<0||j<0||i>board.length-1||j>board[0].length-1) return;
		// if(board[i][j]!='O'){
		// visited[i][j]=true;
		// return;
		// }
		// if(visited[i][j]) return;
		
		if (board[i][j] != 'O') {
			return;
		}
		visited[i][j] = true;
		notCapture[i][j] = true;
		if (i + 1 < board.length-1 && !visited[i + 1][j] && board[i + 1][j] == 'O')
			travelZero(i + 1, j, board, visited, notCapture);
		if (i  > 1 && !visited[i - 1][j] && board[i - 1][j] == 'O')
			travelZero(i - 1, j, board, visited, notCapture);
		if (j + 1 < board[0].length-1 && !visited[i][j + 1] && board[i][j + 1] == 'O')
			travelZero(i, j + 1, board, visited, notCapture);
		if (j  > 1 && !visited[i][j - 1] && board[i][j - 1] == 'O')
			travelZero(i, j - 1, board, visited, notCapture);
	}
}
