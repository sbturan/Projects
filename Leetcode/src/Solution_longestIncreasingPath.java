
public class Solution_longestIncreasingPath {

	public static void main(String[] args) {
		int[][] matrix = new int[][] { { 1,2 } };
		Solution_longestIncreasingPath s = new Solution_longestIncreasingPath();
		System.out.println(s.longestIncreasingPath(matrix));
	}

	public  int longestIncreasingPath(int[][] matrix) {

		if (matrix.length == 0)
			return 0;
		line = matrix.length;
		column = matrix[0].length;
		maximumValues=new int[line][column];
		int result=maximumValues[0][0];
		for(int i=0;i<line;i++){
			for(int j=0;j<column;j++){
				int currentResult=maximumValues[i][j];
				if(currentResult==0){
					currentResult=findLongest(matrix, i, j);
				}
				if(currentResult>result){
					result=currentResult;
				}
			}
		}

		return result;
	}

	private static int line;
	private static int column;
	private static int[][] maximumValues;

	private static int findLongest(int[][] matrix, int x, int y) {

		if(maximumValues[x][y]!=0)
			return maximumValues[x][y];
		int rightWayLength = 0;
		int leftWayLength = 0;
		int upWayLength = 0;
		int downWayLength = 0;
		int maximum = 0;
		if (y + 1 < column && matrix[x][y] < matrix[x][y + 1]) {
			rightWayLength = findLongest(matrix, x, y + 1);
			if (rightWayLength > maximum)
				maximum = rightWayLength;
		}
		if (y - 1 > -1 && matrix[x][y] < matrix[x][y - 1]) {
			leftWayLength = findLongest(matrix, x, y - 1);
			if (leftWayLength > maximum)
				maximum = leftWayLength;
		}
		if (x + 1 < line && matrix[x][y] < matrix[x + 1][y]) {
			downWayLength = findLongest(matrix, x + 1, y);
			if (downWayLength > maximum)
				maximum = downWayLength;
		}

		if (x - 1 > -1 && matrix[x][y] < matrix[x - 1][y]) {
			upWayLength = findLongest(matrix, x - 1, y);
			if (upWayLength > maximum)
				maximum = upWayLength;
		}
 
	    maximumValues[x][y]=maximum+1;
		return maximum + 1;

	}

}
