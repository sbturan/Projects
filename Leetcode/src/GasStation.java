
public class GasStation {
	public int canCompleteCircuit(int[] gas, int[] cost) {
     
		
		 int length = cost.length;
         int array[] =new int[2*length];
		 for(int i=0;i<length;i++){
			 array[i]=gas[i]-cost[i];
			 array[length+i]=gas[i]-cost[i];
		 }
		 int i=0;
		 while(i<length){
			 int total=0;
			 int j=i;
			 while(j<i+length){
				 total+=array[j++];
				 if(total<0)break;
			 }
			 if(total>=0) return i;
			 i++;
		 }
		 
		 return -1;
		 
            		 
		
	}

}
