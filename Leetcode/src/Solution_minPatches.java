public class Solution_minPatches {

	public static void main(String[] args) {
		Solution_minPatches s = new Solution_minPatches();

		int[] nums=new int[]{1,5,10};
		int n=20;
//		int[] nums = new int[] {1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,3,3,3,3,3,3,4,4,4,4,4,4,4,4,4,5,5,5,5,5,5,6,6,6,6,6,6,6,6,7,7,7,7,7,7,7,7,8,8,8,8,8,9,9,9,9,9,9,9,9,10,10,10,10,10,10,10,11,12,12,12,12,12,13,13,13,13,13,13,13,13,14,14,14,14,15,16,16,16,17,17,17,17,17,17,17,17,18,18,18,18,18,18,19,19,19,19,19,19,19,19,19,20,20,20,20,21,21,21,21,21,21,22,22,22,22,22,22,22,22,23,23,23,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,25,25,26,26,26,26,26,27,27,27,27,27,27,27,27,28,28,28,28,28,28,28,28,29,29,29,30,30,30,30,30,31,31,31,31,31,31,32,32,32,33,33,33,33,33,33,34,34,34,34,34,34,34,35,35,35,35,35,35,36,36,37,37,37,37,38,38,38,38,39,39,39,39,39,39,40,40,40,40,40,40,40,40,41,41,42,42,42,43,43,43,43,43,43,43,43,44,44,44,44,44,44,44,44,44,45,45,45,46,46,46,46,46,47,47,47,47,47,47,47,47,47,47,48,48,48,48,48,48,48,49,49,49,49,49,49,49,49,50,50,50,50,50,50,50,50,50,50,51,51,51,51,51,51,51,51,51,51,52,52,52,52,53,53,53,53,53,54,54,54,54,54,54,55,55,55,55,55,55,56,56,56,56,57,57,57,57,57,57,57,57,58,58,58,58,58,59,59,59,59,59,59,59,60,60,60,60,60,61,61,61,61,61,62,62,62,62,62,62,63,63,63,63,64,65,65,65,65,65,65,65,66,66,66,66,66,66,66,67,67,67,67,68,68,68,68,69,69,69,69,69,69,69,70,71,71,71,71,71,71,71,71,72,72,72,72,72,72,72,72,73,73,73,73,73,73,74,74,74,74,74,74,74,75,75,75,75,75,75,75,75,75,76,76,76,76,76,76,77,77,77,77,77,77,78,78,78,78,78,78,78,78,79,79,79,79,79,80,80,80,81,81,81,81,81,81,82,82,82,82,82,82,82,82,83,83,83,83,83,84,84,84,84,84,84,85,85,85,85,85,86,86,86,86,86,87,87,87,87,87,87,88,88,88,88,88,88,89,89,89,89,89,89,89,89,89,89,89,90,90,90,90,90,90,91,91,91,91,91,91,91,92,92,92,92,92,93,93,93,93,93,93,93,94,94,95,95,95,95,95,95,95,96,96,96,96,96,97,97,97,97,97,97,97,97,97,97,98,98,98,98,98,98,98,99,99,99,99,99,99,100,100,100,100,100};
//				int n=91863;
//		int[] nums = new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4,
//				4, 4, 4, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9,
//				9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 11, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14,
//				14, 15, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19,
//				19, 19, 20, 20, 20, 20, 21, 21, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 24, 24, 24,
//				24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27,
//				27, 28, 28, 28, 28, 28, 28, 28, 28, 29, 29, 29, 30, 30, 30, 30, 30, 31, 31, 31, 31, 31, 31, 32, 32, 32,
//				33, 33, 33, 33, 33, 33, 34, 34, 34, 34, 34, 34, 34, 35, 35, 35, 35, 35, 35, 36, 36, 37, 37, 37, 37, 38,
//				38, 38, 38, 39, 39, 39, 39, 39, 39, 40, 40, 40, 40, 40, 40, 40, 40, 41, 41, 42, 42, 42, 43, 43, 43, 43,
//				43, 43, 43, 43, 44, 44, 44, 44, 44, 44, 44, 44, 44, 45, 45, 45, 46, 46, 46, 46, 46, 47, 47, 47, 47, 47,
//				47, 47, 47, 47, 47, 48, 48, 48, 48, 48, 48, 48, 49, 49, 49, 49, 49, 49, 49, 49, 50, 50, 50, 50, 50, 50,
//				50, 50, 50, 50, 51, 51, 51, 51, 51, 51, 51, 51, 51, 51, 52, 52, 52, 52, 53, 53, 53, 53, 53, 54, 54, 54,
//				54, 54, 54, 55, 55, 55, 55, 55, 55, 56, 56, 56, 56, 57, 57, 57, 57, 57, 57, 57, 57, 58, 58, 58, 58, 58,
//				59, 59, 59, 59, 59, 59, 59, 60, 60, 60, 60, 60, 61, 61, 61, 61, 61, 62, 62, 62, 62, 62, 62, 63, 63, 63,
//				63, 64, 65, 65, 65, 65, 65, 65, 65, 66, 66, 66, 66, 66, 66, 66, 67, 67, 67, 67, 68, 68, 68, 68, 69, 69,
//				69, 69, 69, 69, 69, 70, 71, 71, 71, 71, 71, 71, 71, 71, 72, 72, 72, 72, 72, 72, 72, 72, 73, 73, 73, 73,
//				73, 73, 74, 74, 74, 74, 74, 74, 74, 75, 75, 75, 75, 75, 75, 75, 75, 75, 76, 76, 76, 76, 76, 76, 77, 77,
//				77, 77, 77, 77, 78, 78, 78, 78, 78, 78, 78, 78, 79, 79, 79, 79, 79, 80, 80, 80, 81, 81, 81, 81, 81, 81,
//				82, 82, 82, 82, 82, 82, 82, 82, 83, 83, 83, 83, 83, 84, 84, 84, 84, 84, 84, 85, 85, 85, 85, 85, 86, 86,
//				86, 86, 86, 87, 87, 87, 87, 87, 87, 88, 88, 88, 88, 88, 88, 89, 89, 89, 89, 89, 89, 89, 89, 89, 89, 89,
//				90, 90, 90, 90, 90, 90, 91, 91, 91, 91, 91, 91, 91, 92, 92, 92, 92, 92, 93, 93, 93, 93, 93, 93, 93, 94,
//				94, 95, 95, 95, 95, 95, 95, 95, 96, 96, 96, 96, 96, 97, 97, 97, 97, 97, 97, 97, 97, 97, 97, 98, 98, 98,
//				98, 98, 98, 98, 99, 99, 99, 99, 99, 99, 100, 100, 100, 100, 100 };
//		int n = 91863;
		// int[] nums = new int[] { 15, 28, 47, 56, 62, 66, 90, 91, 102, 102,
		// 120, 137, 152, 159, 165, 169, 177, 179, 202,
		// 204, 215, 217, 220, 235, 237, 248, 248, 254, 256, 262, 294, 296, 298,
		// 303, 311, 311, 313, 314, 322, 328,
		// 335, 338, 350, 354, 364, 368, 375, 383, 390, 392, 396, 399, 432, 433,
		// 452, 489, 490, 514, 516, 520, 540,
		// 545, 560, 561, 581, 587, 593, 636, 672, 679, 679, 688, 704, 707, 729,
		// 731, 732, 755, 757, 773, 803, 817,
		// 837, 843, 848, 849, 862, 882, 890, 900, 910, 912, 913, 916, 930, 947,
		// 964, 966, 980, 982 };
		// int n = 325013;
//		 int[] nums = new int[] { 2, 3, 3, 4, 6, 8, 8, 10, 10, 10, 12, 13, 13,
//		 14, 15, 15, 16, 17, 19, 20, 20, 21, 21,
//		 21, 23, 23, 24, 25, 26, 27, 27, 28, 28, 29, 29, 30, 30, 31, 31, 32,
//		 32, 32, 36, 36, 38, 41, 41, 41, 43,
//		 44, 46, 46, 46, 48, 48, 49, 50, 51, 51, 52, 52, 53, 54, 55, 56, 56,
//		 58, 58, 58, 59, 60, 60, 60, 61, 63,
//		 63, 66, 66, 70, 70, 73, 74, 74, 75, 78, 80, 81, 83, 85, 87, 87, 89,
//		 89, 89, 90, 90, 92, 92, 96, 98 };
//		
//		 int n = 60844;
		System.out.println(s.minPatches(nums, n));
	}

	public int minPatches(int[] nums, int n) {
		
		int k = nums.length, ans = 0, i = 0;
	    long sum = 0;
	    while (sum < n) {
	        if (i < k && nums[i] <= sum + 1)
	            sum += nums[i++];
	        else {
	            sum += sum + 1;
	            ans++;
	        }
	    }
	    return ans;
	}

}
