
public class Searcha2DMatrix {

	public static void main(String[] args) {
		System.out.println(searchMatrix(new int[][]{{1,1}}, 2));
	}
	 public static boolean searchMatrix(int[][] matrix, int target) {
	     
		 if(matrix==null) return false;
		 int row=matrix.length;
		 int column=matrix[0].length;
		 int start=0;
		 int end=(row*column)-1;
		 int k1,k2;
		 while(start<=end){
			 k1=((start+end)/2)/column;
			 k2=((start+end)/2)%column;
			 if(target==matrix[k1][k2]) return true;
			 if(target>matrix[k1][k2]) start=((start+end)/2)+1;
			 else{
				 end=((start+end)/2)-1;
			 }
					 
			 
		 }
		 
		 return false;
	    }
}
