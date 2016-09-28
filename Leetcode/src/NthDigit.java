
public class NthDigit {
	public static void main(String[] args) {
		 
		for(int i=1000000;i<1000008;i++)
		System.out.println(findNthDigit(i));
		
	}
	public static int findNthDigit(int n) {

		if(n < 10){
			return n;
		}
		//get string length
		String s = Integer.toString(n);
		int len = s.length(); 
	    int i;
	    int cur;
	    int pass = 0;   

		for(i = 1; i <= len; i++){
			//9 * 1, 90 * 2, 900 * 3...
			cur = 9 * (int)Math.pow(10, i - 1) * i;
			//avoid out of bound
			if(i == 9){
				if(n % i == 0){
					return ((int)Math.pow(10, i - 1) + n / i - 1) % 10;
				}
				else{
					pass = (int)Math.pow(10, i - 1) + n / i;
					break;
				}
			}
			
			//normal case
			if(cur < n){
				n -= cur;
			}
			else if(cur == n){
				return 9;
			}
			
			else if(cur > n){
				if(n % i == 0){
					//printout the target number's last digit
					return ((int)Math.pow(10, i - 1) + n / i - 1) % 10;
				}
				else{
					pass = (int)Math.pow(10, i - 1) + n / i;
					break;
				}
			}	   
	    }
		//find the relation index's number on the target number
	    return Integer.toString(pass).charAt((n % i) - 1) - '0';
    		   
	}
}
