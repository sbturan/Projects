import java.util.HashMap;

public class AllOoneDataStructure {
	public static void main(String[] args) {
		AllOoneDataStructure a=new AllOoneDataStructure();
		AllOne b=a.new AllOne();
		b.inc("hello");
		b.inc("world");
		b.inc("leet");
		b.dec("code");
		b.inc("DS");
		b.inc("leet");
		System.out.println(b.getMaxKey());
		b.inc("DS");
		b.dec("leet");
		
		System.out.println(b.getMaxKey());
	}
	public class AllOne {

		/** Initialize your data structure here. */
		HashMap<String, Integer> map;
		int maxCount;
		String maxString;
		int minCount;
		String minString;

		public AllOne() {
			map = new HashMap<>();
			maxCount = 0;
			maxString = "";
			minCount = Integer.MAX_VALUE;
			minString = "";

		}

		/**
		 * Inserts a new key <Key> with value 1. Or increments an existing key
		 * by 1.
		 */
		public void inc(String key) {
			Integer value = map.getOrDefault(key, 0);
			value++;
			map.put(key, value);
			if (value > maxCount) {
				maxCount = value;
				maxString = key;
			}
			 if (value < minCount) {
			 minCount = value;
			 minString = key;
			 }
			if (value - 1 == minCount) {
				minCount++;
				for (String s : map.keySet()) {
					if (map.get(s) == value - 1) {
						minCount = value - 1;
						minString = s;
						break;
					}
				}
			}

		}

		/**
		 * Decrements an existing key by 1. If Key's value is 1, remove it from
		 * the data structure.
		 */
		public void dec(String key) {
			Integer value = map.get(key);
			if (value == null)
				return;
			value--;
			if (value == 0) {
				map.remove(key);
				Integer min = Integer.MAX_VALUE;
				Integer max=0;
				String curminString = "";
				String curMaxString="";
				for (String s : map.keySet()) {
					Integer integer = map.get(s);
					if (integer < min) {
						min = integer;
						curminString = s;
					}
					if(integer>max){
						max=integer;
						curMaxString=s;
					}
				}
				minCount = min;
				minString = curminString;
				maxCount=max;
				maxString=curMaxString;
			} else {
				map.put(key, value);
				if (value < minCount) {
					minCount = value;
					minString = key;
				}
				if (value + 1 == maxCount) {
					maxCount--;
					for (String s : map.keySet()) {
						if (map.get(s) == value + 1) {
							maxCount = value + 1;
							maxString = s;
							break;
						}
					}
				}
			}
		}

		/** Returns one of the keys with maximal value. */
		public String getMaxKey() {
			return maxString;
		}

		/** Returns one of the keys with Minimal value. */
		public String getMinKey() {
			return minString;
		}
	}
}
