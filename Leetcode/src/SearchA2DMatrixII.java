
public class SearchA2DMatrixII {
	public static void main(String[] args) {
		System.out.println(searchMatrix(new int[][]{{-5}}, -5));
		//System.out.println(searchMatrix(new int[][]{{1,2,3,4,5},{6,7,8,9,10},{11,12,13,14,15},{16,17,18,19,20},{21,22,23,24,25}},15));
		/**
		 * [[1,2,  3, 4,5],
		 * [ 6,7,  8, 9,10],
		 * [11,12,13,14,15],
		 * [16,17,18,19,20],
		 * [21,22,23,24,25]]
                  15
		 * **/
	}
	public static boolean searchMatrix(int[][] matrix, int target) {
 
		int row = matrix.length;
		int column = matrix[0].length;
		if (target < matrix[0][0] || target > matrix[row - 1][column - 1])
			return false;
	    int currentRow=0;
	    while(target>matrix[currentRow][column-1]){currentRow++;}
	    while(currentRow<row){
	    	int start=0,end=column-1;
	    	while(start<=end){
	    		int mid=(start+end)/2;
	    		if(target==matrix[currentRow][mid]) return true;
	    		if(target>matrix[currentRow][mid]) start=mid+1;
	    		else{ end=mid-1;}
	    		
	    	}
	    	currentRow++;
	    }
	    
	    return false;
	    
	}
}
