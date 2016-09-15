import java.util.Arrays;
import java.util.Comparator;

public class RussianDollEnvelopes {

	
	public static void main(String[] args) {
	  int[][] envolopes={{2,100},{3,200},{4,300},{5,500},{5,400},{5,250},{6,370},{6,360},{7,380}};
//	  
	  
	  RussianDollEnvelopes rs=new RussianDollEnvelopes();
	  System.out.println(rs.maxEnvelopes(envolopes));
	}
	
	 public  int maxEnvelopes(int[][] envelopes) {
		 
		    if(envelopes == null || envelopes.length == 0 
		       || envelopes[0] == null || envelopes[0].length != 2)
		        return 0;
		    Arrays.sort(envelopes, new Comparator<int[]>(){
		        public int compare(int[] arr1, int[] arr2){
		            if(arr1[0] == arr2[0])
		                return arr2[1] - arr1[1];
		            else
		                return arr1[0] - arr2[0];
		       } 
		    });
		    int dp[] = new int[envelopes.length];
		    int len = 0;
		    for(int[] envelope : envelopes){
		        int index = Arrays.binarySearch(dp, 0, len, envelope[1]);
		        if(index < 0)
		            index = -(index + 1);
		        dp[index] = envelope[1];
		        if(index == len)
		            len++;
		    }
		    return len;
			 }
	 
}
