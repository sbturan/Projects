
public class MinimumMovestoEqualArrayElements {
	public static void main(String[] args) {
		MinimumMovestoEqualArrayElements  m=new MinimumMovestoEqualArrayElements();
		System.out.println(m.minMoves(new int[]{-100,0,100}));
	}
	public int minMoves(int[] nums) {
       int moveIncrements=nums.length-1;
       if(moveIncrements<1) return 0;
       int min=nums[0];
       for(int i:nums){
    	  min=Math.min(min, i);
       }
       int result=0;
       for(int i:nums){
    	   result+=i-min;
       }
       
       return result;
      
	}
}
