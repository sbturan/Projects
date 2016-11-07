
public class RectangleArea {
	public static void main(String[] args) {
		/*-3,-3,3,-1,-2,-2,2,2*/
		System.out.println(computeArea(-3,-3,3,-1,-2,-2,2,2));
	}
	public static int computeArea(int A, int B, int C, int D, int E, int F, int G, int H) {
      int first=(C-A)*(D-B);
      int second=(G-E)*(H-F);
      int crossX=0,crossY=0;
      
      if(E<=A&&G>=C){
    	  crossX=C-A;
      }else if(E>=A&&G<=C){
    	  crossX=G-E;
      }
      else if(C>E&&A<E){
    	  crossX=C-E;
      }else if(C>G&&A<G){
    	  crossX=G-A;
      }
      
      if(F<=B&&H>=D){
    	  crossY=D-B;
      }else if(F>=B&&H<=D){
    	  crossY=H-F;
      }
      else if(D>F&&B<F){
    	  crossY=D-F;
      }else if(D>H&&B<H){
    	  crossY=H-B;
      }
      
      return first+second-(crossX*crossY);


	}
}
