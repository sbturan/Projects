import java.util.ArrayList;

public class Test {
	public static void main(String[] args) {
		TreeNode t1 = new TreeNode(1);
		TreeNode t2 = new TreeNode(2);
		TreeNode t3 = new TreeNode(3);
		t2.left = t3;
		t3.left = t1;
//		for(int i=1;i<100;i++){
//			System.out.println(i+" "+lastRemaining(i));	
//		}
		System.out.println(lastRemaining(6157));
		

	}
	  public static int lastRemaining(int n) {
	        return helper(n, true);
	    }
	   static int helper(int n, boolean fromLeft) {
	        if (n == 1) return 1;
	        if (fromLeft) return 2 * helper(n/2, false);
	        return 2 * helper(n/2, true) - 1 + (n & 1);
	    }
}
