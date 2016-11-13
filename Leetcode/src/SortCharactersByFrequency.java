import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class SortCharactersByFrequency {
	public static void main(String[] args) throws IOException {
		SortCharactersByFrequency s = new SortCharactersByFrequency();
		BufferedReader br=new BufferedReader(new FileReader("word.txt"));
		String st=br.readLine();
		br.close();
		String frequencySort2 = s.frequencySort2(st);
//		System.out.println(frequencySort);
//		System.out.println(frequencySort2);
	}

	public String frequencySort2(String s) {
		long currentTimeMillis = System.currentTimeMillis();
		char[] charArray = s.toCharArray();
		int[] counts = new int[128];
		for (Character c : charArray) {
			counts[(int) c] += 1;
		}

		int curCharSeq = 1;
		int length = s.length();
		int index = length - 1;
		char[] result = new char[length];
		while (index > -1 && curCharSeq < length) {
			for (int i = 0; i < counts.length; i++) {
				if (counts[i] == curCharSeq) {
					for (int j = 0; j < curCharSeq; j++)
						result[index--] = (char) (i);
				}
			}
			curCharSeq++;
		}
		System.out.println("2= "+(System.currentTimeMillis()-currentTimeMillis));
		return new String(result);
	}

	
}
