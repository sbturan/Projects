import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class ConcatenatedWords {
	public static void main(String[] args) {
		/*
		 * t:
		 * ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat"
		 * ,"ratcatdogcat"]
		 */
		ConcatenatedWords c = new ConcatenatedWords();
//		System.out.println(c.findAllConcatenatedWordsInADict(new String[] { "cat", "cats", "catsdogcats", "dog",
//				"dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" }));
		
	}

	public List<String> findAllConcatenatedWordsInADict(String[] words) {
		HashSet<String> givenSet = new HashSet<>();
		for (String s : words) {
			givenSet.add(s);
		}

		List<String> result = new ArrayList<>();
		for (String s : words) {
			if (isConcatted(s, givenSet,0)) {
				result.add(s);
			}
		}

		return result;
	}

	private boolean isConcatted(String s, Set<String> lib,int counter) {
        if(s.length()==0) {
        	if(counter>1)return true;
        	return false;
        }
		for (int i = 1; i <= s.length(); i++) {
			if (lib.contains(s.substring(0, i))) {
				if( isConcatted(s.substring(i), lib,counter+1)){
					return true;
				}
			}
		}

		return false;
	}

}
