public class LongestIncreasingSubsequence {

	public static void main(String[] args) {
		
	}
	 public static int lengthOfLIS(int[] nums) {
		 if(nums.length<2) return nums.length;
		int maxLenght=0;
		int[] lenghts=new int[nums.length];
		int i=1,j=0;
		while(i<nums.length){
			while(j<i){
				
				if(nums[j]<nums[i]){
					lenghts[i]=Math.max(lenghts[i], lenghts[j]+1);
					maxLenght=Math.max(maxLenght, lenghts[i]);
				}
				j++;
			}
			j=0;
			i++;
		}
		
		
		
		return maxLenght+1;
	 }
}
