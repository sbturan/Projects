
public class BulbSwitcher {
	public static void main(String[] args) {
		int count = 10;
		int arra[]=new int[count];
		for(int i=1;i<count;i++){
			for(int j=i;j<count;j=j+i){
				arra[j]=arra[j]^1;
			}
		}
		
		for (int i=0;i<count;i++) {
			System.out.print(i+" "+arra[i]);
			System.out.println();
		}
		System.out.println(bulbSwitch(count));
	}
	 public static int bulbSwitch(int n) {
		 int i=1;
	     int result=0;
		 while((i*i)<=n){
			 i++;
			 result++;
		 }
		 return result;
		 
	    }
}
