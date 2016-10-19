import java.util.ArrayList;
import java.util.HashMap;
import java.util.Random;

public class InsertDeleteGetRandomO {
	public static void main(String[] args) {
		RandomizedSet r=new  RandomizedSet();
		r.insert(3);
		r.insert(3);
		System.out.println(r.getRandom());
		System.out.println(r.getRandom());
		r.insert(1);
		r.remove(3);
		System.out.println(r.getRandom());
		System.out.println(r.getRandom());
		System.out.println(r.getRandom());
		System.out.println(r.getRandom());
		r.insert(0);
		r.remove(0);
	}
	public static class RandomizedSet {

	    /** Initialize your data structure here. */
		HashMap<Integer,Integer> map;
		ArrayList<Integer> list;
	    public RandomizedSet() {
	        map=new HashMap<>();
	        list=new ArrayList<>();
	    }
	    
	    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
	    public boolean insert(int val) {
          if(map.containsKey(val)) return false;
          map.put(val, list.size());
          list.add(val);
          return true;
            
	    }
	    
	    /** Removes a value from the set. Returns true if the set contained the specified element. */
	    public boolean remove(int val) {
	        if(!map.containsKey(val))return false;
	        
	        int index = map.get(val);
	        if(index==list.size()-1){
	        	list.remove(list.size()-1);
	        	map.remove(val);
	        	return true;
	        }
	        Integer lastElement=list.get(list.size()-1);
	        list.remove(index);
	        list.add(index,lastElement);
	        list.remove(list.size()-1);
	        map.put(lastElement, index);
	        map.remove(val);
	        return true;
	    }
	    
	    /** Get a random element from the set. */
	    public int getRandom() {
	        Random rd=new Random();
	        return list.get(rd.nextInt(list.size()));
	    }
	}
}
