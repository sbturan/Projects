public class FindMedianfromDataStream {
 	public class MedianFinder {
      
 		ListNode head;
 		int size=0;
		public void addNum(int num) {
			size++;
            if(head==null){
            	head=new ListNode(num);
            }else{
            	ListNode cur=head;
            	ListNode before=null;
            	while(cur!=null&&cur.val<num){
            		before=cur;
            		cur=cur.next;
            	}
            	ListNode nw=new ListNode(num);
            	if(before==null){
            		nw.next=head;
            		head=nw;
            	}
            	else{
                  before.next=nw;
                  nw.next=cur;
            	}
            	
            }
            
		}

		// Returns the median of current data stream
		public double findMedian() {
              int end=size/2;
              ListNode res=head;
              ListNode bef=null;
			while(end>0){
				bef=res;
				res=res.next;
				end--;
			}
			
			if(size%2==1){
            	 return res.val;
             }
			return ((double)bef.val+(double)res.val)/2;
             
		}
	};
}
