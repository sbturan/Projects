import java.util.ArrayList;
import java.util.List;

public class DataStreamAsDisjointIntervals {

	public class SummaryRanges {

	    /** Initialize your data structure here. */
		List<Interval> intervals;
	    public SummaryRanges() {
            intervals=new ArrayList<>();	        
	    }
	    
	    public void addNum(int val) {
	        Interval left=null;
	        Interval right=null;
	        int index=0;
	        for(Interval i:intervals){
	        	if(i.start<=val&&i.end>=val) return;
	        	if(i.start==val+1) right=i;
	        	if(i.end+1==val) left=i;
	        	if(i.start<val){
	        		index++;
	        	}
	        }
	        if(left!=null&&right!=null){
	        	left.end=right.end;
	        	intervals.remove(right);
	        	return;
	        }
	        if(left!=null){
	        	left.end=val;
	        	return;
	        }
	        if(right!=null){
	        	right.start=val;
	        	return;
	        }
	        Interval interval=new Interval(val, val);
	        intervals.add(index,interval);
	    }
	    
	    public List<Interval> getIntervals() {
	        return  intervals;
	    }
	}

}
