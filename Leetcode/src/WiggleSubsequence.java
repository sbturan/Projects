
public class WiggleSubsequence {
	public static void main(String[] args) {
		WiggleSubsequence es = new WiggleSubsequence();
		System.out.println(es.wiggleMaxLength(new int[]{1,7,4,9,2,5}));
	}

	public int wiggleMaxLength(int[] nums) {

		if (nums.length <2)
			{
			 return nums.length;
		}
		if(nums.length==2) return (nums[0]!=nums[1])? 2: 0;
		int result =1;
		int i=0;
		while(i<nums.length-2&&nums[i]==nums[i+1]) i++;
		boolean current = nums[i] > nums[i+1];
		if(current)current=false;else current=true;
		for ( ; i < nums.length - 1; i++) {
			if (current) {
				if (nums[i] >= nums[i + 1])
				continue;
				current = false;
			} else {
				if (nums[i] <= nums[i + 1])
				continue;
				current = true;
			}
			result++;
		}
		return result;
	}
}
