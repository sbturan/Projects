import java.util.Arrays;

public class Heaters {
	public static void main(String[] args) {
		Heaters h=new Heaters();
		System.out.println(h.findRadius(new int[]{1,2,3,4}, new int[]{1,4}));
	}
	public int findRadius(int[] houses, int[] heaters) {
      
		int result=0;
	    
		Arrays.sort(heaters);
		for(int i:houses){
			int cur=Integer.MAX_VALUE;
			int index=Arrays.binarySearch(heaters, i);
			if(index<0){
				index+=1;
				index*=-1;
			}
			if(index>0){
				cur=Math.min(cur, i-heaters[index-1]);
			}
			if(index<heaters.length){
				cur=Math.min(cur, heaters[index]-i);
			}
			result=Math.max(result, cur);
		}
		return result;
	}
	
	
	
}
