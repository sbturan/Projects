import java.util.ArrayList;
import java.util.List;

public class Solution_reorderList {

	public static void main(String[] args) {
		
		
				
		ListNode head=new ListNode(1);
		ListNode head2=new ListNode(2);
		ListNode head3=new ListNode(3);
		head.next=head2;
		head2.next=head3;
		reorderList(head);
	
		
 
		
	
	}
	
    public static void reorderList(ListNode head) {
    	if(head==null) return ;
    
     List<ListNode> list=new ArrayList<ListNode>();
     
      ListNode temp=head;
      while(temp!=null){
    	  list.add(temp);
    	  temp=temp.next;
      }
      
      int size = list.size();
      if(size==1||size==2) return;
	for(int i=0;i<size/2;i++){
    	  
    	  list.get(i).next=list.get(size-1-i);
    	  list.get(size-1-i).next=list.get(i+1);
      }
	
	list.get(size/2+1).next=null;
	 
	
    }
	 
}