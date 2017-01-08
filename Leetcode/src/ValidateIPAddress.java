
public class ValidateIPAddress {
	public static enum ResultType {
		IPv4("IPv4"), IPv6("IPv6"), wrong("Neither");
		String val;

		private ResultType(String val) {
			this.val = val;
		}

		public String getValue() {
			return this.val;
		}

	}

	public static void main(String[] args) {
		ValidateIPAddress v = new ValidateIPAddress();
		System.out.println(v.validIPAddress("0.0.0.0.0"));

	}

	public String validIPAddress(String IP) {
		if (IP.contains("."))
			return checkIPv4(IP);
		return checkIPv6(IP);

	}

	private static String checkIPv4(String IP) {
		if (IP.contains(":") || IP.startsWith(".") || IP.endsWith("."))
			return ResultType.wrong.getValue();
		String[] split = IP.split("\\.");
		if (split.length != 4)
			return ResultType.wrong.getValue();
		for (String s : split) {
			if (!checkIPv4SinglePart(s))
				return ResultType.wrong.getValue();
		}
		return ResultType.IPv4.getValue();
	}

	private static boolean checkIPv4SinglePart(String part) {
		if (part.length() < 1 || part.length() > 3 || part.startsWith("-"))
			return false;
		if (part.length() > 1 && part.charAt(0) == '0')
			return false;
		try {
			Integer intVal = Integer.valueOf(part);
			if (intVal < 0 || intVal > 255)
				return false;
			return true;
		} catch (NumberFormatException e) {
			return false;
		}
	}

	private static String checkIPv6(String IP) {
		if (IP.contains(".") || IP.endsWith(":") || IP.startsWith(":"))
			return ResultType.wrong.getValue();
		String[] split = IP.split(":");
		if (split.length != 8)
			return ResultType.wrong.getValue();
		for (String s : split) {
			if (!checkIPv6SinglePart(s))
				return ResultType.wrong.getValue();
		}
		return ResultType.IPv6.getValue();

	}

	private static boolean checkIPv6SinglePart(String part) {
		if (part.length() < 1 || part.length() > 4 || part.startsWith("-"))
			return false;
		try {
			Long.parseLong(part, 16);
			return true;
		} catch (NumberFormatException ex) {
			return false;
		}
	}
}
