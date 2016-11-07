public class LRUCache {

        int[] values;
        int[] keys;
        int[] gen; // some generation of value
        int size;
        int lastGen;

        public LRUCache(int capacity) {
            values = new int[capacity];
            keys = new int[capacity];
            gen = new int[capacity];
            size = 0;
            lastGen = 0;
        }

        public int get(int key) {
            int val = -1;
            for (int i = 0; i < size && val == -1; i++)
                if (keys[i] == key) {
                    val = values[i];
                    // update generation to least recently used
                    gen[i] = ++lastGen; 
                }

            return val;
        }

        public void set(int key, int value) {
            int ind = -1;
            boolean inserted = false;
            for (int i = 0; i < size && !inserted; i++) {
                if (keys[i] == key) {
                    inserted = true;
                    ind = i;
                }
            }

            if (!inserted) {
                if (size == keys.length) {
                    int min = Integer.MAX_VALUE;
                    for (int i = 0; i < size; i++) {
                        if (gen[i] < min) {
                            ind = i;
                            min = gen[i];
                        }
                    }
                } else {
                    ind = size;
                    size++;
                }
            }
            keys[ind] = key;
            values[ind] = value;
            gen[ind] = ++lastGen;
        }
    }