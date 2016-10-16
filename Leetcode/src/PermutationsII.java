import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PermutationsII {
	 public List<List<Integer>> permuteUnique(int[] nums) {
	        List<List<Integer>> res = new ArrayList<>();
	        if(nums.length == 0){
	            return res;
	        }
	        if(nums.length == 1){
	            List<Integer> list  = new ArrayList<>();
	            list.add(nums[0]);
	            res.add(list);
	            return res;
	        }
	        dfs(res, nums, 0);
	        return res;
	    }
	    
	    public void dfs(List<List<Integer>> res, int nums[], int start){
	        if(nums.length-start == 2){
	            List<Integer> pair = new ArrayList<>();
	            pair.add(nums[start]);
	            pair.add(nums[start+1]);
	            res.add(pair);
	            if(nums[start] != nums[start+1]){ //line #23
	                List<Integer> revPair = new ArrayList<>();
	                revPair.add(nums[start+1]);
	                revPair.add(nums[start]);
	                res.add(revPair);
	            }                            
	            return;
	        }
	        dfs(res, nums, start+1);
	        int size = res.size();
	        for(int j = 0;j<size;j++){
	            List<Integer> list = res.get(0);
	            res.remove(0);
	            list.add(0, nums[start]);
	            res.add(new ArrayList<>(list));
	            for(int jj = 1;jj<list.size();jj++){
	                if(list.get(jj) == nums[start]){ // line #39
	                    break;    
	                }                                // line #41
	                Collections.swap(list, jj-1,jj);
	                res.add(new ArrayList<>(list));
	            }
	        }
	    }
}
