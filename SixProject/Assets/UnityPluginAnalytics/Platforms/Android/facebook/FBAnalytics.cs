
using System;
using UnityEngine;
using UnityPluginAnalytics.Common;


namespace UnityPluginAnalytics.Android {

    public class FBAnalytics : IFBAnalytics {

        private AndroidJavaObject activity;
        private AndroidJavaObject fBAnalyticsJavaObject;

        public FBAnalytics() {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.fBAnalyticsJavaObject = new AndroidJavaObject("com.handarui.unity.plugin.analytics.facebook.FBAnalytics");
        }

        public void Init(string appId) {
            this.fBAnalyticsJavaObject.Call("init", appId);
        }

        public void OnResume() {
            this.fBAnalyticsJavaObject.Call("onResume", activity);
        }

        public void OnPause() {
            this.fBAnalyticsJavaObject.Call("onPause", activity);
        }
    }
}