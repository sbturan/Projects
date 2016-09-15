
public class Solution_multiply {

	public static void main(String[] args) {
		
//		String test="3213213213";
//		int x=test.charAt(0) - '0' ;
//		System.out.println(x);
		Solution_multiply s = new Solution_multiply();
		long f = System.currentTimeMillis();
		System.out.println(s.multiply("12345321321321343243243221678455435439", "954354354354354354354354387654321"));
		System.out.println("time=" + (System.currentTimeMillis() - f));
	}

	public String multiply(String num1, String num2) {
		num1 = num1.trim();
		num2 = num2.trim();
		if (num1 == null || num1.length() == 0 || num2 == null || num2.length() == 0) {
			return null;
		}

		String alttaki = num1;
		String ustteki = num2;
		if (num1.length() > num2.length()) {
			alttaki = num2;
			ustteki = num1;
		}

		String result = "0";
		int basamak = 1;
		for (int i = alttaki.length() - 1; i > -1; i--) {
			//String current = alttaki.substring(i, i + 1);
			int current=alttaki.charAt(i)-'0';
			String currentResult = multiplySingleNumberAndMulti(String.valueOf(current), ustteki);
			for (int j = 1; j < basamak; j++) {
				currentResult = currentResult.concat("0");
			}
			result = addTwoString(currentResult, result);
			basamak++;

		}

		return result;
	}

	static String addTwoString(String s1, String s2) {
		int counterS1 = s1.length() - 1;
		int counterS2 = s2.length() - 1;
		String result = "";
		int cc = 0;
		while (counterS2 > -1 || counterS1 > -1) {
			//String substringS1 = "0";
			int substringS1 = 0;
			//String substringS2 = "0";
			int substringS2 = 0;
			if (counterS1 > -1)
				//	substringS1 = s1.substring(counterS1, counterS1 + 1);
			substringS1 = s1.charAt(counterS1)-'0'; 
			if (counterS2 > -1)
				//	substringS2 = s2.substring(counterS2, counterS2 + 1);
			substringS2 = s2.charAt(counterS2)-'0';
			int currentTotal =substringS1 + substringS2 + cc;
			if (currentTotal >= 10) {
				int cc2 = currentTotal % 10;
				cc = (currentTotal - cc2) / 10;
				currentTotal = cc2;
			} else {
				cc = 0;
			}
			result = String.valueOf(currentTotal).concat(result);
			counterS2--;
			counterS1--;

		}
		if (cc != 0)
			result = String.valueOf(cc).concat(result);
		return result;
	}

	static String multiplySingleNumberAndMulti(String single, String multi) {
		if (single.trim().equals("0"))
			return "0";
		String result = "";
		int singleIntVal = Integer.valueOf(single);
		int cc = 0;
		for (int i = multi.length() - 1; i > -1; i--) {
			int currentMulti=multi.charAt(i)-'0';
			int current = (singleIntVal * currentMulti) + cc;
			if (current >= 10) {
				int cc2 = current % 10;
				cc = (current - cc2) / 10;
				current = cc2;
			} else {
				cc = 0;
			}
			result = String.valueOf(current).concat(result);

		}

		if (cc != 0) {
			result = String.valueOf(cc).concat(result);
		}

		return result;

	}

}
