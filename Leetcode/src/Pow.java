
public class Pow {
	public static void main(String[] args) {
		Pow p=new Pow();
		/*2.00000
-2147483648*/
		System.out.println(p.myPow(2, 5));
	}
	public double myPow(double x, int n){
		return myPowHelper(x, n,5);
	}
	private double myPowHelper(double x, int n,int divide) {
       if(n==0) return 1;
       if(n==1) return x;
       boolean negative=false;
       double nDouble=(double)n;
       if(nDouble<0){
    	   negative=true;
    	   nDouble*=-1;
       }
       double result=1,multp=myPow(x, (int)nDouble/divide);
       
       for(int i=0;i<divide;i++){
    	   result*=multp;
       }
     for(int i=0;i<nDouble%divide;i++){
    	 result*=x;
     }

       if(negative){
    	   return 1.0/result;
       }
       return result;
	}
}
