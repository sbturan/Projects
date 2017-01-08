
public class IslandPerimeter {
	public int islandPerimeter(int[][] grid) {

		int result = 0;
		for (int i = 0; i < grid.length; i++) {
			for (int j = 0; j < grid[0].length; j++) {
				if (grid[i][j] == 1) {
					int add = 4;
					if (i > 0 && grid[i - 1][j] == 1) {
						add--;
					}
					if (j > 0 && grid[i][j - 1] == 1) {
						add--;
					}
					if (i < grid.length - 1 && grid[i + 1][j] == 1) {
						add--;
					}
					if (j < grid[0].length - 1 && grid[i][j + 1] == 1) {
						add--;
					}
					result += add;
				}
			}
		}
		
		return result;
	}
}
