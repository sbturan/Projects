import java.util.ArrayList;
import java.util.List;

public class GenerateParentheses {
	public static void main(String[] args) {
		GenerateParentheses g = new GenerateParentheses();
	System.out.println(g.generateParenthesis(3));
	
		
		

	}
	 public List<String> generateParenthesis(int n) {
		    List<String> ans = new ArrayList<>();
		    if(n == 0)
		        return ans;
		    StringBuilder sb = new StringBuilder();
		    sb.append('(');
		    Judge(1, 1, sb, ans, 2*n);
		    return ans;
		}

		public void Judge(int length, int value, StringBuilder sb, List<String> list, int n) {
		    if(length == n) {
		        list.add(sb.toString());
		        return;
		    }
		    if(length <= n) {
		        if(value+1 <= n/2 && value+1 < n-length) {
		            Judge(length + 1, value + 1, sb.append('('), list, n);
		            sb.deleteCharAt(length);
		        }
		        if(value-1 >= 0) {
		            Judge(length + 1, value - 1, sb.append(')'), list, n);
		            sb.deleteCharAt(length);
		        }
		    }
		}

//	public List<String> generateParenthesis(int n) {
//
//		return	rcrsv(new ArrayList<String>(),"", n, 0, 0);
//
//	}

	static String left = "(";
	static String right = ")";
	//static List<String> result = new ArrayList<>();
	static int size = 0;

	public static  List<String>  rcrsv(List<String> result,String cc, int n, int leftCount, int rightCount) {
		if (cc.length() == n * 2 && size++ % 2 == 1) {
			result.add(cc);
			return result;
		}

		if (leftCount < n) {
			cc = cc.concat(left);
			leftCount++;
			result=rcrsv(result,cc, n, leftCount, rightCount);
		}
		if (rightCount <leftCount) {
			cc = cc.concat(right);
			rightCount++;
			result=rcrsv(result,cc, n, leftCount, rightCount);
		}

		return result;
	}
}
