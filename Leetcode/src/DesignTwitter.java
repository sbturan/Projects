import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Set;

public class DesignTwitter {

	public class Twitter {

		/** Initialize your data structure here. */
		List<Integer> tweets;
		HashMap<Integer, Integer> tweetUser;
		HashMap<Integer, Set<Integer>> follows;

		public Twitter() {
			tweets = new ArrayList<Integer>();
			follows = new HashMap<>();
			tweetUser = new HashMap<>();
		}

		/** Compose a new tweet. */
		public void postTweet(int userId, int tweetId) {
			tweets.add(tweetId);
			tweetUser.put(tweetId, userId);

		}

		/**
		 * Retrieve the 10 most recent tweet ids in the user's news feed. Each
		 * item in the news feed must be posted by users who the user followed
		 * or by the user herself. Tweets must be ordered from most recent to
		 * least recent.
		 */
		public List<Integer> getNewsFeed(int userId) {
			Set<Integer> followsList = follows.get(userId);
			if (followsList == null) {
				followsList = new HashSet<>();
				followsList.add(userId);
			}
			List<Integer> result = new ArrayList<>();
			int count = 10;
			int tweetListCounter = tweets.size() - 1;
			while (tweetListCounter>-1&&count > 0) {
				int currentTweetId = tweets.get(tweetListCounter--);
				Integer twetterUserID = tweetUser.get(currentTweetId);
				if (followsList.contains(twetterUserID) || userId == twetterUserID) {
					result.add(currentTweetId);
					count--;
				}
			}

			return result;
		}

		/**
		 * Follower follows a followee. If the operation is invalid, it should
		 * be a no-op.
		 */
		public void follow(int followerId, int followeeId) {
			if(follows.get(followerId)==null)
				follows.put(followerId, new HashSet<>());
			follows.get(followerId).add(followeeId);
		}

		/**
		 * Follower unfollows a followee. If the operation is invalid, it should
		 * be a no-op.
		 */
		public void unfollow(int followerId, int followeeId) {
			if (follows.get(followerId) != null) {
				follows.get(followerId).remove(followeeId);
			}
		}
	}

	/**
	 * Your Twitter object will be instantiated and called as such: Twitter obj
	 * = new Twitter(); obj.postTweet(userId,tweetId); List<Integer> param_2 =
	 * obj.getNewsFeed(userId); obj.follow(followerId,followeeId);
	 * obj.unfollow(followerId,followeeId);
	 */
}
