import java.util.Arrays;

public class ZigZagConversion {

	public static void main(String[] args) {
		System.out.println(convert("PAYPALISHIRING", 3));
	}
	public static String convert(String s, int numRows) {

		if(numRows==0||numRows==1) return s;
		String[] lines=new String[numRows];
		Arrays.fill(lines, "");
		int i=0;
		int l=0;
		while(i<s.length()){
			
			while(i<s.length()&&l<numRows){
				lines[l]=lines[l]+s.charAt(i);
				l++;
				i++;
			}
			l=l-2;
			while(i<s.length()&&l>-1){
				lines[l]=lines[l]+s.charAt(i);
				l--;
				i++;
			}
			l=l+2;		
		}
		String result="";
		for(String se:lines){
			result=result.concat(se);
		}
		return result;
	}
}
