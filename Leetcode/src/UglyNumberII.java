public class UglyNumberII {
	public static void main(String[] args) {
		UglyNumberII uglyNumberII = new UglyNumberII();
		System.out.println(uglyNumberII.nthUglyNumber(10));
        
	}
	public int nthUglyNumber(int n) {
		
		int[] uglyNumbers=new int[n];
		uglyNumbers[0]=1;
		int l2=0;
		int l3=0;
		int l5=0;
		for(int i=1;i<n;i++){
              uglyNumbers[i]=Math.min(Math.min(uglyNumbers[l2]*2, uglyNumbers[l3]*3), 
            		  uglyNumbers[l5]*5);
              if(uglyNumbers[i]==uglyNumbers[l2]*2) l2++;
              if(uglyNumbers[i]==uglyNumbers[l3]*3) l3++;
              if(uglyNumbers[i]==uglyNumbers[l5]*5) l5++;
			
		}
		
		return uglyNumbers[n-1];
	}

}
