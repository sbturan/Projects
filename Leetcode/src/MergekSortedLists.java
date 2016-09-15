import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

public class MergekSortedLists {
	public static void main(String[] args) {
//		TreeSet<Integer> set=new  TreeSet<>();
//		set.add(5);
//		set.add(4);
//		set.add(3);
//		set.add(7);
//		Iterator<Integer> iterator = set.iterator();
//		while(iterator.hasNext()){
//			System.out.println(iterator.next());
//		}
			
		
		
		ListNode[] lists=new ListNode[5]; 
		ListNode listNode1=new ListNode(1);
		ListNode listNode2=new ListNode(2);
		ListNode listNode3=new ListNode(3);
		ListNode listNode4=new ListNode(4);
		ListNode listNode5=new ListNode(5);
		lists[0]=listNode1;
		lists[1]=listNode2;
		lists[2]=listNode3;
		lists[3]=listNode4;
		lists[4]=listNode5;
		System.out.println(mergeKLists(lists).val);
	}

	public static ListNode mergeKLists(ListNode[] lists) {

		if (lists == null || lists.length == 0) {
			return null;
		}
		List<Integer> set=new  ArrayList<>();
		for(ListNode ls:lists){
			ListNode current=ls;
			while(current!=null){
				set.add(current.val);
				current=current.next;
			}
		}
		Collections.sort(set);
		Iterator<Integer> iterator = set.iterator();
		ListNode current= new ListNode(iterator.next());
		ListNode result= current;
		while(iterator.hasNext()){
			ListNode cc=new ListNode(iterator.next());
			current.next=cc;
			current=current.next;
		}
		
		
		return result;
		
		

	}


}
