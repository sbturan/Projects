import java.util.PriorityQueue;

public class KthSmallestElementinaSortedMatrix {

	public static void main(String[] args) {
		int sqr = (int) Math.sqrt(8);
		int[][] matrix= new int[][]{{1,2},{1,3}};
		
		System.out.println(kthSmallest(matrix, 4));
	}


	public  static int kthSmallest(int[][] matrix, int k) {
		
		
		 int n = matrix.length;
	        int lo = matrix[0][0], hi = matrix[n - 1][n - 1];
	        while (lo <= hi) {
	            int mid = lo + (hi - lo) / 2;
	            int count = getLessEqual(matrix, mid);
	            if (count < k) lo = mid + 1;
	            else hi = mid - 1;
	        }
	        return lo;
	}
	
	  private static int getLessEqual(int[][] matrix, int val) {
	        int res = 0;
	        int n = matrix.length, i = n - 1, j = 0;
	        while (i >= 0 && j < n) {
	            if (matrix[i][j] > val) i--;
	            else {
	                res += i + 1;
	                j++;
	            }
	        }
	        return res;
	    }

}
