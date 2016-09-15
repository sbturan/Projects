import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class TopKFrequentElements {
	public List<Integer> topKFrequent(int[] nums, int k) {
		List<Integer> result=new ArrayList<>();
		Map<Integer,Integer> counts=new HashMap<>();
		
		for(int i:nums){
			Integer countValue=counts.get(i);
			if(countValue==null){
				counts.put(i, 1);
			}else{
				counts.put(i, countValue+1);
			}
		}
		List<Integer> values = new ArrayList<>(counts.values());
		Collections.sort(values);
		Collections.reverse(values);
		List<Integer> subList = values.subList(0, k);
		for(Integer j:counts.keySet()){
			Integer current=counts.get(j);
			if(subList.contains(current)&&!result.contains(j)){
				result.add(j);
			}
				
		}
		
		return result;

	}
}
