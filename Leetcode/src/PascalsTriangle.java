import java.util.ArrayList;
import java.util.List;

public class PascalsTriangle {
	public static void main(String[] args) {
		PascalsTriangle p= new PascalsTriangle();
		List<List<Integer>> generate = p.generate(15);
		for(List<Integer> a:generate){
			System.out.println(a);
		}
	}
public List<List<Integer>> generate(int numRows) {
        
	List<List<Integer>> result= new ArrayList<List<Integer>>();
	if(numRows==0) return result;
	ArrayList<Integer> r1=new ArrayList<>();
    r1.add(1);
    result.add(r1);
    if(numRows==1) return result;
    ArrayList<Integer> r2=new ArrayList<>();
    r2.add(1);
    r2.add(1);
    result.add(r2);
    for(int i=3;i<=numRows;i++){
    	List<Integer> current=new ArrayList<>();
    	current.add(1);
    	List<Integer> before = result.get(result.size()-1);
    	for(int j=0;j<before.size()-1;j++){
    		current.add(before.get(j)+before.get(j+1));
    	}
    	current.add(1);
    	result.add( current);
    }
    
    return result;
    }
}
