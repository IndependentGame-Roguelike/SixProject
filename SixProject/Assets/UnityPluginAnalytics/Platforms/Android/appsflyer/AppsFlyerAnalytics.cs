using System;
using UnityEngine;
using UnityPluginAnalytics.Common;


namespace UnityPluginAnalytics.Android {
    public class AppsFlyerAnalytics : IAppsFlyerAnalytics {

        private AndroidJavaObject activity;
        private AndroidJavaObject appsFlyerAnalyticsJavaObject;

        public AppsFlyerAnalytics() {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.appsFlyerAnalyticsJavaObject = new AndroidJavaObject("com.handarui.unity.plugin.analytics.appsflyer.AppsFlyerAnalytics");
        }

        public void Init(string devKey) {
            this.appsFlyerAnalyticsJavaObject.Call("init", activity, devKey); 
        }
        
    }
}