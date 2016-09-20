import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class WordBreakII {
	
	public static void main(String[] args) {
		WordBreakII wb=new WordBreakII();
		Set<String> set=new HashSet<>();
		set.add("cat");
		set.add("cats");
		set.add("and");
		set.add("sand");
		set.add("dog");
		System.out.println(wb.wordBreak("catsanddog", set));
	}

	public List<String> wordBreak(String s, Set<String> wordDict) {

	     return helper(0, s, wordDict, new HashMap<Integer,List<String>>());

	}
	
	private List<String> helper (int index,String s,Set<String> words,HashMap<Integer,List<String>> dp){
		
		if(dp.get(index)!=null){
			return dp.get(index); 
		}
		int i = 1;
		List<String> result = new ArrayList<>();
		while (i < s.length() + 1) {
			String substring = s.substring(0, i);
			if (words.contains(substring)) {
				if (i < s.length()) {
					List<String> list = helper(i+index,s.substring(i), words,dp);
					for (String se : list) {
						result.add(substring.concat(" ").concat(se));
					}
				} else {
					result.add(substring);
				}

			}
			i++;
		}
       dp.put(index, result);
		return result;
	}
	 
}
