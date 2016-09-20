import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Random;

public class InsertDeleteGetRandom {
	public static void main(String[] args) {
		RandomizedCollection r=new RandomizedCollection();
		r.insert(1);
		r.insert(2);
		r.insert(3);
		r.insert(4);
		r.remove(4);
		r.remove(3);
		r.remove(2);
		r.remove(1);
		r.remove(0);
		
	}

	public static class RandomizedCollection {
	    private ArrayList<Integer> arrayList;
	    private HashMap<Integer, HashSet<Integer>> hashMap;
	    private Random random;

	    public RandomizedCollection() {
	        arrayList = new ArrayList<>();
	        hashMap = new HashMap<>();
	        random = new Random();
	    }

	    public boolean insert(int val) {
	        boolean result = !hashMap.containsKey(val) || hashMap.get(val).isEmpty();
	        hashMap.computeIfAbsent(val, key -> new HashSet<>()).add(arrayList.size());
	        arrayList.add(val);
	        return result;
	    }

	    public boolean remove(int val) {
	        if (hashMap.containsKey(val) && !hashMap.get(val).isEmpty()) {
	            HashSet<Integer> setOfCurrentElement = hashMap.get(val);
	            Integer currentIndex = setOfCurrentElement.iterator().next();
	            setOfCurrentElement.remove(currentIndex);
	            int lastIndex = arrayList.size() - 1;
	            Integer lastElement = arrayList.get(lastIndex);
	            arrayList.set(currentIndex, lastElement);
	            HashSet<Integer> setOfLastElement = hashMap.get(lastElement);
	            setOfLastElement.add(currentIndex);
	            setOfLastElement.remove(lastIndex);
	            arrayList.remove(lastIndex);
	            return true;
	        }
	        return false;
	    }

	    public int getRandom() {
	        return arrayList.get(random.nextInt(arrayList.size()));
	    }
	}
	/**
	 * Your RandomizedCollection object will be instantiated and called as such:
	 * RandomizedCollection obj = new RandomizedCollection();
	 * boolean param_1 = obj.insert(val);
	 * boolean param_2 = obj.remove(val);
	 * int param_3 = obj.getRandom();
	 */
}
