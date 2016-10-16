import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Queue;

public class CloneGraph {
	public UndirectedGraphNode cloneGraph(UndirectedGraphNode node) {
		HashMap<Integer,UndirectedGraphNode> visitedGraphs=new HashMap<>();
		Queue<UndirectedGraphNode> oldsQueue=new LinkedList<>();
		Queue<UndirectedGraphNode> newsQueue=new LinkedList<>();
		if(node==null) return null;
		UndirectedGraphNode result=new UndirectedGraphNode(node.label);
		UndirectedGraphNode temp=result;
		oldsQueue.add(node);
		newsQueue.add(temp);
		visitedGraphs.put(temp.label, temp);
		while(!oldsQueue.isEmpty()){
			UndirectedGraphNode pollOld = oldsQueue.poll();
			UndirectedGraphNode pollNew = newsQueue.poll();
			for(UndirectedGraphNode e:pollOld.neighbors){
				UndirectedGraphNode currentNeighbor=visitedGraphs.get(e.label);
				if(currentNeighbor==null){
					currentNeighbor=new UndirectedGraphNode(e.label);
					visitedGraphs.put(currentNeighbor.label, currentNeighbor);
					oldsQueue.add(e);
					newsQueue.add(currentNeighbor);
				}
				pollNew.neighbors.add(currentNeighbor);
			}
		}
		
		return result;
	}
}

class UndirectedGraphNode {
	int label;
	List<UndirectedGraphNode> neighbors;

	UndirectedGraphNode(int x) {
		label = x;
		neighbors = new ArrayList<UndirectedGraphNode>();
	}
};