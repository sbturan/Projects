import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;

public class LetterCombinationsOfAPhoneNumber {
	 public static void main(String[] args) {
		 LetterCombinationsOfAPhoneNumber l = new LetterCombinationsOfAPhoneNumber();
		System.out.println(l.letterCombinations("626"));
	}
	
	 static HashMap<String,List<String>>  buttons=new HashMap<String,List<String>>();
	    
    public List<String> letterCombinations(String digits) {
        
    	if(digits.length()==0) return new ArrayList<String>();
    	buttons.put("2", Arrays.asList("a","b","c"));
	    buttons.put("3", Arrays.asList("d","e","f"));
	    buttons.put("4", Arrays.asList("g","h","i"));
	    buttons.put("5", Arrays.asList("j","k","l"));
	    buttons.put("6", Arrays.asList("m","n","o"));
	    buttons.put("7", Arrays.asList("p","q","r","s"));
	    buttons.put("8", Arrays.asList("t","u","v"));
	    buttons.put("9", Arrays.asList("w","x","y","z"));
   
//      return dfs(digits,1,buttons.get(digits.substring(0,1)));
    List<String> result=new ArrayList<>();
    
    List<String> clusters=new ArrayList<>();
    clusters.addAll(buttons.get(digits.substring(0, 1)));
    if(digits.length()==1) return clusters;
    for(int i=1;i<digits.length()-1;i++){
    	String current=digits.substring(i,i+1);
    	if(current.equals("1")||current.equals("0")) continue;
    	List<String> currentList=buttons.get(current);
    	List<String> newClusters=new ArrayList<>();
    	for(int j=0;j<clusters.size();j++){
    		String currentCluster=clusters.get(j);
    		for(int k=0;k<currentList.size();k++){
    			newClusters.add(currentCluster.concat(currentList.get(k)));
    		}
    	}
    	
    	clusters=newClusters;
    	
    }
    
    
    String current=digits.substring(digits.length()-1,digits.length());
	List<String> currentList=buttons.get(current);
	for(int j=0;j<clusters.size();j++){
		String currentCluster=clusters.get(j);
		for(int k=0;k<currentList.size();k++){
			result.add(currentCluster.concat(currentList.get(k)));
		}
	}
    
    
    
     
    
    return result;
    }
    
//    public static List<String> dfs(String input,int index,List<String> a){
//    	
//    	if(index>=input.length()){
//    		return a;
//    	}
//    	List<String> b=new ArrayList<>();
//    	for(int i=0;i<a.size(); i++){
//    		String current=a.get(i);
//    		for(String c :buttons.get(input.substring(index, index+1))){
//    			b.add(i, current.concat(c)) ;
//    		}
//    		
//    	}
//    	
//    	return dfs(input,index+1,b);
//    	
//    	
//    	
//    	
//    }
}
