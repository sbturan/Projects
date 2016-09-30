import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class GroupAnagrams {
	public static void main(String[] args) {
		GroupAnagrams g=new GroupAnagrams();
		System.out.println(g.groupAnagrams(new String[]{"hgh","ghh"}));
	}
	public List<List<String>> groupAnagrams(String[] strs) {
        Map<String,List<String>> map=new HashMap<>();
        
        for(String s:strs){
        	char[] charArray = s.toCharArray();
        	Arrays.sort(charArray);
			String key=new String(charArray);
			List<String> value = map.getOrDefault(key, new ArrayList<String>());
			value.add(s);
			map.put(key, value);
        	
        }
        
        
        return new ArrayList<>(map.values());
        
	}
}
