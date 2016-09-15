
public class PowerofFour {

	public static void main(String[] args) {
		PowerofFour powerofFour = new PowerofFour();
		System.out.println(powerofFour.isPowerOfFour(16));
	}
	
   public boolean isPowerOfFour(int num) {
       
	   double r1 = Math.log10(num);
	   double r2=Math.log10(4);
	   if((r1/r2)%1==0){
		   return true;
	   }
	   return false;
        
    }
}
