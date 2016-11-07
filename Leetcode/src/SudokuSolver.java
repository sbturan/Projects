public class SudokuSolver {
	public static void main(String[] args) {
		SudokuSolver s = new SudokuSolver();
		String[] b = { "5...3..1.", ".3.4.9...", ".......36", "8.6......", ".27.8.35.", "......8.9", "25.......",
				"...1.4.7.", ".8..9...3" };

		char[][] board = new char[b.length][b[0].length()];
		int i = 0;
		for (String sa : b) {
			int j = 0;
			char[] charArray = sa.toCharArray();

			for (char c : charArray) {
				board[i][j++] = c;
				System.out.print(c + " ");
			}
			i++;
			System.out.println();
		}
		s.solveSudoku(board);
		System.out.println();
		for (i = 0; i < board.length; i++) {
			for (int j = 0; j < board[0].length; j++) {
				System.out.print(board[i][j] + " ");
			}
			System.out.println();
		}
	}

	public void solveSudoku(char[][] board) {
		boolean[][] col = new boolean[9][10];
		boolean[][] row = new boolean[9][10];
		boolean[][] box = new boolean[9][10];
		for (int i = 0; i < board.length; i++) {
			for (int j = 0; j < board[0].length; j++) {
				if (board[i][j] != '.') {
					int val = ((int) board[i][j]) - '0';
					col[j][val] = true;
					row[i][val] = true;
					int squareKey = (i / 3) * 3 + (j / 3);
					box[squareKey][val] = true;
				}

			}
		}
		solveAPoint(board, 0, 0, row, col, box);

	}

	private boolean solveAPoint(char[][] board, int x, int y, boolean[][] lines, boolean[][] columns,
			boolean[][] squares) {
		if (x > 8)
			return true;
		if (board[x][y] != '.') {
			y++;
			if (y == 9) {
				y = 0;
				x++;
			}
			return solveAPoint(board, x, y, lines, columns, squares);
		}

		int squareKey = (x / 3) * 3 + (y / 3);
		for (int i = 1; i < 10; i++) {
			if (!lines[x][i] && !columns[y][i] && !squares[squareKey][i]) {
				board[x][y] = (char) (i + '0');
				lines[x][i] = true;
				columns[y][i] = true;
				squares[squareKey][i] = true;
				int k = x;
				int l = y;
				l++;
				if (l == 9) {
					l = 0;
					k++;
				}
				if (solveAPoint(board, k, l, lines, columns, squares)) {
					return true;
				}
				lines[x][i] = false;
				columns[y][i] = false;
				squares[squareKey][i] = false;
				board[x][y] = '.';
			}
		}
		return false;

	}
}
