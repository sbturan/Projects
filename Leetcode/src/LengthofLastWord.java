public class LengthofLastWord {
	public static void main(String[] args) {
		LengthofLastWord l=new LengthofLastWord();
		System.out.println(l.lengthOfLastWord("a "));
	}
	public int lengthOfLastWord(String s) {
		 char[] charArray = s.toCharArray();
		 int i=s.length()-1;
		 while(i>-1&&charArray[i]==' '){
			 i--;
		 }
		 int k=i;
		 while(i>-1&&charArray[i]!=' '){
			 i--;
		 }
		 return k-i;
	}
}
