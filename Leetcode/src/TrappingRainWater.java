public class TrappingRainWater {
	public static void main(String[] args) {
		TrappingRainWater t = new TrappingRainWater();
		System.out.println(t.trap(new int[] {  2, 3,4 }));
	}

	public int trap(int[] height) {

		if(height.length<3) return 0;
		int result=0;
		int max=height[0];
		for(int i=0;i<height.length;i++){
			int j=height.length-1;
			
		    for(;j>i;j--){
		    	if(height[j]>=height[i]) break;
		    }
		    if(j>i){
		    	if(height[i]<=max){
					result+=max-height[i];
				}else{
					max=height[i];
				}	
		    }else{
		    	if(max==height[i]){
		    		max=height[i+1];
		    	}
		    }
			
		}
		
		return result;
	}
	
//	int findWaterPerLevel(int level,int[] height){
//		int first=0;
//		while(height[first]<level){
//			first++;
//		}
//		int last=height.length-1;
//		while(height[last]<level){
//			last--;
//		}
//		int result=0;
//		for(int i=first;i<last;i++){
//			if(height[i]<level){
//				result++;
//			}
//		}
//		return result;
//	}
}
