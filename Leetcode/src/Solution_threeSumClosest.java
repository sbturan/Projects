import java.util.Arrays;

public class Solution_threeSumClosest {
	public static void main(String[] args) {
		int [] nums=new int[]{-5,-3,-2,3,4};
		int target=-1;
		System.out.println(threeSumClosest(nums, target));
	}
	
	public static int threeSumClosest(int[] nums, int target) {

		if(nums.length<3) return 0;
		if(nums.length==3)return nums[0]+nums[1]+nums[2];
		
		Arrays.sort(nums);
		
		
		int min=nums[0]+nums[1]+nums[2];
		int i=0;
		while(i<nums.length-2){
			  
			  int start=i+1;
			  int end=nums.length-1;
			  while(start<end){
				  
				  if(start!=i+1&&nums[start]==nums[start-1]){
					  start++;
					  continue;
				  }
				  if(end!=nums.length-1&&nums[end]==nums[end+1]){
					  end--;
					  continue;
				  }
				  
				  int current=nums[i]+nums[start]+nums[end];
				  if(Math.abs(current-target)<Math.abs(min-target))
					  min=current;
				  
				  if(min==target) return min;
				  
				  if(current>target){
					start=i+1;
					end--;
				    continue;
				  }
				  start++;
			  }
			i++;
		}
		return min;

	}
}
