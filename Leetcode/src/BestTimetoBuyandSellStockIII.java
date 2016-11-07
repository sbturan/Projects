
public class BestTimetoBuyandSellStockIII {
	public static void main(String[] args) {
		BestTimetoBuyandSellStockIII b = new BestTimetoBuyandSellStockIII();
		System.out.println(b.maxProfit(new int[] {6,1,3,2,4,7}));
	}

	public int maxProfit(int[] prices) {
		   int n = prices.length;
	        if (n<2) return 0;
	        int[] left = new int[n];
	        int[] right = new int [n];
	        int min = prices[0];
	        for (int i=1; i<n; i++) {
	            min = Math.min(min, prices[i]);
	            left[i] = Math.max(left[i-1], prices[i]-min);
	        }
	        int max = prices[n-1];
	        for (int i=n-2; i>=0; i--) {
	            max = Math.max(max, prices[i]);
	            right[i] = Math.max(right[i+1], max-prices[i]);
	        }
	        int result = 0;
	        for (int i=0; i<n; i++) result = Math.max(result, left[i]+right[i]);
	        return result;
	}
}
