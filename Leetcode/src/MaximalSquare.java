
public class MaximalSquare {
	public static void main(String[] args) {
		/*
		 * "10100", "10111", "11111", "10010"
		 */
		MaximalSquare m = new MaximalSquare();
		char[][] matrix = new char[][] { { '1', '0', '1', '0', '0' }, { '1', '0', '1', '1', '1' },
				{ '1', '1', '1', '1', '1' }, { '1', '0', '0', '1', '0' } };

		System.out.println(m.maximalSquare(matrix));
	}

	public int maximalSquare(char[][] matrix) {

		int result = 0;
		for (int i = 0; i < matrix.length; i++) {
			for (int j = 0; j < matrix[0].length; j++) {
				if (matrix[i][j] == '1') {
					int k = i + 1;
					int l = j + 1;
					int n = 1;
					while (k < matrix.length && l < matrix[0].length) {
						boolean isSquare = true;
						for (int d = i; d <= k; d++) {
							if (matrix[d][l] == '0') {
								isSquare = false;
								break;
							}
						}
						if (isSquare) {
							for (int h = j; h <= l; h++) {
								if (matrix[k][h] == '0') {
									isSquare = false;
									break;
								}
							}
						}
						if (isSquare) {
							n++;
							k++;
							l++;
						} else {
							break;
						}
					}

					result = Math.max(result, n * n);
				}
			}
		}

		return result;

	}

}
