using System;
using System.Collections.Generic;

namespace UnityPluginPlayGames.Common {
	
	public interface IPlayGamesService {

		/// <summary>
		/// Call on user sign in failed
		/// </summary>
		event Action<string> OnSignInFailed;

		/// <summary>
		/// Call on user sign in successed
		/// </summary>
		event Action OnSignInSucceeded;

		/// <summary>
		/// Call on user sign in is require
		/// </summary>
		event Action OnRequireSignIn;

		/// <summary>
		// Call this on first scene entered
		/// </summary>
		void Setup();

		/// <summary>
		/// Determines whether user is signed in.
		/// </summary>
		/// <returns><c>true</c> if this instance is signed in; otherwise, <c>false</c>.</returns>
		bool IsSignedIn();

		/// <summary>
		// Begin Sign in
		/// </summary>
		void BeginUserInitiatedSignIn();

		/// <summary>
		/// Sign user out
		/// </summary>
		void SignOut();

		/// <summary>
		/// Submits the score to leaderboard
		/// </summary>
		/// <param name="leaderboardId">Leaderboard identifier.</param>
		/// <param name="score">Score.</param>
		void SubmitScore(string leaderboardId, long score);

		/// <summary>
		/// Shows the leaderboard.
		/// </summary>
		/// <param name="leaderboardId">Leaderboard identifier.</param>
		void ShowLeaderboard(string leaderboardId);

		/// <summary>
		/// Unlocks the achievement.
		/// </summary>
		/// <param name="achievementId">Achievement identifier.</param>
		void UnlockAchievement(string achievementId);

		/// <summary>
		/// Unlocks the achievement with steps
		/// </summary>
		/// <param name="achievementId">Achievement identifier.</param>
		/// <param name="numSteps">Number steps.</param>
		void IncrementAchievement(string achievementId, int numSteps);

		/// <summary>
		/// Shows the achievements.
		/// </summary>
		void ShowAchievements();
	}
}