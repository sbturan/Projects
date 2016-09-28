import java.util.ArrayList;
import java.util.List;



public class RestoreIPAddresses {
	public static void main(String[] args) {
		
		System.out.println(restoreIpAddresses("010010"));
	}
	public static List<String> restoreIpAddresses(String s) {
      List<String> result=new ArrayList<>();
      if(s.length()>12||s.length()<4) return result;
      return helper(s,1);
	}
	
	private static List<String> helper(String s,int level){
		List<String> result=new ArrayList<>();
		if(s.length()==0){
			return result;
		}
       if(level==4){
    	   if(s.charAt(0)=='0'&&s.length()>1) return result;
    	   if(Integer.valueOf(s)<=255){
    		   result.add(s);
    	   }
    	   return result;
       }
       for(int i=1;i<4&&i<s.length();i++){
    	   String current=s.substring(0,i);
    	   if(Integer.valueOf(current)>255) return result;
    	   for(String s1:helper(s.substring(i),level+1)){
    		   result.add(current.concat(".").concat(s1));
    	   }
    	   if(Integer.valueOf(current)==0) return result;
       }
       return result;
       
	}
}
