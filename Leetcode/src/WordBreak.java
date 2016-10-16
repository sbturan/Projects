import java.util.HashSet;
import java.util.Set;

public class WordBreak {
	public static void main(String[] args) {
		/*
		 * "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab"
["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]*/
		WordBreak wb=new WordBreak();
		String s="aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";
		Set<String> a=new HashSet<>();
		a.add("a");
		a.add("aa");
		a.add("aaa");
		a.add("aaaa");
		a.add("aaaaa");
		a.add("aaaaaa");
		a.add("aaaaaaa");
		a.add("aaaaaaaa");
		a.add("aaaaaaaaa");
		a.add("aaaaaaaaaa");
		System.out.println(wb.wordBreak(s,a));
	}
	
	public boolean wordBreak(String s, Set<String> wordDict) {
		
		int [] dp1=new int[s.length()];
		boolean[] dp2=new boolean[s.length()];
		
		return helper(0,s, wordDict, dp1, dp2);
	}
	private boolean helper(int index,String s,Set<String> wordDict,int[] dp1,boolean[] dp2){
		if(s.length()==0) return true;
		if(dp1[index]!=0) return dp2[index];
		StringBuilder sb=new StringBuilder(s);
		for(int i=0;i<sb.length();i++){
			if(wordDict.contains(sb.substring(0, i+1))){
				boolean helper = helper(index+i,sb.substring(i+1), wordDict,dp1,dp2);
				dp1[index+i]=1;
				dp2[index+i]=helper;
				if( helper) return true;
			}
		}
		dp1[index]=1;
		dp2[index]=false;
		return false;
	}
} 
