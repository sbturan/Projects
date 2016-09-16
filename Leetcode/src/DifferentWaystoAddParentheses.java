import java.util.ArrayList;
import java.util.List;

public class DifferentWaystoAddParentheses {
	public List<Integer> diffWaysToCompute(String input) {

		List<Integer> result = new ArrayList<>();
		if (!input.contains("*") && !input.contains("+") && !input.contains("-")) {
			result.add(Integer.valueOf(input));
			return result;
		}
		for (int i = 0; i < input.length(); i++) {
			if (!Character.isDigit(input.charAt(i))) {
				List<Integer> left = diffWaysToCompute(input.substring(0, i));
				List<Integer> right = diffWaysToCompute(input.substring(i + 1));
				for (Integer leftI : left) {
					for (Integer rightI : right) {
						switch (input.charAt(i)) {
						case '*':
							result.add(leftI * rightI);
							break;
						case '-':
							result.add(leftI - rightI);
							break;
						case '+':
							result.add(leftI + rightI);
							break;
						}
					}
				}
			}
		}
		return result;
		
		
	}
}
