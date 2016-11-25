import java.util.Comparator;
import java.util.HashMap;
import java.util.TreeSet;


class Item  {

	int key;
	int value;
	int frequency;
	Long lastUsedTime;
    
	public Item(int key,int value){
		this.key=key;
		this.value=value;
	    this.frequency=0;
        this.lastUsedTime=0L;
	}

	

}

public class LFUCache {
//	public static void main(String[] args) throws InterruptedException {
//		
//		LFUCache lfu=new LFUCache(2);
//		lfu.set(3, 1);
//		lfu.set(2, 1);
//		lfu.set(2, 2);
//		lfu.set(4, 4);
//		System.out.println(lfu.get(2));
////		lfu.set(3, 3);
////		System.out.println(lfu.get(2));
////		System.out.println(lfu.get(3));
////		lfu.set(4, 4);
////		System.out.println(lfu.get(1));
////		System.out.println(lfu.get(3));
////		System.out.println(lfu.get(4));
//		
//	}
	HashMap<Integer, Item> map;
	int capacity;
	TreeSet<Item> tree;
	public LFUCache(int capacity) {
		map = new HashMap<>();
		this.capacity = capacity;
		tree=new TreeSet<>(new Comparator<Item>() {

			@Override
			public int compare(Item o1, Item o2) {
				if(o1.frequency!=o2.frequency){
					return o1.frequency-o2.frequency;
				}
				if(Long.compare(o1.lastUsedTime, o2.lastUsedTime)!=0)
				return Long.compare(o1.lastUsedTime, o2.lastUsedTime);
				return Integer.compare(o1.key, o2.key);
			}
		});
	}

	public int get(int key) {

      if(!map.containsKey(key)) return -1;
      Item item = map.get(key);
      tree.remove(item);
      item.frequency+=1;
      item.lastUsedTime=System.currentTimeMillis();
      tree.add(item);
      map.put(item.key,item);
      return item.value;
	}

	public void set(int key, int value) {
        if(map.containsKey(key)) {
        	Item item = map.get(key);
        	tree.remove(item);
        	item.lastUsedTime=System.currentTimeMillis();
        	item.value=value;
        	tree.add(item);
        	map.put(item.key, item);
        	return;
        }
		if(capacity==map.size()){
        	Item pollFirst = tree.pollFirst();
        	if(pollFirst!=null)
            map.remove(pollFirst.key);
           
        }
		if(map.size()<capacity)
		{
			Item item=new Item(key,value);
	         map.put(item.key, item);
	         tree.add(item);
		}
         
	}
}
