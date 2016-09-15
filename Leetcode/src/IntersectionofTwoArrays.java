import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class IntersectionofTwoArrays {

    public int[] intersection(int[] nums1, int[] nums2) {
    
    	int length1 = nums1.length;
		int length2 = nums2.length;
		if(length1==0||length2==0) return new int[0];
		if(length2>length1){
			int[] temp=nums2;
			nums2=nums1;
			nums1=temp;
		}
    	List<Integer> nums1List=new ArrayList<>();
		for(int i:nums1){
    		nums1List.add(i);
    	}
		ArrayList<Integer> result=new ArrayList<>();
		for(int i:nums2){
			if(nums1List.contains(i)){
				result.add(i);
				nums1List.remove(Integer.valueOf(i));
			}
		}
    	int[] arrayResult=new int[result.size()];
    	
    	for(int i=0;i<result.size();i++){
    		arrayResult[i]=result.get(i);
    	}
    	return arrayResult;
    }
}
