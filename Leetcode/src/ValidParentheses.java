public class ValidParentheses {
	public static void main(String[] args) {
		ValidParentheses v=new ValidParentheses();
		System.out.println(v.isValid("{}][}}{[))){}{}){(}]))})[({"));
	}
	public boolean isValid(String s) {
      
		int p1=0;
		int p2=0;
		int p3=0;
		
		char[] charArray = s.toCharArray();
		int[] lastArray=new int[charArray.length];
		int k=-1;
		for(char c:charArray){
			if(c=='('){
				//last=1;
				k++;
				lastArray[k]=1;
				p1++;
				
			}else if(c==')'){
				if((k==-1||k>-1&&lastArray[k]!=1)) 
					return false;
				
				k--;
				p1--;
			}else if(c=='{'){
				k++;
				lastArray[k]=2;
				p2++;
			}else if(c=='}'){
				if(k==-1||(k>-1&&lastArray[k]!=2)) 
					return false;
				k--;
				p2--;
			}else if(c=='['){
				k++;
				lastArray[k]=3;
				p3++;
			}else if(c==']'){
				if(k==-1||(k>-1&&lastArray[k]!=3))
					return false;
				k--;
				p3--;
			}
		}
		
		if(p1==0&&p3==0&&p2==0){
			return true;
		}
		
		return false;
    }
}
