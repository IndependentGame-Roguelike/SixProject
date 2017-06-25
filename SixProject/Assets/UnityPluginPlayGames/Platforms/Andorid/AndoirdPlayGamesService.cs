using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginPlayGames.Common;

namespace UnityPluginPlayGames.Android {

	public class AndoirdPlayGamesService : AndroidJavaProxy, IPlayGamesService {

		public event Action<string> OnSignInFailed;

		public event Action OnSignInSucceeded;

		public event Action OnRequireSignIn;

		private AndroidJavaObject unityActivity;

		public AndoirdPlayGamesService(): base("com.handarui.unity.plugin.playgames.SignInListener") {
			AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            this.unityActivity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
			unityActivity.Call("setPlayGamesListener", this);
            Loom.Loom.Initialize();
		}

        void IPlayGamesService.Setup() {
            this.unityActivity.Call("setup");
        }

        bool IPlayGamesService.IsSignedIn()
        {
            return this.unityActivity.Call<bool>("isSignedIn");
        }

        void IPlayGamesService.BeginUserInitiatedSignIn()
        {
            this.unityActivity.Call("beginUserInitiatedSignIn");
        }

        void IPlayGamesService.SignOut()
        {
            this.unityActivity.Call("signOut");
        }

        void IPlayGamesService.SubmitScore(string leaderboardId, long score)
        {
            this.unityActivity.Call("submitScore", leaderboardId, score);
        }

        void IPlayGamesService.ShowLeaderboard(string leaderboardId)
        {
            this.unityActivity.Call("showLeaderboard", leaderboardId);
        }

        void IPlayGamesService.UnlockAchievement(string achievementId)
        {
            this.unityActivity.Call("unlockAchievement", achievementId);
        }

        void IPlayGamesService.IncrementAchievement(string achievementId, int numSteps)
        {
            this.unityActivity.Call("incrementAchievement", achievementId, numSteps);
        }

        void IPlayGamesService.ShowAchievements()
        {
            this.unityActivity.Call("showAchievements");
        }


		// proxy methods for com.handarui.unity.plugin.playgames.SignInListener
		public void onSignInFailed(string reason) {
            Loom.Loom.QueueOnMainThread(() => {
                this.OnSignInFailed(reason);
            });
		}

		public void onSignInSucceeded() {
            Loom.Loom.QueueOnMainThread(this.OnSignInSucceeded);
		}

		public void onRequireSignIn() {
            Loom.Loom.QueueOnMainThread(this.OnRequireSignIn);
		}
    }

}
