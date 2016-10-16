import java.util.ArrayList;
import java.util.List;

public class InsertInterval {
	public static void main(String[] args) {
		InsertInterval i=new InsertInterval();
		Interval i1=new Interval(1,5);
		Interval i2=new Interval(6,8);
		Interval i3=new Interval(5, 6);
		
		List<Interval> list=new  ArrayList<>();
		list.add(i1);
		list.add(i2);
		List<Interval> insert = i.insert(list, i3);
		System.out.println();
	}
	public List<Interval> insert(List<Interval> intervals, Interval newInterval) { if(intervals.size()==0){
		intervals.add(newInterval);
		return intervals;
	}


	int leftIndex = 0;
	while (leftIndex < intervals.size() && intervals.get(leftIndex).start < newInterval.start) {
		leftIndex++;
	}
	if(leftIndex==intervals.size()&&intervals.get(leftIndex-1).end<newInterval.start){
		intervals.add(newInterval);
		return intervals;
	}
	int rightIndex=0;
	while(rightIndex<intervals.size()&&intervals.get(rightIndex).end<newInterval.end){
		rightIndex++;
	}
	Interval leftInterval=null;
	Interval rightInterval=null;
	if(leftIndex!=0&&newInterval.start<=intervals.get(leftIndex-1).end){
		leftInterval=intervals.get(leftIndex-1);
	}
	if(rightIndex!=intervals.size()&&newInterval.end>=intervals.get(rightIndex).start){
		rightInterval=intervals.get(rightIndex);
	}
	if(leftInterval!=null&&rightInterval!=null){
		leftInterval.end=rightInterval.end;
		for(int i=leftIndex;i<=rightIndex;i++){
			intervals.remove(leftIndex);
		}
		return intervals;
	}
	if(leftInterval!=null){
		leftInterval.end=newInterval.end;
		for(int i=leftIndex;i<rightIndex;i++){
			intervals.remove(leftIndex);
		}
		return intervals;
	}
	if(rightInterval!=null){
		rightInterval.start=newInterval.start;
		for(int i=leftIndex;i<rightIndex;i++){
			intervals.remove(leftIndex);
		}
		return intervals;
	}
	for(int i=leftIndex;i<rightIndex;i++){
		intervals.remove(leftIndex);
	}
	intervals.add(leftIndex, newInterval);
	return intervals;
}
}
