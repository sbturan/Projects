
public class MedianOfTwoSortedArrays {

	public static void main(String[] args) {
		System.out.println(findMedianSortedArrays(new int[]{1,2},new int[]{3}));
	}
public static double findMedianSortedArrays(int[] nums1, int[] nums2) {
     
        if((nums1==null&&nums2==null)||(nums1.length==0&&nums2.length==0)) return 0;   	
 		int medianIndex=(nums1.length+nums2.length)/2;
 		double result=0;
 		if(nums1.length>0)result=nums1[0];else  result=nums2[0];
		int i=0;
		int index1=0,index2=0;
		double oldValue=result;
		while(i<=medianIndex){
			
			
			if(index2>=nums2.length){
				oldValue=result;
				result=nums1[index1++];
				i++;
				continue;
			}
			if(index1>=nums1.length||nums1[index1]>nums2[index2]){
				oldValue=result;
				result=nums2[index2];
					index2++;
			}else{
				oldValue=result;
				result=nums1[index1];
					index1++;
			}
			i++;
			
		}
		if((nums1.length+nums2.length)%2==0)result=(result+oldValue)/(2.0);
		return result;
    }
}
