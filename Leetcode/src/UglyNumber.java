
public class UglyNumber {
	public static void main(String[] args) {
		UglyNumber ug = new UglyNumber();
		System.out.println(ug.isUgly(14));
	}

	public boolean isUgly(int num) {
		if (num < 1)
			return false;
		if (num == 1)
			return true;

		int value = num;

		while (value % 5 == 0 && value > 4) {
			value = value / 5;
		}

		while (value % 3 == 0 && value > 2) {
			value = value / 3;

		}

		while (value % 2 == 0 && value > 1) {
			value = value / 2;

		}
		return value == 1;
	}
}
