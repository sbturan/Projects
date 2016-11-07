
public class RangeSumQuery2DImmutable {
	/*[[3,0,1,4,2],[5,6,3,2,1],[1,2,0,1,5],[4,1,0,1,7],[1,0,3,0,5]]
	 * ,sumRegion(2,1,4,3),sumRegion(1,1,2,2),sumRegion(1,2,2,4)*/
	public static void main(String[] args) {
		RangeSumQuery2DImmutable r=new RangeSumQuery2DImmutable();
		int[][] matrix=new int[][]{{3,0,1,4,2},{5,6,3,2,1},{1,2,0,1,5},{4,1,0,1,7},{1,0,3,0,5}};
		NumMatrix n=r.new NumMatrix(matrix);
		System.out.println(n.sumRegion(2, 1,2, 4));
	}
	public class NumMatrix {

		 int [][] sum;
		    public NumMatrix(int[][] matrix) {
		        if (matrix.length == 0 || matrix[0].length == 0)
		            return;
		        sum = new int[matrix.length+1][matrix[0].length+1];
		        for (int i=0; i<matrix.length; i++) {
		            int tmp = 0;
		            for (int j=0; j<matrix[0].length; j++) {
		                tmp += matrix[i][j];
		                sum[i+1][j+1] = sum[i][j+1] + tmp;
		            }
		        }
		    }

		    public int sumRegion(int row1, int col1, int row2, int col2) {
		        if (sum.length == 0)
		            return 0;
		        return sum[row2+1][col2+1] - sum[row2+1][col1] - sum[row1][col2+1] + sum[row1][col1];
		    }
	}

}
