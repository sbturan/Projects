import java.util.ArrayList;
import java.util.List;

public class LexicographicalNumbers {
	public static void main(String[] args) {
		LexicographicalNumbers l = new LexicographicalNumbers();
		List<Integer> lexicalOrder = l.lexicalOrder(218);
		List<Integer> lexicalOrder2 = l.lexicalOrder2(218);
		for (int i = 0; i < lexicalOrder.size(); i++) {
			System.out.println(i + " " + lexicalOrder.get(i) + " " + lexicalOrder2.get(i));
		}
	}

	public List<Integer> lexicalOrder2(int n) {

		List<Integer> list = new ArrayList<>(n);
		int curr = 1;
		for (int i = 1; i <= n; i++) {
			list.add(curr);
			if (curr * 10 <= n) {
				curr *= 10;
			} else if (curr % 10 != 9 && curr + 1 <= n) {
				curr++;
			} else {
				while (curr % 10 == 9) {
					curr /= 10;
				}
				curr = curr + 1;
			}
		}
		return list;

	}

	public List<Integer> lexicalOrder(int n) {
		List<Integer> list = new ArrayList<>(n);
		int curr = 1;
		for (int i = 1; i <= n; i++) {
			list.add(curr);
			if (curr * 10 <= n) {
				curr *= 10;
			} else if (curr % 10 != 9 && curr + 1 <= n) {
				curr++;
			} else {
				while ((curr / 10) % 10 == 9) {
					curr /= 10;
				}
				curr = curr / 10 + 1;
			}
		}
		return list;
	}
}
