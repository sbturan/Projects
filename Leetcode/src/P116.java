import java.util.LinkedList;
import java.util.Queue;

public class P116 {
	public void connect(TreeLinkNode root) {
      
		Queue<TreeLinkNode> q=new LinkedList<>();
		if(root==null) return;
		q.add(root);
		int count=1;
		while(!q.isEmpty()){
            int currentCount=0;
            TreeLinkNode before=q.peek();
            TreeLinkNode poll=null;
            while(count>0){
            	 poll= q.poll();
                	before.next=poll;
                if(poll.left!=null){
                	q.add(poll.left);
                	 currentCount++;
                	q.add(poll.right);
                	 currentCount++;
                }
                count--;
               
                before=poll;
            }
            count=currentCount;
           poll.next=null;
		}
	}
}
