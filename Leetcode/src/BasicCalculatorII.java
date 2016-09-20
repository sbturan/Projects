import java.util.Stack;

public class BasicCalculatorII {
 
	
	public static void main(String[] args) {
		BasicCalculatorII bs=new BasicCalculatorII();
		System.out.println(bs.calculate("3+5 / 2 "));
	}
   public int calculate(String s) {
   
	    s=s.replace(" ", "");
	    Stack<Integer> stack=new Stack<>();
	    stack.push(1);
	    int i=0;
	    while(i<s.length()){
	    	if(Character.isDigit(s.charAt(i))){
	    		int sum = s.charAt(i) - '0';
	    		i++;
				while (i  < s.length() && Character.isDigit(s.charAt(i ))) {
					sum = sum * 10 + s.charAt(i ) - '0';
					i++;
				}
				stack.push(sum);
	    	}else if(s.charAt(i)=='+'){
	    		stack.push(1);
	    		i++;
 	    	}else if(s.charAt(i)=='-'){
 	    		stack.push(-1);
 	    		i++;
 	    	}else if(s.charAt(i)=='*'){
 	    		i++;
 	    		int sum = s.charAt(i) - '0';
 	    		i++;
				while (i  < s.length() && Character.isDigit(s.charAt(i ))) {
					sum = sum * 10 + s.charAt(i ) - '0';
					i++;
				}
				int value=stack.pop()*sum;
				stack.push(value);
 	    	}else if(s.charAt(i)=='/'){
 	    		i++;
 	    		int sum = s.charAt(i) - '0';
 	    		i++;
				while (i  < s.length() && Character.isDigit(s.charAt(i ))) {
					sum = sum * 10 + s.charAt(i ) - '0';
					i++;
				}
				if(sum==0) return 0;
				int value=stack.pop()/sum;
				stack.push(value);
 	    	}
	    }
	    
//	    int result=stack.get(0);
//	    int j=1;
	    
	    int result=0;
	    while(!stack.isEmpty()){
	    	result+=stack.pop()*stack.pop();
	    }
	   return result;
    }
}
