public class TrappingRainWater {
	public static void main(String[] args) {
		TrappingRainWater t= new TrappingRainWater();
		System.out.println(t.trap(new int[]{4,2,3}));
	}

	public int trap(int[] height) {
		
		int result=0;
		return result; 
			
		
//		if(height.length<3) return 0; 
//	 int max=height[0];
//	 int total=0;
//	 for(int a:height){
//		 max=Math.max(max, a);
//	 }
//	 for(int i=max;i>0;i--){
//       int first=0,last=height.length-1;
//       while(height[first]<i) {
//    	   first++;
//       }
//       while(height[last]<i) last--;
//       while(first<last){
//    	   if(height[first]<i) {
//    		   total++;
//    	   }
//    	   first++;
//       }
//       
//	 }
//	 
//	 return total;
	}	  
}
