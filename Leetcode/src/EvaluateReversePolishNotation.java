import java.util.Stack;

public class EvaluateReversePolishNotation {
	public int evalRPN(String[] tokens) {

		Stack<Integer> stack=new Stack<>();
		for(String s:tokens){
			if(s.equals("*")){
				Integer val1 = stack.pop();
				Integer val2 = stack.pop();
				stack.push(val2*val1);
			}else if(s.equals("/")){
				Integer val1 = stack.pop();
				Integer val2 = stack.pop();
				stack.push(val2/val1);
			}
			else if(s.equals("+")){
				Integer val1 = stack.pop();
				Integer val2 = stack.pop();
				stack.push(val1+val2);
			}
			else if(s.equals("-")){
				Integer val1 = stack.pop();
				Integer val2 = stack.pop();
				stack.push(val2-val1);
			}else{
				stack.push(Integer.valueOf(s));
			}
		}
		
		return stack.pop();
		
	}
}
