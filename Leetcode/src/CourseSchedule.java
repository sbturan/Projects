import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class CourseSchedule {
	public static void main(String[] args) {
		CourseSchedule cs = new CourseSchedule();
		long currentTimeMillis = System.currentTimeMillis();
		System.out.println(cs.canFinish(2, new int[][] { { 0, 1 } }));
		System.out.println(System.currentTimeMillis() - currentTimeMillis);

	}

	public boolean canFinish(int numCourses, int[][] prerequisites) {
		HashMap<Integer, List<Integer>> preList = new HashMap<>();
		for (int[] a : prerequisites) {
			if (preList.get(a[0]) == null)
				preList.put(a[0], new ArrayList<>());
			preList.get(a[0]).add(a[1]);
		}
		int[] dp = new int[numCourses];
		boolean result = true;
		int i = 0;
		while (result && i < numCourses) {
			result = canFinishACourse(i, preList, dp);
			i++;
		}

		return result;

	}

	private boolean canFinishACourse(int courseNumber, HashMap<Integer, List<Integer>> preList, int[] dp) {

		if (dp[courseNumber] == 1) {//
			return true;
		}
		if (dp[courseNumber] == -2)
			return false;
		dp[courseNumber] = -2;
		List<Integer> list = preList.get(courseNumber);

		int i = 0;
		boolean result = true;
		if (list != null)
			while (result && i < list.size()) {
				result = canFinishACourse(list.get(i++), preList, dp);
			}

		if (result) {
			dp[courseNumber] = 1;
		}

		return result;

	}
}
