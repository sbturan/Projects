public class BitwiseANDOfNumbersRange {

	public static void main(String[] args) {
		
	   System.out.println(Integer.toBinaryString(35)+"-"+Integer.toBinaryString(35<<2));
     //System.out.println(rangeBitwiseAnd(1556565,2147483647));		
	}
	public static int rangeBitwiseAnd(int m, int n) {

		int result=m&n;
		if(m==2147483647) return 2147483647;
		if(m<=n/2) return 0;
		for(int i=m+1;i<n;i++){
		    if(result==0) return 0;
			result=result&i;
			
		}
		
		return result;
	}
}
