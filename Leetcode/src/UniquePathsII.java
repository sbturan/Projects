public class UniquePathsII {
	   public int uniquePathsWithObstacles(int[][] obstacleGrid) {
	     
		   int[][] dp=new int[obstacleGrid.length][obstacleGrid[0].length];
		   dp[0][0]=1;
		   return helper(obstacleGrid,dp,obstacleGrid.length-1,obstacleGrid[0].length-1);
		   
	    }
	   private static int helper(int[][] grid,int[][] dp,int x,int y){
		   
		   if(x==-1||y==-1||grid[x][y]==1) return 0;
		   if(dp[x][y]!=0) return dp[x][y];
		   int result=0;
           result+=helper(grid, dp, x-1, y);
           result+=helper(grid, dp, x, y-1);
           dp[x][y]=result;
           return result;
	   }
}
