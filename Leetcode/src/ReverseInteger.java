
public class ReverseInteger {
	public static void main(String[] args) {
		System.out.println(reverse(123));
	}
	public static int reverse(int x) {
		if(x==Integer.MIN_VALUE) return 0;
     int sign=1;
     if(x<0){
    	 sign=-1;
    	 x*=-1;
     }
     double result=x%10;
     x/=10;
     while(x>0){
    	 result=result*10+(x%10);
    	 x/=10;
     }
     if(result*sign<Integer.MIN_VALUE||result*sign>Integer.MAX_VALUE) return 0;
     return (int)(result*sign);
	}
}
