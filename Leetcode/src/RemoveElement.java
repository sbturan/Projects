
public class RemoveElement {
	public static void main(String[] args) {
		System.out.println(removeElement(new int[]{2}, 3));
		
	}
	public static int removeElement(int[] nums, int val) {
		int i = 0;
        for (int n : nums) {
            if (n != val)
                nums[i++] = n;
        }
        return i;
			 
	   
		
	    
	}
}
