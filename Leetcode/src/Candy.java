import java.util.Arrays;

public class Candy {
	public static void main(String[] args) {
		Candy c=new Candy();
		System.out.println(c.candy(new int[]{5,3,1}));
	}
	public int candy(int[] ratings) {
       if(ratings.length<2) return ratings.length;
       int[] candies=new int[ratings.length];
       Arrays.fill(candies, 1);
       for(int i=1;i<ratings.length;i++){
    	   if(ratings[i]>ratings[i-1]){
    		   candies[i]=candies[i-1]+1;
    	   }
       }
       for(int i=candies.length-1;i>0;i--){
    	   if(ratings[i-1]>ratings[i])
    		   candies[i-1]=Math.max(candies[i]+1, candies[i-1]);
       }
       
       int result=0;
       for(int i:candies){
    	   result+=i;
       }
       
       return result;
	}
}
