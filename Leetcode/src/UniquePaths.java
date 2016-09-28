
public class UniquePaths {
	public static void main(String[] args) {
		for(int i=2;i<7;i++){
			for(int j=2;j<7;j++){
				System.out.println(i+" "+j+" "+uniquePaths(i, j));
			}
		}
	}
	public static int uniquePaths(int m, int n) {

		int [][] dp=new int[m+1][n+1];
		dp[1][1]=1;
		return helper(m, n, m, n, dp);
	}
   
	private static int helper(int x,int y,int m,int n,int dp[][]){
		
		if(dp[x][y]!=0) return dp[x][y];
		int result=0;
		if(y!=1){
			result+=dp[x][y]=helper(x, y-1, m, n, dp);
		}
		if(x!=1){
			result+=dp[x][y]=helper(x-1, y, m, n, dp);
		}
		dp[x][y]=result;
		return result; 
	}
}

