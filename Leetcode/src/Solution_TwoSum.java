import java.util.HashMap;

public class Solution_TwoSum {
	
	public static void main(String[] args) {
		Solution_TwoSum s = new Solution_TwoSum();
		int nums[]=new int[]{3,2,4};
		int target=6;
		s.twoSum(nums, target);
	}
public int[] twoSum(int[] nums, int target) {
    
	HashMap<Integer,Integer> numsMap=new HashMap<>();
	for(int i=0;i<nums.length;i++){
		numsMap.put(nums[i],i);
	}
	
	int[] result=new int[2];
	
	for(int i=0;i<nums.length;i++){
		Integer value=numsMap.get(target-nums[i]);
		if(value!=null&&value!=i){
		   result[0]=i;
		   result[1]=value;
		   return result;
		}
		
	}
	
	return result;
    }
}
