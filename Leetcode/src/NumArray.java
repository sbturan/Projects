public class NumArray {
  
    public int[] numbers;
    public NumArray(int[] nums) {
        if(nums!=null) {
    	numbers=new int[nums.length];
    	numbers[0]=nums[0];
    	for (int i=1;i<nums.length;i++){
    		numbers[i]=numbers[i-1]+nums[i];
    	}
    	
                 
        }
        
    }

    public int sumRange(int i, int j) {
        if(numbers==null) return 0;
        if(i==0||j==0) return numbers[j];
    	return numbers[j]-numbers[i-1];
    }
}