public class BullsandCows {
	public String getHint(String secret, String guess) {
      
		int[] map=new int[26];
		char[] s = secret.toCharArray();
		char[] g = guess.toCharArray();
		int bulls=0;
		int cows=0;
		for(int i=0;i<s.length;i++){
			if(s[i]==g[i]){
				bulls++;
			}else
			map[s[i]-'0']++;
		}
		for(int i=0;i<g.length;i++){
			if(s[i]!=g[i]){
				
				if(map[g[i]-'0']>0){
					cows++;
					map[g[i]-'0']--;
				}
			}
		}
		
		return bulls+"A"+cows+"B";
	}
}
