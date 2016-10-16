import java.io.IOException;
import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class Test {
	public static void main(String[] args) throws NumberFormatException, IOException {
		
		Scanner sc=new Scanner(System.in);
		int row=sc.nextInt();
		sc.nextInt();
		sc.nextLine();
		int[] array=new int[row];
		for(int i=0;i<row;i++){
			array[i]=Integer.parseInt(sc.nextLine(), 2);
		}
		sc.close();
		int maxTeam=0;
		int maxTopic=0;
		for(int i=0;i<row;i++){
			for(int j=i+1;j<row;j++){
				if(Integer.bitCount(array[i]|array[j])>maxTopic){
					maxTopic=(Integer.bitCount(array[i]|array[j]));
					maxTeam=1;
				}else if(Integer.bitCount(array[i]|array[j])==maxTopic){
					maxTeam++;
				}
			}
		}
			
		System.out.println(maxTopic);
		System.out.println(maxTeam);
		
	}


}
