
public class PermutationSequence {
	public static void main(String[] args) {
		PermutationSequence p=new PermutationSequence();
		System.out.println(p.getPermutation(4,13));
	}

	public String getPermutation(int n, int k) {
		boolean[] arr = new boolean[n+1];
		return helper(arr, n, k, n);

	}

	private String helper(boolean[] arr, int n, int k, int orgN) {
		if (n <= 2) {
			int first = 0;
			int second = 0;
			for (int i = 1; i < n + 1; i++) {
				if (arr[i] == false) {
					if (first == 0) {
						first = i;
					} else {
						second = i;
						break;
					}
				}
			}
			if(n==1) return Integer.toString(first);
			if (k == 0) {
				return Integer.toString(first).concat(Integer.toString(second));
			} else {
				return Integer.toString(second).concat(Integer.toString(first));
			}

		}
		int val = (int)Math.ceil((double) k/ getFac(n - 1));
		String s = Integer.toString(val);
		arr[val]=true;
		int sec = (k +1) % (n - 1);
		s=s.concat(helper(arr, n-1, sec, orgN));
		return s;
	}
	private int getFac(int n){
		if(n==1) return 1;
		return getFac(n-1)*n;
	}
}
