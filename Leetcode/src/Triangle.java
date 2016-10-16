import java.util.List;

public class Triangle {
	 public int minimumTotal(List<List<Integer>> triangle) {
	        
		 if(triangle==null||triangle.isEmpty()) return 0;
		 int[][] dp=new int[triangle.size()][triangle.get(triangle.size()-1).size()];
		 return helper(triangle, 0, 0,dp);
	 }
	 private int helper(List<List<Integer>> triangle,int level,int seq, int[][] dp){
    	 if(level==triangle.size()) return 0;
		if(dp[level][seq]!=0) return dp[level][seq];
		int value=triangle.get(level).get(seq)+Math.min(helper(triangle, level+1, seq,dp), helper(triangle, level+1, seq+1,dp));
		dp[level][seq]=value;
		return value;
 	 }
}
