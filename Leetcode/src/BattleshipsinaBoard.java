
public class BattleshipsinaBoard {
	public int countBattleships(char[][] board) {
      int row=board.length;
      int column=board[0].length;
      int result=0;
      for(int i=0;i<row;i++){
    	  for(int j=0;j<column;j++){
    		  if(board[i][j]=='X'&&
    			(i==0||board[i-1][j]!='X')&&
    			 (j==0||board[i][j-1]!='X')){
    			  result++;
    		  }
    	  }
      }
      return result;
	}
}
