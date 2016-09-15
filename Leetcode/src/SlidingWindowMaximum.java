import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class SlidingWindowMaximum {
	
	public static void main(String[] args) {
		
		int[] nums = new int[] {1,2,3,4,5,6,7,8,10,0};
		long currentTimeMillis = System.currentTimeMillis();
		System.out.println(subsets(nums).toString());
		System.out.println("time = "+(System.currentTimeMillis()-currentTimeMillis));
		
	}
	
	public static List<List<Integer>> subsets(int[] S) {
		if (S == null)
			return null;
	 
		Arrays.sort(S);
	 
		List<List<Integer>> result = new ArrayList<List<Integer>>();
	 
		for (int i = 0; i < S.length; i++) {
			ArrayList<ArrayList<Integer>> temp = new ArrayList<ArrayList<Integer>>();
	 
			//get sets that are already in result
			for (List<Integer> a : result) {
				temp.add(new ArrayList<Integer>(a));
			}
	 
			//add S[i] to existing sets
			for (ArrayList<Integer> a : temp) {
				a.add(S[i]);
			}
	 
			//add S[i] only as a set
			ArrayList<Integer> single = new ArrayList<Integer>();
			single.add(S[i]);
			temp.add(single);
	 
			result.addAll(temp);
		}
	 
		//add empty set
		result.add(new ArrayList<Integer>());
	 
		return result;
	}
	

//	 public static List<List<Integer>> subsets(int[] nums) {
//		 
//		 List<List<Integer>> result=new ArrayList<List<Integer>>();
//		 result.add(new ArrayList<Integer>());
//		 Set<Set<Integer>> subSet = getSubSet(nums.length,nums);
//		 for (Set<Integer> set : subSet) {
//			result.add(new ArrayList<>(set));
//		}
//	    return	 result;
//		  
//	 }
//
//	
//	 public static Set<Set<Integer>> getSubSet(int subsetElementCout,int[] elements){
//		 Set<Set<Integer>> subs= new HashSet<>();
//		 if(subsetElementCout!=1){
//			 Set<Set<Integer>> countDownOneSubs=getSubSet(subsetElementCout-1, elements);
//			 
//			 for (Set<Integer> list : countDownOneSubs) {
//				for (int integer : elements) {
//					
//						Set<Integer> temp=new HashSet<>(list);
//						temp.add(integer);
//
//						subs.add(temp);
//					
//				}
//				
//			}
//			 subs.addAll(countDownOneSubs);
//		 }else{
//			 
//			 Set<Integer> tempArray;
//			 for(int i=0;i<elements.length;i++){
//				 tempArray=new HashSet<>();
//				 tempArray.add(elements[i]);
//				 subs.add(tempArray);
//			 }
//			 
//			 
//			 
//		 }
//		 
//		 return subs;
//	 }
	

}
