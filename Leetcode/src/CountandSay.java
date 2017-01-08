

public class CountandSay {
	public static void main(String[] args) {
		CountandSay c=new CountandSay();
		System.out.println(c.countAndSay(5));
	}
	public String countAndSay(int n) {
		if(n<2) return "1";
	    String cur="1"; 
	    while(n>1){
	    	cur=helper(cur.toCharArray());
	    	n--;
	    }
	    return cur;
	}
	
    public String helper(char[] charArray) {
        StringBuilder sb = new StringBuilder();
		int index = 1;
		char curChar = charArray[0];
		if(charArray.length==1){
			return "1"+curChar;
		}
		int count = 1;
		while (index < charArray.length) {
			if (curChar != charArray[index]) {
				sb.append(count + "" + curChar);
				curChar = charArray[index];
				count = 1;
			} else {
				count++;
			}
			index++;
		}
		if(count>0){
			sb.append(count + "" + curChar);
		}
		return sb.toString();
    }
}
