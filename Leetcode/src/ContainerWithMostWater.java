
public class ContainerWithMostWater {
	public static void main(String[] args) {
		ContainerWithMostWater c=new ContainerWithMostWater();
		System.out.println(c.maxArea(new int[]{2,1}));
	}
	public int maxArea(int[] height) {
          
		int max[]=new int[height.length];
		for(int i=0;i<height.length;i++){
			for(int j=0;j<height.length;j++){
				if(height[i]>=height[j]&&Math.abs(i-j)>max[j]){
					max[j]=Math.abs(i-j);
				}
			}
		}
		
		int result=0;
		for(int i=0;i<height.length;i++){
			result=Math.max(result, max[i]*height[i]);
		}
		return result;
	}
}
