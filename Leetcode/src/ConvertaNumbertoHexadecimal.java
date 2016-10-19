import java.util.HashMap;
import java.util.Map;

public class ConvertaNumbertoHexadecimal {
	public static void main(String[] args) {
		ConvertaNumbertoHexadecimal c=new ConvertaNumbertoHexadecimal();
		System.out.println(c.toHex(123));
	}
	public String toHex(int num) {
		Map<String, String> map = new HashMap<>();
		map.put("0000", "0");
		map.put("0001", "1");
		map.put("0010", "2");
		map.put("0011", "3");
		map.put("0100", "4");
		map.put("0101", "5");
		map.put("0110", "6");
		map.put("0111", "7");
		map.put("1000", "8");
		map.put("1001", "9");
		map.put("1010", "a");
		map.put("1011", "b");
		map.put("1100", "c");
		map.put("1101", "d");
		map.put("1110", "e");
		map.put("1111", "f");
		if (num == 0)
			return "0";
		String binary = Integer.toBinaryString(num);
		int length = binary.length();
		if (length % 4 != 0) {
			for (int i = 0; i < 4 - (length % 4); i++) {
				binary = "0" + binary;
			}
		}
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < binary.length() - 3; i=i+4) {
			String cur = binary.substring(i, i + 4);
			sb.append(map.get(cur));
		}
      return sb.toString();
	}
}
