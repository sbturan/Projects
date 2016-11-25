
public class FirstMissingPositive {
	public static void main(String[] args) {
		FirstMissingPositive f = new FirstMissingPositive();
		System.out.println(f.firstMissingPositive(new int[] { 1 }));
	}

	public int firstMissingPositive(int[] nums) {

		int pos = 0;

		while (pos < nums.length) {
			int val = nums[pos];
			if (nums[pos] == pos + 1 || val < 1 || val > nums.length) {
				pos++;
			} else {
				while (val <= nums.length && val > 0 && nums[val - 1] != val) {
					int temp = nums[val - 1];
					nums[val - 1] = val;
					val = temp;
				}
				pos++;
			}
		}
		int i;
		for (i = 0; i < nums.length; i++) {
			if (nums[i] != i + 1) {
				return i + 1;
			}
		}

		return i + 1;
	}
}
