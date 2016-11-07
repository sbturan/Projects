public class RotateImage {
	public void rotate(int[][] matrix) {
		int cstart = 0, cend = matrix.length - 2;
		for (int i = 0; i <= matrix.length / 2; i++) {
			for (int k = cstart; k <= cend; k++) {
				rotateAPoint(matrix, i, k);
			}
			cstart++;
			cend--;
		}
	}

	private void rotateAPoint(int[][] matrix, int x, int y) {
		int temp = matrix[x][y];
		matrix[x][y] = matrix[matrix.length - y-1][x];
		matrix[matrix.length - y-1][x] = matrix[matrix.length - x-1][matrix.length - y-1];
		matrix[matrix.length - x-1][matrix.length - y-1] = matrix[y][matrix.length - x-1];
		matrix[y][matrix.length - x-1] = temp;
	}

}
