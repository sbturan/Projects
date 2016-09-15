
public class LongestPalindromicSubstring {
	
	private int lo, maxLen;

	public static void main(String[] args) {
		
		String test = "rgczcpratwyqxaszbuwwc" + "adruayhasynuxnakpmsyhxzl" + "nxmdtsqqlmwnbxvmgvllafrpm"
				+ "lfuqpbhjddmhmbcgmlyeypkfpr" + "eddyencsdmgxysctpubvgeedhur" + "vizgqxclhpfrvxggrowaynrtuw"
				+ "vvvwnqlowdihtrdzjffrgoeqivnp" + "rdnpvfjuhycpfydjcpfcnkpyujlji" + "esmuxhtizzvwhvpqylvcirwqsmpptyh"
				+ "cqybstsfgjadicwzycswwmpluvzqd" + "vnhkcofptqrzgjqtbvbdxylrylinspnc"
				+ "rkxclykccbwridpqckstxdjawvziucrsw" + "psfmisqiozworibeycuarcidbljslwbal"
				+ "cemgymnsxfziattdylrulwrybzztoxhevs" + "dnvvljfzzrgcmagshucoalfiuapgzpqgjjg"
				+ "qsmcvtdsvehewrvtkeqwgmatqdpwlayjcxcavjmgpdyklrjcqvxjqbjucfubgmgpkfdxznkhcejscymuildfnuxwmuklntnyycdcscioimenaeohgpbcpogyifcsatfxeslstkjclauqmywacizyapxlgtcchlxkvygzeucwalhvhbwkvbceqajstxzzppcxoanhyfkgwaelsfdeeviqogjpresnoacegfeejyychabkhszcokdxpaqrprwfdahjqkfptwpeykgumyemgkccynxuvbdpjlrbgqtcqulxodurugofuwzudnhgxdrbbxtrvdnlodyhsifvyspejenpdckevzqrexplpcqtwtxlimfrsjumiygqeemhihcxyngsemcolrnlyhqlbqbcestadoxtrdvcgucntjnfavylip";
		LongestPalindromicSubstring l=new LongestPalindromicSubstring();
		System.out.println(l.longestPalindrome(test));
	}
	
	


	public  String  longestPalindrome(String s) {
		int len = s.length();
		if (len < 2)
			return s;
		
	    for (int i = 0; i < len-1; i++) {
	     	extendPalindrome(s, i, i);  //assume odd length, try to extend Palindrome as possible
	     	extendPalindrome(s, i, i+1); //assume even length.
	    }
	    return s.substring(lo, lo + maxLen);
	}

	private void extendPalindrome(String s, int j, int k) {
		while (j >= 0 && k < s.length() && s.charAt(j) == s.charAt(k)) {
			j--;
			k++;
		}
		if (maxLen < k - j - 1) {
			lo = j + 1;
			maxLen = k - j - 1;
		}
	}
	
}
