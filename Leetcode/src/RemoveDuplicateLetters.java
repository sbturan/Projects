import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;

public class RemoveDuplicateLetters {

	public static void main(String[] args) {
		RemoveDuplicateLetters dp=new  RemoveDuplicateLetters();
		System.out.println(dp.removeDuplicateLetters("bcabc"));
	}

	public String removeDuplicateLetters(String s) {

		HashMap<Integer, List<Integer>> map = new HashMap<>();
		int i = 0;
		for (char ch : s.toCharArray()) {
			if (map.get((int)ch) == null) {
				map.put((int)ch, new ArrayList<Integer>());
			}
			map.get((int)ch).add(i++);
		}

		List<String> combinations = getCombinations(s, map);
		Collections.sort(combinations);
		return combinations.get(0);
	}

	private List<String> getCombinations(String s, HashMap<Integer, List<Integer>> map) {
		ArrayList<String> result = new ArrayList<>();
		if (checkIncludeUniqueChars(s)) {
			result.add(s);
			return result;
		}else if(s.length()==2){
			result.add(s.substring(1));
			return result;
		}

		Iterator<Integer> iterator = map.keySet().iterator();
		int value = -1;
		while (iterator.hasNext()) {
			value = iterator.next();

			if (map.get(value).size() != 1) {
				break;
			}
		}
		List<Integer> list ;//map.get(value);// recalculate
		char currentChar = (char) value;
		int[] positions=new int[s.length()];
		int index2=0;
		Arrays.fill(positions, -1);
		for(int i=0;i<s.length();i++){
			if(s.charAt(i)==value){
				positions[index2++]=i;
			}
		}
		map.remove(value);
		String cToString = Character.toString((char) value);
		String replaceAll = s.replace(cToString, "");
		List<String> combinations = getCombinations(replaceAll, map);
		
		for (String st : combinations) {
			index2=0;
			while(positions[index2]!=-1){
				result.add(addCharAt(st, positions[index2++], currentChar));
			}
		}

		return result;

		// List<String> result=new ArrayList<>();
		// if(checkIncludeUniqueChars(s)){
		// result.add(s);
		// return result;
		// }
		// if(s.length()==2){
		// result.add(s);
		// return result;
		// }
		//

	}

	private String addCharAt(String s, int position, char c) {
		String result="";
		if(position>=s.length()){
         result=s.concat(Character.toString(c));
		}else
		result= s.substring(0, position) + Character.toString(c) + s.substring(position);
		
		return result;
	}

	private boolean checkIncludeUniqueChars(String s) {
		int[] chars = new int[26];
		// - 97
		for (char c : s.toCharArray()) {
			if (chars[c - 97] == 1)
				return false;
			chars[c - 97] = 1;
		}

		return true;
	}
}
