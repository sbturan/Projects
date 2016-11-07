
public class ValidPalindrome {
	public static void main(String[] args) {
		System.out.println(isPalindrome("ab"));
	}
public static boolean isPalindrome(String s) {
  char[] charArray =s.toCharArray();
  int i=0,j=s.length()-1;
  while(i<=j){
	  while(i<charArray.length&&!Character.isLetterOrDigit(charArray[i])){
		  i++;
	  }
	  while(j>-1&&!Character.isLetterOrDigit(charArray[j])){
		  j--;
	  }
	  if(j<=i) return true;
	  if(Character.isUpperCase(charArray[i])){
		  charArray[j]=Character.toUpperCase(charArray[j]);
	  }else{
		  charArray[j]=Character.toLowerCase(charArray[j]);
	  }
	  if(charArray[i]!=charArray[j]) return false;
	  i++;
	  j--;
  }
  return true;
  
 }
}
