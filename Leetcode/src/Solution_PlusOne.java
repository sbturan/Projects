
public class Solution_PlusOne {
	
	public static void main(String[] args) {
		Solution_PlusOne s=new Solution_PlusOne();
		int[] nums=new int[]{0};
		int[] plusOne = s.plusOne(nums);
		
	}
	 public int[] plusOne(int[] digits) {
	     
		 if(digits==null||digits.length==0) return null;

		 
		 
		 for(int i=digits.length-1;i>-1;i--){
			 digits[i]=digits[i]+1;
			 if(digits[i]==10){
				 digits[i]=0;
			 }else{
				 break;
			 }
		 }
		 
		 if(digits[0]==0){
			 int[] result= new int[digits.length+1];
			 int[] firstNum=new int[]{1};
			 System.arraycopy(firstNum, 0, result, 0, 1);
			 System.arraycopy(digits, 0, result, 1, digits.length);
			 return result;
		 }
		 return digits;
	    }
}
