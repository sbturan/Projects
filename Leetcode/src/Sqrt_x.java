
public class Sqrt_x {
	public static void main(String[] args) {
		Sqrt_x s=new Sqrt_x();
		System.out.println(s.mySqrt(2147395599));
	}
	 public int mySqrt(int x) {
			int start=0,end=x;
			while(start<=end){
				double val=(start+end)/2;
				if(val*val==x){
					return (int)val;
				}
				if(val*val>x){
					end=(start+end)/2-1;
				}else{
					start=(start+end)/2+1;
				}
			}
			
			return end;
	    }
}
