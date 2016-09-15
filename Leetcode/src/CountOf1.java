import java.util.Scanner;

public class CountOf1 {

	public static void main(String[] args) {
		int input;
		while(true){
			try{
				System.out.println("ilgili sayýyý girin");
				Scanner sc= new Scanner(System.in);
				input=sc.nextInt();
				
				System.out.println("binary hali="+Integer.toBinaryString(input));
				System.out.println("sonuc="+getCountOfOne(input));	
			} catch (Exception e){
				System.out.println("tam sayý girin");
			}
		
		
		}
		
	}
	 public static int[] countBits(int num) {
		 int[] result=new int[num+1];
		 
		 for(int i=0;i<=num;i++){
			 result[i]=getCountOfOne(i);
		 }
		 
		 
		 return result;
		
		
    }
    
    static int getCountOfOne(int n){
    	n = n - ((n >>> 1) & 0x55555555);
		n = (n & 0x33333333) + ((n >>> 2) & 0x33333333);
		n = (n + (n >>> 4)) & 0x0f0f0f0f;
		n = n + (n >>> 8);
		n = n + (n >>> 16);
		return n & 0x3f;
    }
    
    
}
