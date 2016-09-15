import java.util.HashMap;

public class SingleNumberIII {

	 public static void main(String[] args) {
		System.out.println(3^4^3^4^5^6);
		System.out.println(5^6);
		System.out.println(6^5);
	}
	
	
	 public int[] singleNumber(int[] nums) {
	      
		 HashMap<Integer,Integer> map=new HashMap<>();
		 for(int a:nums){
			 if(map.containsKey(a)){
				 map.remove(a);
			 }else{
				 map.put(a, 1);
			 }
		 }
		 
		 return map.keySet().stream().mapToInt(i->i).toArray();
		 
	    }
}
