
public class MinimumGeneticMutation {
	public static void main(String[] args) {
		/*
		 * "AACCGGTT"
"AACCGGTA"
["AACCGGTA"]*/
		MinimumGeneticMutation m=new MinimumGeneticMutation();
		System.out.println(m.minMutation("AACCGGTT", "AACCGGTA", new String[]{"AACCGGTA"}));
	}
	public int minMutation(String start, String end, String[] bank) {
        
		int min=Integer.MAX_VALUE;
		if(start.equals(end)) return 0;
		
		for(int i=0;i<bank.length;i++){
			String s=bank[i];
			if(s.length()!=0&&checkForNextStep(s, start)){
				int step=1;
				bank[i]="";
				int minMutation = minMutation(s, end, bank);
				bank[i]=s;
				if(minMutation!=-1){
				step+=minMutation;
				min=Math.min(min, step);
				}
			}
		}
		if(min==Integer.MAX_VALUE) return -1;
		return min;
	}
	private boolean checkForNextStep(String s1,String s2){
		int dif=0;
		for(int i=0;i<s1.length()&&dif<2;i++){
			if(s1.charAt(i)!=s2.charAt(i)) dif++;
		}
		
		return dif==1;
	}
}
