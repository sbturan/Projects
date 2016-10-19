
public class ReverseBits {
	public int reverseBits(int n) {
		int r = 0;
		for (int i = 31; i >= 0; i--, n >>= 1) {
			r |= ((n & 1) << i);
		}
		return r;
	}
}
