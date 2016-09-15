
public class Solution_addBinary {
	public static void main(String[] args) {
		Solution_addBinary s = new Solution_addBinary();
		System.out.println(s.addBinary("1", "1"));
	}

	public String addBinary(String a, String b) {

		String result = "";
		if (a.length() != b.length()) {
			int fark = a.length() - b.length();
			if (fark > 0) {
				String temp = "";
				for (int i = 0; i < fark; i++) {
					temp = temp.concat("0");
				}
				b = temp.concat(b);

			} else {
				fark = fark * (-1);
				String temp = "";
				for (int i = 0; i < fark; i++) {
					temp = temp.concat("0");
				}
				a = temp.concat(a);
			}
		}

		int cc = 0;
		for (int i = a.length() - 1; i > -1; i--) {
			int currentTotal = cc + Integer.valueOf(a.substring(i, i + 1)) + Integer.valueOf(b.substring(i, i + 1));
			if (currentTotal >= 2) {
				result = result.concat(String.valueOf(currentTotal - 2));
				cc = 1;
			} else {
				result = result.concat(String.valueOf(currentTotal));
				cc = 0;
			}
		}

		if (cc == 1) {
			result = result.concat("1");
		}

		StringBuilder s = new StringBuilder();
		s.append(result);
		s.reverse();
		return s.toString();
	}
}
