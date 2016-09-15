
public class Solution_integerBreak {
	
	public static void main(String[] args) {
	
		Solution_integerBreak s=new Solution_integerBreak();
		System.out.println(s.integerBreak(16));
		
	}


	public int integerBreak(int n) {
		
		if (n==2||n==3) return n-1;

		int[] values=new int[]{2,3};
		 int result=1;
		for(Integer value:values){
			int powerValue=n/value;
			int lastValue=n-(powerValue*value);
			if(lastValue==1){
				powerValue--;
				lastValue+=value;
			}else if(lastValue==0) lastValue=1;
			
			result=Math.max(result, (int)Math.pow(value, powerValue)*lastValue);
		}
		return result;
		
// 		 int value;
//		 double sqrRoot=Math.sqrt(n);
//		 int sqrRootInt=(int)sqrRoot;
//		 value=sqrRootInt;
//		
//		 int powerValue=n/value;
//		 int lastValue=n-(powerValue*value);
//		 if(lastValue==1&&powerValue!=1){
//			 powerValue--;
//			 lastValue=lastValue+value;
//		 }else if(lastValue==0) lastValue=1;
//		 
//		 int result1=(int)Math.pow(value, powerValue)*lastValue;
//		
//		 value++;
//		 if(value==n){
//			 return result1;
//		 }
//		  powerValue=n/value;
//		   lastValue=n-(powerValue*value);
//			 if(lastValue==1&&powerValue!=1){
//				 powerValue--;
//				 lastValue=lastValue+value;
//			 }else if(lastValue==0) lastValue=1;
//		 int result2=(int)Math.pow(value, powerValue)*lastValue;
//		 
//		 
//		 
//		 
//		 
//		 
//		return Math.max(result1, result2);
	}
}
