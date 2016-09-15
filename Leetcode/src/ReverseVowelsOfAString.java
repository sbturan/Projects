
public class ReverseVowelsOfAString {
  public static void main(String[] args) {
	  ReverseVowelsOfAString r= new ReverseVowelsOfAString();
	  System.out.println(r.reverseVowels(".,"));
	  
	  
}
	
    public String reverseVowels(String s) {
       
    	if(s.length()<=1) return s;
    	 char[] chars=s.toCharArray();
    	 int length=s.length();
    	 
    	 int start=0;
    	 int end=length-1;
    	 while(true){
    		 while(start<length&&!checkVowel(chars[start])){
    			 start++;
    		 }
    		 if(start>=length) return s;
    		 
    		 while(!checkVowel(chars[end])){
    			 end--;
    		 }
    		 if(start>=end) break;
    		 char tmp=chars[start];
    		 chars[start]=chars[end];
    		 chars[end]=tmp;
    		 start++;
    		 end--;
    	 }
    	 
    	 
    	
    	
    	return String.valueOf(chars);
    }
    
    private static boolean checkVowel(char a){
    	a=Character.toLowerCase(a);
    	if(a=='a'||a=='e'||a=='i'||a=='o'||a=='u'){
    		return true;
    	}
    	  return false;
    	
    }
}
