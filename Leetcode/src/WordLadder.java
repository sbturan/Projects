import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

public class WordLadder {
	public static void main(String[] args) {
		
		/*
		 * beginWord = "hit"
endWord = "cog"
wordList = ["hot","dot","dog","lot","log"]*/
		WordLadder wr=new WordLadder();
		Set<String> wordList=new HashSet<>();
		String arr[]=new String[]{"a","b","c"};
		for (String string : arr) {
			wordList.add(string);
		}
		System.out.println(wr.ladderLength("a", "c", wordList));
	}

	public int ladderLength(String beginWord, String endWord, Set<String> wordList) {
		
		int index = 0;
		wordList.add(beginWord);
		wordList.add(endWord);
		String arr[] = new String[wordList.size()];
		for (String s : wordList) {
			arr[index++] = s;
		}

		HashMap<String, Set<String>> ways = new HashMap<>();
		for (int i = 0; i < wordList.size(); i++) {
			for (int j = i + 1; j < wordList.size(); j++) {
				if (isNeighBoor(arr[i], arr[j])) {
					Set<String> set1 = ways.getOrDefault(arr[i], new HashSet<>());
					set1.add(arr[j]);
					ways.put(arr[i], set1);
					Set<String> set2 = ways.getOrDefault(arr[j], new HashSet<>());
					set2.add(arr[i]);
					ways.put(arr[j], set2);
				}
			}
		}
		int res = helper(beginWord, endWord, new HashSet<>(), ways, 1);
	   	return res==-1?0:res;
	
	}
	private int helper(String s1,String s2,Set<String> way,HashMap<String, Set<String>> ways,int curWay )
	{
		if(way.contains(s1)) return -1;
		way.add(s1);
		Set<String> set = ways.get(s1);
		if(set==null||set.size()==0) return -1;
		int min=Integer.MAX_VALUE; 
		for(String neighBoor:set){
			if(s2==neighBoor){
				{
					way.remove(s1);
					return curWay+1;
					
				}
			}
			
			int res = helper(neighBoor, s2, way, ways, curWay+1);
			if(res!=-1){
				min=Math.min(min, res);
			}
			
		}
		way.remove(s1);
		if(min==Integer.MAX_VALUE) return -1;
		return min;		
	}
	private boolean isNeighBoor(String s1, String s2) {
		int difChar = 0;
		int i = 0;
		while (difChar < 2 && i < s1.length()) {
			if (Character.compare(s1.charAt(i), s2.charAt(i)) != 0) {
				difChar++;
			}
			i++;
		}
		if (difChar == 1)
			return true;
		return false;
	}
}
