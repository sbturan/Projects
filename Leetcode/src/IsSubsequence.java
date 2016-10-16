
public class IsSubsequence {
	public static void main(String[] args) {
		IsSubsequence a=new IsSubsequence();
		/*"abc"
"ahbgdc"*/
		System.out.println(a.isSubsequence("abc", "ahbgdc"));
	}
	public boolean isSubsequence(String s, String t) {

		if(s.length()==0) return true;
		int firstIndex=t.indexOf(s.charAt(0));
		if(s.length()==1){
			return firstIndex!=-1;
		}
		char[] charArray = s.toCharArray();
		for(int i=1;i<s.length();i++){
          firstIndex=t.indexOf(charArray[i],firstIndex+1);
          if(firstIndex==-1) {
        	  return false;
          }
		}
		return true;
	}
}
