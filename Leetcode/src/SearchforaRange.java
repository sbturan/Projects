
public class SearchforaRange {

	public static void main(String[] args) {
	
		int[] searchRange = searchRange(new int[]{4}, 4);
		for(int i=0;i<searchRange.length;i++){
			System.out.println(searchRange[i]);
		}
}
	
public static int[] searchRange(int[] nums, int target) {
        
        int first=0;
        int last=nums.length-1;
        if(target<nums[0]||target>nums[last]) return new int[]{-1,-1};
        
        int findedFirstIndex=0;
        int findCount=0;
        while(first<=last){
            if(target==nums[(first+last)/2]){
                findCount++;
                int index=(first+last)/2-1;
                while(index>=0&&target==nums[index]){
                    findCount++;
                    index--;
                }
                
                findedFirstIndex=index+1;
                  index=(first+last)/2+1;
                 while(index<nums.length&&target==nums[index]){
                    findCount++;
                    index++;
                }
                
                break;
                
            }
            else if(target<nums[(first+last)/2]){
                last=(first+last)/2-1;
            }else {
                first=(first+last)/2+1;
            }
            
        }
        if(findCount==0) return new int[]{-1,-1};
        
        int[] result=new int[2];
        result[0]=findedFirstIndex;
        result[1]=findedFirstIndex+findCount-1;

        return result;
        
    }
}
