import java.util.ArrayList;
import java.util.Arrays;

public class Solution_isValidSerialization {

   public static void main(String[] args) {
	 Solution_isValidSerialization s=new Solution_isValidSerialization();
	 System.out.println(s.isValidSerialization("9,3,4,#,#,1,#,#,2,#,6,#,#"));
    }	
   public boolean isValidSerialization(String preorder) {
      
	   
//	   String[] splitted = preorder.split(",");
//	   size=splitted.length;
//	   if(size==1&&splitted[0].trim().equals("#")) return true;
//	if(size%2==0||size<3) return false;
//	   int count=0;
//	   for (String string : splitted) {
//		 if(string.trim().equals("#"))
//			 count++;
//	}
//	   
//	   if(2*count-1!=size) return false;
//	   
//	   return true;
	   
	   String[] splitted = preorder.split(",");
	   size=splitted.length;
	   if(size==1&&splitted[0].trim().equals("#")) return true;
	if(size%2==0||size<3) return false;
	
	preorderArray=new ArrayList<String>(Arrays.asList(splitted));

       visitTree(0);
	
	if(preorderArray.isEmpty()){
		return true;
	}else{
		return false;
	}
    }
   
   private static int size;
   private static ArrayList<String> preorderArray;
   private static void visitTree(int index){
	  if(index>=size) return;
	    
	   if(preorderArray.get(index).trim().equals("#")){
		   preorderArray.remove(index);
		   return;
	   }
	   
	   visitTree(index+1);//remove left
	   visitTree(index+1);//remove right
	   preorderArray.remove(index);//remove own
	   
   }
}
