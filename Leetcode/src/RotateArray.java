
public class RotateArray {
	public static void main(String[] args) {
		RotateArray r=new  RotateArray();
		r.rotate(new int[]{1, 2},1);
	}
	
	public void rotate(int[] nums, int k) {
		
       k=k%nums.length;
        if(k==0) return;
       int m[]=new int[k];
       int j=0;
       for(int i=nums.length-k;i<nums.length;i++){
          m[j++]=nums[i];
       }
       for(int i=nums.length-k-1;i>-1;i--){
    	   nums[i+k]=nums[i];
       }
       j=0;
       while(j<m.length){
    	   nums [j]=m[j++];
       }
       
       
	}
}
