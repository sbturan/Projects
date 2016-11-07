
public class ArrangingCoins {
	public static void main(String[] args) {
		System.out.println(arrangeCoins(1804289383));
	}
	  public static int arrangeCoins(int n) {
	     /* n.n+1 /2 */
		  long m=2L*n;
		  m=(long) Math.sqrt(m);
		  if(m*(m+1)/2<=n) return (int)m;
		  return (int)m-1;
	    }
}
