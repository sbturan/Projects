/****** result for n is n th fibonacci number??  *****/
public class ClimbingStairs {
public static void main(String[] args) {
}
	public int climbStairs(int n) {
		if(n<2)return n;
		
		dp=new double[n+1];
		dp[0]=1;
		dp[1]=1;
		double result=0;
       for(int i=0;i<=n/2;i++){
    	   int c=n-i;
    	   result+=calculateCombination(c, i);
       }

       return (int)result;
       
	}
	
	double dp[];
	private double calculateCombination(int n,int r){
		return  (getFactorial(n)/(getFactorial(r)*getFactorial(n-r)));
	}
	private double getFactorial(int n){
		if(dp[n]!=0) return dp[n];
		dp[n]=n*getFactorial(n-1);
		return dp[n];
	}
}
