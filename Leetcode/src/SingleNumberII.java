import java.util.HashMap;

public class SingleNumberII {

	public static void main(String[] args) {
		SingleNumberII sg=new SingleNumberII();
		int nums[]={43,16,45,89,45,-2147483648,45,2147483646,-2147483647,-2147483648,43,2147483647,-2147483646,-2147483648,89,-2147483646,89,-2147483646,-2147483647,2147483646,-2147483647,16,16,2147483646,43};
		System.out.println(sg.singleNumber(nums));
	}
	
    public int singleNumber(int[] nums) {
    
    	Long total=0L,uniqueTotal=0L;
    	HashMap<Integer,Integer> map=new HashMap<>();
         
    	for(int a:nums){
    		total+=a;
    		if(!map.containsKey(a)){
    			uniqueTotal+=a;
    			map.put(a, 1);
    		}
    		
    	}
    	return (int) (((3*uniqueTotal)-total)/2);
    }
}
