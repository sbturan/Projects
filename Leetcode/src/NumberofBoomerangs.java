import java.util.HashMap;
import java.util.Map;

public class NumberofBoomerangs {
	public static void main(String[] args) {
		/*[[0,0],[1,0],[-1,0],[0,1],[0,-1]]*/
		 NumberofBoomerangs n=new NumberofBoomerangs();
		 int[][] points=new int[][]{{0,0},{1,0},{-1,0},{0,1},{0,-1}};
		 System.out.println(n.numberOfBoomerangs(points));

	}
	public int numberOfBoomerangs(int[][] points) {
	    int res = 0;        
	    Map<Integer, Integer> map = new HashMap<>();

	    for(int i=0; i<points.length; i++) {
	        for(int j=0; j<points.length; j++) {
	            if(i == j)
	                continue;
	            
	            int d = getDistance(points[i], points[j]);                
	            map.put(d, map.getOrDefault(d, 0) + 1);
	        }
	        
	        for(int val : map.values()) {
	            res += val * (val-1);
	        }            
	        map.clear();
	    }
	    
	    return res;
	}

	private int getDistance(int[] a, int[] b) {
	    int dx = a[0] - b[0];
	    int dy = a[1] - b[1];
	    
	    return dx*dx + dy*dy;
	}
}