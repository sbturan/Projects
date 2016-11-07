import java.util.Stack;

public class SimplifyPath {
	public static void main(String[] args) {
    System.out.println(simplifyPath("/.."));
	}
	public static String simplifyPath(String path) {
      String[] split = path.split("/");
      
      Stack<String> s=new Stack<>();
      for(String st:split){
    	  if(st.length()>0){
    		  if(st.equals("..")&&!s.isEmpty()){
    			  s.pop();
    		  }else if(!st.equals("..")&&!st.equals(".")){
    			  s.push(st);
    		  }
    	  }
      }
      
      String result="";
      while(!s.isEmpty()){
    	  String pop = s.pop();
    	  result="/".concat(pop).concat(result);
      }
      if(result.length()==0) result="/";
      return result;
	}
}
