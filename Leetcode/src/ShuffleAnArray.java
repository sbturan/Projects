import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Random;

public class ShuffleAnArray {
public static void main(String[] args) {
	Random r=new Random();
	System.out.println(r.nextInt(4));
	System.out.println(r.nextInt(4));
	System.out.println(r.nextInt(4));
	System.out.println(r.nextInt(4));
	System.out.println(r.nextInt(4));
}

public class Solution {

	int [] nums;
	Random rd;
    public Solution(int[] nums) {
        this.nums=nums;
        rd=new Random(nums.length);
    }
    
    /** Resets the array to its original configuration and return it. */
    public int[] reset() {
     
    	return nums;
    }
    
    /** Returns a random shuffling of the array. */
    public int[] shuffle() {
   
        int length = nums.length;
		int[] shuffled=new int[length];
        int[] selected=new int[length];
        Arrays.fill(selected, 0);
        
        for(int i=0;i<shuffled.length;i++){
        	int rndIndex=rd.nextInt(length);
        	while(selected[rndIndex]==1){
        		rndIndex=rd.nextInt(length);
        	}
        	selected[rndIndex]=1;
        	shuffled[i]=nums[rndIndex];
        }
        
        
        return shuffled;
        
        
    }
}
}
