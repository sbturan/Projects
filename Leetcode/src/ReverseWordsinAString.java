import java.util.Stack;

public class ReverseWordsinAString {

	public static void main(String[] args) {
		ReverseWordsinAString res = new ReverseWordsinAString();
		System.out.println(res.reverseWords(
				" a   b "));
	}

	public String reverseWords(String s) {
		   	int i=0,k=0;
		String result="";
		while(i<s.length()){
			k=i;
			while(k<s.length()&&s.charAt(k)!=' '){
				k++;
			}
			
			result=" "+s.substring(i,k)+result;
			while(k<s.length()&&s.charAt(k)==' ') k++;
			i=k;
		}
		 
		 return result.trim();
	
	}
}
