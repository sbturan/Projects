
public class MaximalRectangle {
	public static void main(String[] args) {
		MaximalRectangle m=new MaximalRectangle();
		char[][] matrix=new char[][]{{'1','0','1','0','0'},{'1','0','1','1','1'},{'1','1','1','1','1'},{'1','0','0','1','0'}};
		System.out.println(m.maximalRectangle(matrix));
	}
	public int maximalRectangle(char[][] matrix) {
       int result=0;
		for(int i=0;i<matrix.length;i++){
			for(int j=0;j<matrix[0].length;j++){
				if(matrix[i][j]=='1'){
					result=Math.max(result, checkApoint(matrix, i, j));
				}
			}
		}
		return result;
 		
	}

	private int checkApoint(char[][] matrix, int i, int j) {
		int a=1;
		int k=j+1;
		while(k<matrix[0].length&&matrix[i][k]=='1'){
			k++;
			a++;
		}
		int l=i-1;
		int b=1;
		boolean exist=true;
		while(l>-1&&exist){
			for(int t=j;t<j+a;t++){
				if(matrix[l][t]!='1'){
					exist=false;
					break;
				}
			}
			if(exist){
				l--;
				b++;	
			}
			
		}
		exist=true;
		l=i+1;
		while(l<matrix.length&&exist){
			for(int t=j;t<j+a;t++){
				if(matrix[l][t]!='1'){
					exist=false;
					break;
				}
			}
			if(exist){
			l++;
			b++;
			}
		}
		return a*b;
	}
}
