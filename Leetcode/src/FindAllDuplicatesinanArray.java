import java.util.ArrayList;
import java.util.List;

public class FindAllDuplicatesinanArray {
	public static void main(String[] args) {
		System.out.println(findDuplicates(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }));
	}

	public static List<Integer> findDuplicates(int[] nums) {
		List<Integer> result = new ArrayList<>();

		for (int i = 0; i < nums.length; i++) {
			int index = nums[i];
			if (index < 0)
				index *= -1;
			index-=1;
			if (nums[index] < 0) {
				result.add(index+1);
			} else {
				nums[index] *=-1 ;
			}
		}
		return result;
	}
}
