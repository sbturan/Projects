
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.PriorityQueue;

public class FindKPairswithSmallestSums {
	public static void main(String[] args) {
		FindKPairswithSmallestSums f = new FindKPairswithSmallestSums();
		int[] nums1 = new int[] { 1, 1, 2 };
		int[] nums2 = new int[] { 1, 2, 3 };
		List<int[]> kSmallestPairs = f.kSmallestPairs(nums1, nums2, 2);
		for (int[] a : kSmallestPairs) {
			System.out.print(a[0] + " " + a[1]);
			System.out.println();
		}
	}

	public List<int[]> kSmallestPairs(int[] nums1, int[] nums2, int k) {
		List<int[]> result=new ArrayList<>();
		PriorityQueue<int[]> q = new PriorityQueue<>(new Comparator<int[]>() {

			@Override
			public int compare(int[] o1, int[] o2) {
				Integer i = new Integer(o1[0] + o1[1]);
				return i.compareTo(o2[0] + o2[1]);
			}
		});
		for(int i=0;i<nums1.length;i++){
			for(int j=0;j<nums2.length;j++){
				int[] cur=new int[]{nums1[i],nums2[j]};
				q.add(cur);
				
			}
		}
       for(int i=0;i<k&&!q.isEmpty();i++){
    	   result.add(q.poll());
       }
       
       return result;
		
	}
}
