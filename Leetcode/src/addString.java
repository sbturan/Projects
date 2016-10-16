public class addString {
	public static void main(String[] args) {
		/*"6913259244"
"71103343"*/
		System.out.println(addStrings("1", "1"));
	}
	public static String addStrings(String num1, String num2) {
     char[] charArray = num1.toCharArray();
     char[] charArray2 = num2.toCharArray();
     char [] result=new char[Math.max(charArray.length, charArray2.length)+1];
     int i1=charArray.length-1,i2=charArray2.length-1;
     int curIndex=result.length-1;
     int remain=0;
     while(i1>-1||i2>-1){
    	 if(i1==-1){
    		 int cur=((charArray2[i2--]-'0')+remain);
    		 result[curIndex--]=(char)((cur %10)+'0');
    		 remain=cur/10;
    	 }else if(i2==-1){
    		 int cur=((charArray[i1--]-'0')+remain);
    		 result[curIndex--]=(char)((cur %10)+'0');
    		 remain=cur/10;
          }else{
        	  int cur=((charArray[i1--]-'0')+(charArray2[i2--]-'0')+remain);
        	  result[curIndex--]=(char)((cur %10)+'0');
     		 remain=cur/10;
          }
	}
     result[curIndex]=(char)(remain+'0');
    int i=0;
    while(i<result.length&&(!Character.isDigit(result[i])||result[i]=='0')){
    	i++;
    }
      if(i==result.length) return "0";
     return new String(result).substring(i);
	}
}
