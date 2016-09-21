import java.util.HashMap;
import java.util.Map;

public class IntegertoEnglishWords {
	public static void main(String[] args) {
		System.out.println(numberToWords(1003450));
	}
	public static String numberToWords(int num) {
		if (num == 0)
			return "Zero";
		Map<Integer, String> map = new HashMap<>();
		map.put(1, "");
		map.put(2, "Thousand");
		map.put(3, "Million");
		map.put(4, "Billion");
		Map<Integer, String> map2 = new HashMap<>();
		map2.put(1, "One");
		map2.put(2, "Two");
		map2.put(3, "Three");
		map2.put(4, "Four");
		map2.put(5, "Five");
		map2.put(6, "Six");
		map2.put(7, "Seven");
		map2.put(8, "Eight");
		map2.put(9, "Nine");
		map2.put(10, "Ten");
		map2.put(11, "Eleven");
		map2.put(12, "Twelve");
		map2.put(13, "Thirteen");
		map2.put(14, "Fourteen");
		map2.put(15, "Fifteen");
		map2.put(16, "Sixteen");
		map2.put(17, "Seventeen");
		map2.put(18, "Eighteen");
		map2.put(19, "Nineteen");
		map2.put(20, "Twenty");
		map2.put(30, "Thirty");
		map2.put(40, "Forty");
		map2.put(50, "Fifty");
		map2.put(60, "Sixty");
		map2.put(70, "Seventy");
		map2.put(80, "Eighty");
		map2.put(90, "Ninety");

		String stringNum = Integer.toString(num);
		if (stringNum.length() % 3 != 0) {
			for (int i = 0; i < stringNum.length() % 3; i++) {
				stringNum = "0" + stringNum;
			}
		}

		String result = "";
		int digit = 1;
		for (int i = stringNum.length() - 1; i > 1; i = i - 3) {
			String convertTreeDigit = convertTreeDigit(stringNum.substring(i - 2, i + 1), map2);
			if(!convertTreeDigit.equals(""))
			result = convertTreeDigit + " " + map.get(digit) + " " + result;
			digit++;
		}

		return result.trim();
	}

	private static String convertTreeDigit(String s, Map<Integer, String> map) {
		String result = "";
		for (int i = 2; i > -1; i--) {
			int val = Character.getNumericValue(s.charAt(i));
			if (val != 0) {
				switch (i) {
				case 0:
					result = map.get(val) + " Hundred " + result;
					break;
				case 1:
					if (val == 1) {
						result = map.get(10 + Integer.valueOf(s.substring(2, 3)));
					} else {
						result = map.get((val * 10)) + " " + result;
					}
					break;
				case 2:
					result = map.get(val);
					break;
				}
			}
		}
		return result.trim();
	}
}
