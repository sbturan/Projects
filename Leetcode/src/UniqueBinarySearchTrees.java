
public class UniqueBinarySearchTrees {
	public static void main(String[] args) {
		UniqueBinarySearchTrees u=new UniqueBinarySearchTrees();
		System.out.println(u.numTrees(6));
	}

	public int numTrees(int n) {
      
		int result[]=new int[n+1];
		result[0]=1;
		result[1]=1;
		for(int i=1;i<=n;i++){
			int total=0;
			for(int j=1;j<=i;j++){
				total+=result[j-1]*result[i-j];
			}
			result[i]=total;
		}
	
		return result[n];
    }
	
}
