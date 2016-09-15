import java.lang.reflect.Array;

public class ValidNumber {

	public static void main(String[] args) {
		ValidNumber va=new ValidNumber();
		System.out.println(va.isNumber("e"));
	}
	
	 public boolean isNumber(String s) {
		
		 s=s.trim();
		 if(s.length()==0) return false;
		 if(s.charAt(0)=='-'||s.charAt(0)=='+'){
			 s=s.substring(1,s.length());
		 }
		 boolean pointExist=false;
		 boolean eExist=false;
		 boolean signExist=false;
		 for(int i=0;i<s.length();i++) {
			 char c=s.charAt(i);
			 
			 if(c!='0'&&
					 c!='1'&&
					 c!='2'&&
					 c!='3'&&
					 c!='4'&&
					 c!='5'&&
					 c!='6'&&
					 c!='7'&&
					 c!='8'&&
					 c!='9'&&
					 c!='e'&&
					 c!='.'&&c!='+'&&c!='-'){
				 System.out.println("1="+c);
				 return false;
			 }
			 
			 if(c=='e'){
				 if(eExist){
					 System.out.println("2");
				 return false;
				 }
				 else if((i==0||i==s.length()-1)) return false;
				 else if(pointExist&&s.charAt(i-1)=='.'&&i==1) return false;
				 else eExist=true;
			 } 
			 if(c=='.'){
				 if(pointExist){
					 System.out.println("3");
					 return false;
				 }
				  else if(s.length()==1) return false;
				  else if(eExist) return false;
				 else pointExist=true;
			 }
			 
			 if(c=='+'||c=='-'){
			     if(signExist) return false;
			     signExist=true;
			     if(i==0||s.charAt(i-1)!='e'||(i==s.length()-1)) return false;
			 }
			 
			 
		 }
		 
		 return true;
	 
	    
    
	    
    }
}
