
public class RangeSumQueryMutable {
	public class NumArray {

		int array[];
	    public NumArray(int[] nums) {
         array=new int[nums.length+1];
         array[0]=0;
         for(int i=0;i<nums.length;i++){
        	 array[i+1]=array[i]+nums[i];
         }
         
	    }

	    void update(int i, int val) {
	        int dif=val-sumRange(i, i);
	        for(int j=i+1;j<array.length;j++){
	        	array[j]+=dif;
	        }
	        
	    }

	    public int sumRange(int i, int j) {
	        return array[j+1]-array[i];
	    }
	}
}
