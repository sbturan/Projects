import java.util.Arrays;

public class AssignCookies {
	public static void main(String[] args) {
		AssignCookies a=new AssignCookies();
		System.out.println(a.findContentChildren(new int[]{1,2}, new int[]{1,2,3}));
			
	}
	public int findContentChildren(int[] g, int[] s) {
  
		Arrays.sort(g);
		Arrays.sort(s);
		int result=0;
		int cookiesIndex=0;
		while(cookiesIndex<s.length&&result<g.length){
			int val=g[result];
			while(cookiesIndex<s.length&&val>s[cookiesIndex]){
				cookiesIndex++;
			}
			if(cookiesIndex<s.length&&val<=s[cookiesIndex]){
				result++;
				cookiesIndex++;
			}
			else break;
		}
        		
		return result;
	}
}
