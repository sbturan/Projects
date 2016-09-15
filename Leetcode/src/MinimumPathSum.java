import java.util.Arrays;

public class MinimumPathSum {
	public int minPathSum(int[][] grid) {
		if (grid == null)
			return 0;
		int row = grid.length;
		int column = grid[0].length;
		int dp[][] = new int[row][column];

		return findMinPath(0, 0, grid, dp, row, column);
	}

	private int findMinPath(int i, int j, int[][] grid, int[][] dp, int row, int column) {

		if (i >= row - 1 && j >= column - 1)
			return grid[i][j];
		if (dp[i][j] != 0)
			return dp[i][j];
		int value = grid[i][j];
		if (i == row - 1) {
			dp[i][j] = value + findMinPath(i, j + 1, grid, dp, row, column);
			return dp[i][j];
		}
		if (j == column - 1) {
			dp[i][j] = value + findMinPath(i + 1, j, grid, dp, row, column);
			return dp[i][j];
		}

		dp[i][j] = value
				+ Math.min(findMinPath(i + 1, j, grid, dp, row, column), findMinPath(i, j + 1, grid, dp, row, column));
		return dp[i][j];

	}
}
