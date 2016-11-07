
public class CountNumberswithUniqueDigits {
	public static void main(String[] args) {
		System.out.println(countNumbersWithUniqueDigits(3));
	}
	public static int countNumbersWithUniqueDigits(int n) {
        if(n==0) return 1;
        int result=10;
        int[] dp=new int[n+1];
        dp[1]=9;
        int k=9;
        for(int i=2;i<=n&&k>0;i++){
        	result+=dp[i-1]*k;
        	dp[i]=dp[i-1]*k;
        	k--;
        }
        return result;
	}
}
