import java.util.Stack;

public class DecodeString {
	public static void main(String[] args) {
		System.out.println(decodeString("3[a]2[bc]"));
		// System.out.println(decodeString("sd2[f2[e]g]i"));
	}

	public static String decodeString(String s) {
		Stack<String> chars = new Stack<>();
		Stack<Integer> numbers = new Stack<>();
		char[] charArray = s.toCharArray();
		String result = "";
		for (int i = 0; i < charArray.length; i++) {
			Character c = charArray[i];
			if (Character.isDigit(c)) {
				String number = Character.toString(c);

				while (Character.isDigit(charArray[i + 1])) {
					number = number.concat(Character.toString(charArray[i + 1]));
					i++;
				}
				numbers.push(Integer.valueOf(number));
			} else if (Character.isAlphabetic(c)) {
				if (i == 0 || charArray[i - 1] != '[')
					numbers.push(1);

				String charsSequance = Character.toString(c);
				while (i < charArray.length - 1 && Character.isAlphabetic(charArray[i + 1])) {
					charsSequance = charsSequance.concat(Character.toString(charArray[i + 1]));
					i++;
				}
				chars.push(charsSequance);
			} else if (c == ']') {
				String str = "";
				int count = 1;
				if (!numbers.isEmpty()) {
					count = numbers.pop();
				}
				String str2 = chars.pop();
				str = str2 + str;
				String newStr = "";
				for (int j = 0; j < count - 1; j++) {
					newStr = str + newStr;
				}
				str = str + newStr;

				String stackLast = "";
				if (!chars.isEmpty())
					stackLast = chars.pop();
				chars.push(stackLast.concat(str));
			}

		}

		while (!chars.isEmpty()) {
			String pop = chars.pop();
			Integer count = 1;
			if (!numbers.isEmpty())
				count = numbers.pop();
			for (int i = 0; i < count; i++) {
				result = pop + result;
			}

		}

		return result;

	}
}
