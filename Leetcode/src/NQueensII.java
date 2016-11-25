
public class NQueensII {
	public static void main(String[] args) {
		NQueensII a=new NQueensII();
		System.out.println(a.totalNQueens(2));
	}
	public int totalNQueens(int n) {
		result=0;
      int[][] board=new int[n][n];
      helper(0, board);
      return result;
	}
	private static int result;
	private void helper(int column,int[][] board){
		if(column==board.length){
			result++;
			return;
		}
		for(int i=0;i<board.length;i++){
			if(checkAvaliable(board, i, column)){
				board[i][column]=1;
				helper(column+1, board);
				board[i][column]=0;
			}
		}
		
	}
	
	private boolean checkAvaliable(int[][] board,int row,int column){
		for(int i=0;i<board.length;i++){
			for(int j=0;j<column;j++){
				if(board[i][j]==1&&((i==row)||(i-row)==(j-column)||i-row+j-column==0)){
					return false;
				}
			}
		}
		
		return true;
	}
}
