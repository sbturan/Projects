
public class RansomNote {

	     public boolean canConstruct(String ransomNote, String magazine) {
	    
	    	  
	    	 for(int i=0;i<magazine.length();i++){
                  String replace = magazine.replaceFirst(magazine.substring(i,i+1),"");
                  if(replace.equals(magazine)) return false;
                  magazine=replace;
	    	 }
	    	 
	    	 return true;
	    	 
	    	 
	    }
}
