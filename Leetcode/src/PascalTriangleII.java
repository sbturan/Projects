import java.util.ArrayList;
import java.util.List;

public class PascalTriangleII {
  public static void main(String[] args) {
	
	  PascalTriangleII p=new PascalTriangleII();
      System.out.println(p.getRow(5));  
  }
	public List<Integer> getRow(int rowIndex) {
     
		List<Integer> result= new ArrayList<Integer>();
		result.add(1);
		if(rowIndex==0) return result;
		result=new ArrayList<>();
		result.add(1);
		result.add(1);
		if(rowIndex==1) return result;
		for(int i=2;i<rowIndex;i++){
			List<Integer> current=new ArrayList<>();
			current.add(1);
	    	for(int j=0;j<result.size()-1;j++){
	    		current.add(result.get(j)+result.get(j+1));
	    	}
	    	current.add(1);
	    	result=current;
		}
		return result;
    }
}
