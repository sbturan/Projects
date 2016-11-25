import java.util.HashMap;
import java.util.HashSet;

public class FrogJump {
	public static void main(String[] args) {
		FrogJump f=new FrogJump();
		System.out.println(f.canCross(new int[]{0,1,2,3,4,8,9,11}));
	}
	public boolean canCross(int[] stones) {
		 if (stones.length == 0) {
	        	return true;
	        }
	        
	        HashMap<Integer, HashSet<Integer>> map = new HashMap<Integer, HashSet<Integer>>(stones.length);
	        map.put(0, new HashSet<Integer>());
	        map.get(0).add(1);
	        for (int i = 1; i < stones.length; i++) {
	        	map.put(stones[i], new HashSet<Integer>() );
	        }
	        
	        for (int i = 0; i < stones.length - 1; i++) {
	        	int stone = stones[i];
	        	for (int step : map.get(stone)) {
	        		int reach = step + stone;
	        		if (reach == stones[stones.length - 1]) {
	        			return true;
	        		}
	        		HashSet<Integer> set = map.get(reach);
	        		if (set != null) {
	        		    set.add(step);
	        		    if (step - 1 > 0) set.add(step - 1);
	        		    set.add(step + 1);
	        		}
	        	}
	        }
	        
	        return false;
	}
	
	
	
//	private boolean helper(int[] stones,int pos,int unit){
//	 if(pos==stones.length-1) return true;
//	 if(stones[pos+1]-stones[pos]>unit+1) return false;
//	 if(unit==0) return false;
//	 boolean result=false;
//	 int small=unit-1,mid=unit,large=unit+1;
//	 int i=pos+1;
//	 while(i<stones.length&&stones[i]-stones[pos]<small){
//		 i++;
//	 }
//	 if(i<stones.length&&stones[i]-stones[pos]==small){
//		 result =helper(stones, i, small);
//	 }
//	 if(result==true) return true;
//	 
//	 i=pos+1;
//	 while(i<stones.length&&stones[i]-stones[pos]<mid){
//		 i++;
//	 }
//	 if(i<stones.length&&stones[i]-stones[pos]==mid){
//		 result =helper(stones, i, mid);
//	 }
//	 if(result==true) return true;
//	 i=pos+1;
//	 while(i<stones.length&&stones[i]-stones[pos]<large){
//		 i++;
//	 }
//	 if(i<stones.length&&stones[i]-stones[pos]==large){
//		 result =helper(stones, i, large);
//	 }
//	 if(result==true) return true;
//	 
//	 return false;
//		
//		
//	}
}
