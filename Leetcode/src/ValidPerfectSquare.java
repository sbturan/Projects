
public class ValidPerfectSquare {
	public static void main(String[] args) {
		ValidPerfectSquare v=new ValidPerfectSquare();
		System.out.println(v.isPerfectSquare(16));
	}
	public boolean isPerfectSquare(int num) {

		int start=0,end=num;
		while(start<=end){
			double val=(start+end)/2;
			if(val*val==num){
				return true;
			}
			if(val*val>num){
				end=(start+end)/2-1;
			}else{
				start=(start+end)/2+1;
			}
		}
		
		return false;
	}
	
}
