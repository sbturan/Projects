public class WaterAndJugProblem {
		 public boolean canMeasureWater(int x, int y, int z) {
			    if(z==0) return true;
			    if(z>x+y) return false;
			    int gcd = GCD(x,y);
			    if(gcd==0) return false;
			    else return z%gcd==0;
			}

			public int GCD(int a, int b) {
			    if (b==0) return a;
			    return GCD(b,a%b);
			}
}
