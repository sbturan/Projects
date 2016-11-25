import java.util.HashSet;
import java.util.Set;

public class NumberofBoomerangs {
	public static void main(String[] args) {
		/*[[0,0],[1,0],[-1,0],[0,1],[0,-1]]*/
		 NumberofBoomerangs n=new NumberofBoomerangs();
		 int[][] points=new int[][]{{0,0},{1,0},{-1,0},{0,1},{0,-1}};
		 System.out.println(n.numberOfBoomerangs(points));

	}

	public int numberOfBoomerangs(int[][] points) {

		int result = 0;
		for (int i = 0; i < points.length; i++) {
			HashSet<Integer> distances = new HashSet<>();
			for (int j = 0; j < points.length; j++) {
				if (i == j)
					continue;
				int distance = getDistance(points[i], points[j]);
				if (distances.contains(distance)) {
					result += 2;
					System.out.println(distance+" "+points[i][0]+" "+points[i][1]+"- "+points[j][0]+" "+points[j][1]);
					continue;
				}

				distances.add(distance);
			}
		}
		
		return result;

	}

	private int getDistance(int[] a, int[] b) {
		  int dx = a[0] - b[0];
		    int dy = a[1] - b[1];
		    
		    return dx*dx + dy*dy;
	}

}
