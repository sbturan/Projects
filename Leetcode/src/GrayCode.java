import java.util.ArrayList;
import java.util.List;

public class GrayCode {
	public List<Integer> grayCode(int n) {
		List<Integer> res = new ArrayList<>();
		res.add(0);
		int crt = 0;
		int next = 1;
		for (int i = 1; i <= n; i++) {
			crt = next;
			next <<= 1;
			for (int j = crt - 1; j >= 0; j--) {
				res.add(crt ^ res.get(j));
			}
		}
		return res;
	}
}
