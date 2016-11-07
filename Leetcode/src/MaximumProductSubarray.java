public class MaximumProductSubarray {
	public static void main(String[] args) {
		System.out.println(maxProduct(new int[]{-2,0,-1}));
	}
	public static int maxProduct(int[] nums) {

		 int max = Integer.MIN_VALUE, product = 1;
		    int len = nums.length;

		    for(int i = 0; i < len; i++) {
		        max = Math.max(product *= nums[i], max);
		        if (nums[i] == 0) product = 1;
		    }

		    product = 1;
		    for(int i = len - 1; i >= 0; i--) {
		        max = Math.max(product *= nums[i], max);
		        if (nums[i] == 0) product = 1;
		    }

		    return max;
		
		
	}
	
}
