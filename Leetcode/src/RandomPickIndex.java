import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;

public class RandomPickIndex {
	public class Solution {

		Map<Integer,List<Integer>> map;
		public Solution(int[] nums) {
			map=new HashMap<>();
			for(int i=0;i<nums.length;i++){
				List<Integer> orDefault = map.getOrDefault(nums[i], new ArrayList<Integer>());
				orDefault.add(i);
				map.put(nums[i], orDefault);
			}

		}

		public int pick(int target) {
           List<Integer> list = map.get(target);
           Random rd=new Random();
           return list.get(rd.nextInt(list.size()));
           
		}
	}
}
