import java.util.Arrays;

public class CompareVersionNumbers {
	public static void main(String[] args) {
		/*
		 * "0.1"
"0.0.1"*/
		System.out.println(compareVersion("1.0", "1.0"));
	}
	/*public int compareVersion(String version1, String version2) {
    int i = 0, j = 0, len1 = version1.length(), len2 = version2.length();
    char[] c1 = version1.toCharArray(), c2 = version2.toCharArray();
    while (i < len1 || j < len2) {
        int cur1 = 0, cur2 = 0;
        while (i < len1 && c1[i] != '.') cur1 = cur1 * 10 + c1[i++] - '0';
        while (j < len2 && c2[j] != '.') cur2 = cur2 * 10 + c2[j++] - '0';
        if (cur1 > cur2) return 1;
        if (cur1 < cur2) return -1;
        i++;
        j++;
    }
    return 0;
}*/
	 public static int compareVersion(String version1, String version2) {
		 
		 String[] splitV1 = version1.split("\\.");
		 String[] splitV2 = version2.split("\\.");
		 
		 int index=splitV1.length-1; 
		 while(index>-1&&Integer.valueOf(splitV1[index])==0){
			 index--;
		 }
		 index=Math.max(index, 0);
		 splitV1=Arrays.copyOf(splitV1, index+1);
		 index=splitV2.length-1;
		 
		 while(index>-1&&Integer.valueOf(splitV2[index])==0){
			 index--;
		 }
		 index=Math.max(index, 0);
		 splitV2=Arrays.copyOf(splitV2, index+1);
		 int i=0;
		 while(true){
			 if(i>=splitV1.length) return -1;
			 if(i>=splitV2.length) return 1;
			 int result=Double.compare(Double.valueOf(splitV1[i]), Double.valueOf(splitV2[i]));
			 if(result!=0) return result;
			 if((i==splitV1.length-1)&&i==splitV2.length-1) return 0;
			 i++;
		 }
	    }
}
