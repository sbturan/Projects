import java.util.ArrayList;
import java.util.List;

public class MergeIntervals {

	public static void main(String[] args) {
		//[[5,5],[1,2],[2,4],[2,3],[4,4],[5,5],[2,3],[5,6],[0,0],[5,6]]
		Interval i1=new Interval(5,5);
		Interval i2=new Interval(1,2);
		Interval i3=new Interval(2,4);
		Interval i4=new Interval(2,3);
		Interval i5=new Interval(4,4);
		Interval i6=new Interval(5,5);
		Interval i7=new Interval(2,3);
		Interval i8=new Interval(5,6);
		Interval i9=new Interval(0,0);
		Interval i10=new Interval(5,6);
		List<Interval> intervals =new ArrayList<>();
		intervals.add(i1);
		intervals.add(i2);
		intervals.add(i3);
		intervals.add(i4);
		intervals.add(i5);
		intervals.add(i6);
		intervals.add(i7);
		intervals.add(i8);
		intervals.add(i9);
		intervals.add(i10);
		System.out.println(merge(intervals));
	}
	public static List<Interval> merge(List<Interval> intervals) {
		
		  List<Interval> list = new ArrayList<>();
	        for( Interval iter : intervals) {
	            int i = 0, j = list.size() - 1;
	            if(j == -1) {
	                list.add(iter);
	                continue;
	            }
	            while(i <= j && iter.start > list.get(i).end) i++;
	            while(j >= 0 && iter.end < list.get(j).start) j--;
	            if(i > j) {
	                list.add(i, iter);
	            }else {
	                Interval left = list.get(i);
	                left.start = Math.min(left.start, iter.start);
	                left.end = Math.max(list.get(j).end, iter.end);
	                while(i < j) {
	                    list.remove(i+1);
	                    j--;
	                }
	            }
	        }
	        return list;
	}
}
