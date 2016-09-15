import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Solution_JumpGameII {

	public static void main(String[] args) {

//		int[] nums = new int[] { 2, 3, 1, 1, 4 };
		Solution_JumpGameII s = new Solution_JumpGameII();
		List<Integer> numbers = s.readFile();
		int[] nums = new int[numbers.size()];
		for(int i=0;i<numbers.size();i++)
			nums[i]=numbers.get(i);
		Long ft=System.currentTimeMillis();
		System.out.println(s.jump(nums));
		System.out.println("time="+ (System.currentTimeMillis()-ft));

	}

	 public int jump(int[] nums) {
	        if (nums==null||nums.length==0){
	            return -1;
	        }
	        
	        if (nums.length==1){
	            return 0;
	        }
	        
	        int minStep=0;
	        
	        int start=0;
	        // current longest distance the jump can reach
	        int end=nums[start];
	        
	        // if current longest distance plus current postion passed the length of array
	        // then return current minStep + 1;
	        if (start+end>=nums.length-1){
	            return minStep+1;
	        }
	        
	        while(end<nums.length-1){
	            minStep++;
	            
	            // record farest position can be reached by jump from position within current farest position
	            int max=0;
	            
	            for (int i=start; i<=end; i++){
	                int current=i+nums[i];
	                // pass the total length, return minStep+1, 
	                
	                if (current>=nums.length-1){
	                    return minStep+1;
	                }
	                
	                max=Math.max(max, current);
	            }
	            // update start position(items in array are not negative, so end+1 is exist)
	            start=end+1;
	            // update the most far position can reached for next jump
	            end=max;
	        }

	        return minStep;
	    }
	
	
//	public int jump(int[] nums) {
//		numsG = nums;
//		int length = numsG.length;
//		if (length == 0 || length == 1)
//			return length;
//		if (length == 2) {
//			if (nums[0] == 1)
//				return 2;
//			else
//				return 1;
//		}
//		minWays = new int[length];
//		minWays[length - 2] = 1;
//		for (int i = length - 3; i > -1; i--) {
//			minWays[i] = findMinWay(i);
//		}
//
//		return minWays[0];
//	}
//
//	private static int[] numsG;
//	private static int[] minWays;
//
//	private static int findMinWay(int index) {
//		int value = numsG[index];
//		if (index + value >= numsG.length - 1) {
//			return 1;
//		}
//
//		int min = minWays[index + 1];
//		for (int i = 2; i <= value; i++) { 
//             
//			if (minWays[index + i] < min)
//				min = minWays[index + i];
//			
//			if(min==1) break;
//		}
//
//		return min + 1;
//	}

	private List<Integer> readFile() {
		List<Integer> result = new ArrayList<>();
		try {
			// FileInputStream fs=new
			// FileInputStream("C:/Users/seckin/Desktop/jump.txt");
			FileReader rd = new FileReader("C:/Users/seckin/Desktop/jump.txt");
			BufferedReader bf = new BufferedReader(rd);
			String line = bf.readLine();

			while (line != null&&!line.equals("--")) {
				String[] numbers = line.split(",");
				for (String number : numbers) {
					result.add(Integer.valueOf(number));
				}
				line=bf.readLine();
			}
          bf.close();
          rd.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			// TODO: handle exception
		}

		return result;
	}

}
