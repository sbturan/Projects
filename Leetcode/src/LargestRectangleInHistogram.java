
public class LargestRectangleInHistogram {
	public static void main(String[] args) {
		LargestRectangleInHistogram l=new LargestRectangleInHistogram();
        int[] array=new int[]{1,1,1,1,1,1,1,1,1,1,1,1};
        System.out.println(l.largestRectangleArea(array));
	}
	public static int largestRectangleArea(int[] heights) {
		   if(heights == null || heights.length == 0) {
	            return 0;
	        }
	      		int lenght = heights.length;
			int left[]=new int[lenght];
			int right[]=new int[lenght];
			left[0]=0;
			for(int i=1;i<lenght;i++){
				int currentLeft=i-1;
				while(currentLeft>-1&&heights[currentLeft]>=heights[i]){
					currentLeft=left[currentLeft]-1;
				}
				left[i]=currentLeft+1;
			}
			right[lenght-1]=lenght-1;
			 for(int i = lenght-2; i >= 0; i--) {
		            int currentRight = i+1;
		            while(currentRight < lenght && heights[i] <= heights[currentRight]) {
		                currentRight = right[currentRight]+1;
		            }
		                
		            right[i] = currentRight-1;
		        }
			 
			 int max=0;
			 for(int i=0;i<lenght;i++){
				 max=Math.max(max, (right[i]-left[i]+1)*heights[i]);
			 }
			
			return max;
	}
}
