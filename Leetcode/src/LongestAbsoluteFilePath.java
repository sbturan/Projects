import java.util.Arrays;
import java.util.HashMap;

public class LongestAbsoluteFilePath {

	public static void main(String[] args) {
		int r=lengthLongestPath("a\n\tb\n\t\tc.txt");
		System.out.println(r);
	}
	public static int lengthLongestPath(String input) {
	       if(!input.contains(".")) return 0;
	       int size=0;
	       String curr=input;
	       while(curr.indexOf('\n')!=-1){
	    	   curr=curr.substring(curr.indexOf('\n')+1);
	    	   size++;
	       }
	       if(size==0) return input.length();
	       String[][] fileSystem=new String[size+1][size+1];
	       HashMap<Integer,Integer> fileExist=new HashMap<>();
	       int level=0;
	       int index=0;
	       char[] charArray = input.toCharArray();
	       int i=0;
	       while(i<charArray.length){
	    	   int j=i;
	    	   StringBuilder sb=new StringBuilder("");
	    	   while(j<charArray.length&&charArray[j]!='\n'){
	    		   sb.append(charArray[j]);
	    		   j++;
	    	   }
	    	   fileSystem[index][level]=sb.toString();
	    	   if(sb.indexOf(".")!=-1){
	    		  fileExist.put(index, level);
	    	   }
	    	   i=j;
	    	   int countOfT=0;
	    	   int oldLevel=level;
	    	   while(j<charArray.length&&(charArray[j]=='\n'||charArray[j]=='\t')){
	    		   if(charArray[j]=='\t')countOfT++;
	    		   j++;
	    	   }
	    	   level=countOfT;
	    	   if(level<=oldLevel){
	    		   index++;
	    		   fileSystem[index]=Arrays.copyOf(fileSystem[index-1],fileSystem[index-1].length);
	    	   }
	    	   i=j;
	    	   
	       }
	       int result=0;
	       for(Integer in:fileExist.keySet()){
	    	   int currentCount=-1;
	    	   for(int k=0;k<=fileExist.get(in);k++){
	    		   currentCount+=fileSystem[in][k].length()+1;
	    	   }
	    	   result=Math.max(result, currentCount);
	       }
	       return result;
	}
}
