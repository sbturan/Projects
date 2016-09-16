import java.util.Stack;

public class BasicCalculator {
	public static void main(String[] args) {
		BasicCalculator b = new BasicCalculator();
		System.out.println(b.calculate("(5-(1+(5)))"));
	}

	public int calculate(String s) {
		s = s.replace(" ", "");
		if (!s.contains("+") && !s.contains("-"))
			return Integer.valueOf(s.replace("(", "").replace(")", ""));

		boolean containParanthesis = true;
		while (containParanthesis) {
			int i = 0;
			int start = 0;
			while (i < s.length() && s.charAt(i) != ')') {
				if (s.charAt(i) == '(') {
					start = i + 1;
				}
				i++;
			}
			if (i == s.length())
				containParanthesis = false;
			else {
				s=getTotalBetween(start, i - 1, s);
			}
		}
		
		s=getTotalBetween(0, s.length()-1, s);

		return Integer.valueOf(s);
	}

	private String getTotalBetween(int start, int end, String s) {
		Integer total = 0;
		int currentSign = 0;
		if(s.charAt(start)=='-') {
			currentSign=1;
			start++;
		}
		
		Integer cur = start;
		while (true) {
			int number = getNumber(cur, s);
			while(cur<s.length()&&Character.isDigit(s.charAt(cur))) cur++;
			if (currentSign == 0)
				total += number;
			else
				total -= number;
			if (cur >= end)
				break;
			char c = s.charAt(cur);
			if (c == '+')
				currentSign = 0;
			else
				currentSign = 1;
			cur++;
		}
		String result="";
		if(start!=0)result = s.substring(0,start-1);
		
		result += total.toString();
		if (end < s.length() - 2) {
			result = result + s.substring(end + 2);
		}
		int index=0;
		while(index<result.length()-1){
			char firstChar = result.charAt(index);
			char secondChar = result.charAt(index+1);
			if((firstChar=='+'&&secondChar=='+')||
					(firstChar=='+'&&secondChar=='-')||
					(firstChar=='-'&&secondChar=='+')||
					(firstChar=='-'&&secondChar=='-')){
				if(firstChar!=secondChar){
					result=result.substring(0,index)+"-"+result.substring(index+2);
				}else{
					result=result.substring(0,index)+"+"+result.substring(index+2);
				}
			}
			index++;
		}
	
   return result;
	}

	private int getNumber(Integer i, String s) {
		int k = i;
		while (k < s.length() && Character.isDigit(s.charAt(k))) {
			k++;
		}

		return Integer.valueOf(s.substring(i, k));
	}
}
