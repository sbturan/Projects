import java.util.ArrayList;

public class SetMatrixZeroes {
	public void setZeroes(int[][] matrix) {

		ArrayList<Integer> zeroRows = new ArrayList<>();
		ArrayList<Integer> zeroColumns = new ArrayList<>();
		for (int i = 0; i < matrix.length; i++) {
			boolean isZero = false;
			int j = 0;
			while (j < matrix[0].length && !isZero) {
				isZero = matrix[i][j] == 0;
				j++;
			}
			if (isZero)
				zeroRows.add(i);
		}
		for (int i = 0; i < matrix[0].length; i++) {
			boolean isZero = false;
			int j = 0;
			while (j < matrix.length && !isZero) {
				isZero = matrix[j][i] == 0;
				j++;
			}
			if (isZero)
				zeroColumns.add(i);
		}

		for (int i : zeroColumns) {
			for (int j = 0; j < matrix.length; j++) {
				matrix[j][i] = 0;
			}
		}

		for (int i : zeroRows) {
			for (int j = 0; j < matrix[0].length; j++) {
				matrix[i][j] = 0;
			}
		}
	}
}
