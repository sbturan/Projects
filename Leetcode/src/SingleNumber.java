public class SingleNumber {
	
	public static void main(String[] args) {
		SingleNumber sg=new SingleNumber();
		int nums[]={2,2,1};
		System.out.println(sg.singleNumber(nums));
	}

	 public int singleNumber(int[] nums) {
		 int result = 0;
	        for(int i = 0;i<nums.length;i++){
	        result = result ^ nums[i];
	        }
	        return result;
		 /*
		HashMap<Integer,Integer> map=new HashMap<>();
		int total=0;
		for(int a:nums){
			if(map.containsKey(a)){
				total-=a;
			}else{
				total+=a;
				map.put(a, 1);
			}
		}
		
		return total;*/
		 
		 
	 }
}
