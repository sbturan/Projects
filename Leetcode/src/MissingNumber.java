
public class MissingNumber {
	 public int missingNumber(int[] nums) {
		 int length=nums.length;
		 int total=0;
		 for(int i:nums){
			 total+=i;
		 }
		 return length*(length+1)/2-total;
	 }
}
