import java.util.HashMap;

public class HappyNumber {
	public static void main(String[] args) {
		HappyNumber hn=new HappyNumber();
		System.out.println(hn.isHappy(10));
	}

	private static HashMap<Integer,Integer> list=new HashMap<>();;
    public boolean isHappy(int n) {
    	if(n==1) return true;
    	if(list.get(n)!=null) 
    		return false;
    	list.put(n, 1);
    	int total=0;
    	while(n>9){
    		total+=Math.pow(n%10, 2);
    		n=n/10;
    		
    	};
    	total+=Math.pow(n%10, 2);
         
    	return isHappy(total);
    	
    }
    
	
}
