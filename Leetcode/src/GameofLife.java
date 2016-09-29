public class GameofLife {
	
	public static void main(String[] args) {
		
		gameOfLife(new int[][]{{1,1}});
	}
	 public static void gameOfLife(int[][] board) {
	        
		 for(int i=0;i<board.length;i++){
			 for(int j=0;j<board[0].length;j++){
				 board[i][j]=2*calculateStatement(board, i, j)+board[i][j];
			 }
		 }
		 
		 for(int i=0;i<board.length;i++){
			 for(int j=0;j<board[0].length;j++){
				board[i][j]=board[i][j]>>1;
			 }
		 }
		 
	  }
	 private static int calculateStatement(int[][] board,int x,int y){
		 int total=0;
		 for(int i=-1;i<2;i++){
			 for(int j=-1;j<2;j++){
				 if(x+i>-1&&x+i<board.length&&y+j>-1&&y+j<board[0].length){
					 total+=board[x+i][y+j]%2;				 }
			 }
		 }
		 total-=board[x][y];
		 if(board[x][y]==1&&total==2) return 1;
		 if(total==3) return 1;
		 return 0;
		 
	 }
}
