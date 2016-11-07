import java.util.ArrayList;
import java.util.List;

public class SpiralMatrix {
	public static void main(String[] args) {
		System.out.println(spiralOrder(new int[][]{{6,9,7}}));
	}
	public static List<Integer> spiralOrder(int[][] matrix) {
		List<Integer> result=new ArrayList<>();
		if(matrix.length==0) return result;
       int i=0;
       int j=0;
       int top=1;
       int left=0;
       int right=matrix[0].length-1;
       int bottom=matrix.length-1;
       while(left<=right){
    	   while(j<=right){
    		   result.add(matrix[i][j]);
    		   j++;
    	   }
    	   right--;
    	   j--;
    	   i++;
    	   while(i<=bottom){
    		   result.add(matrix[i][j]);
    		   i++;
    	   }
    	   bottom++;
    	   i--;
    	   j--;
    	   while(j>=left){
    		   result.add(matrix[i][j]);
    		   j--;
    	   }
    	   left++;
    	   j++;
    	   i--;
    	   while(i>=top){
    		   result.add(matrix[i][j]);
    		   i--;
    	   }
    	   top++;
    	   i++;
    	   j++;
       }
       return result;
			
	}
}
