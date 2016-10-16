import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class TextJustification {
	public static void main(String[] args) {
		TextJustification t=new TextJustification();
		List<String> fullJustify = t.fullJustify(
				new String[]{"a"}, 1);
		for(String s:fullJustify){
			System.out.println(s);
		}
	}
	public List<String> fullJustify(String[] words, int maxWidth) {
		
		// Create an auxiliary array of spaces so we can easily call
        // StringBuilder.append(char[], offset, len);
        char[] spaceStrs = new char[maxWidth];
        Arrays.fill(spaceStrs, ' ');

        List<String> just = new ArrayList<>();
        StringBuilder sb = new StringBuilder();
        int i = 0;
        while (i < words.length) {

            // Figure out how many words can fit in the current line
            int wordsLen = 0, j = i, spaces = 0;
            while (wordsLen + spaces <= maxWidth && j < words.length) {
                if (j > i) {
                    spaces++;
                }
                wordsLen += words[j++].length();
            }
            
            // Remove the last word if we went over
            if (wordsLen + spaces > maxWidth) {
                wordsLen -= words[--j].length();
            }

            int nWords = j - i;
            int totalSpaces = maxWidth - wordsLen;

            sb.setLength(0);
            if (nWords == 1) {  // Handle the single word case
                sb.append(words[i++]);
                sb.append(spaceStrs, 0, totalSpaces);
            } else if (j == words.length) {  // Handle the last line case
                for ( ; i < j - 1; i++) {
                    sb.append(words[i]);
                    sb.append(' ');
                }
                // Handle the last word outside the loop otherwise we may
                // end up with an extra space, if the last word ends at maxWidth
                sb.append(words[i++]);
                sb.append(spaceStrs, 0, maxWidth - sb.length());
            } else {
                // Evenly distribute spaces among the space slots
                // and give the extras to the first 'totalSpaces % (nWords - 1) slots
                int avgSpaces = totalSpaces / (nWords - 1);
                int extras = totalSpaces % (nWords - 1);
                
                for ( ; i < j - 1; i++) {
                    sb.append(words[i]);
                    sb.append(spaceStrs, 0, avgSpaces + ((extras-- > 0) ? 1 : 0));
                }
                sb.append(words[i++]);
            }

            just.add(sb.toString());
        }

        return just;
	}
}
