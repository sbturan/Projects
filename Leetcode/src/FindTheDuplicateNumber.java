import java.util.Arrays;

public class FindTheDuplicateNumber {
	public int findDuplicate(int[] nums) {
		 Arrays.sort(nums);
	       int i=1;
	       while(i<nums.length){
	    	   if(nums[i-1]==nums[i]) return nums[i];
	    	   i++;
	       }

	       return 0;
	}
}
