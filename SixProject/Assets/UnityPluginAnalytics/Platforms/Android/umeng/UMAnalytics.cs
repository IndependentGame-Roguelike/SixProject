
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginAnalytics.Common;


namespace UnityPluginAnalytics.Android {

    public class UMAnalytics: IUMAnalytics {

        private AndroidJavaObject activity;
        private AndroidJavaObject uMAnalyticsJavaObject;

        public UMAnalytics() {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.uMAnalyticsJavaObject = new AndroidJavaObject("com.handarui.unity.plugin.analytics.umeng.UMAnalytics");
        }

 
        public void Init(string appKey, string channelId) {
            this.uMAnalyticsJavaObject.Call("init", activity, appKey, channelId);
        }

        public void SetDebugMode(bool debugMode) {
            this.uMAnalyticsJavaObject.Call("setDebugMode", debugMode);
        }

        public bool IsDebugMode() {
            return this.uMAnalyticsJavaObject.Call<bool>("isDebugMode");
        }

        public void OnResume() {
            this.uMAnalyticsJavaObject.Call("onResume", activity);
        }

        public void OnPause() {
            this.uMAnalyticsJavaObject.Call("onPause", activity);
        }

        public void StartLevel(string level) {
            this.uMAnalyticsJavaObject.Call("startLevel", level);
        }

        public void FailLevel(string level) {
            this.uMAnalyticsJavaObject.Call("failLevel", level);
        }

        public void FinishLevel(string level) {
            this.uMAnalyticsJavaObject.Call("finishLevel", level);
        }

        public void Pay(double money, string item, int number, double price, int source) {
            this.uMAnalyticsJavaObject.Call("pay", money, item, number, price, source);
        }

        public void Use(string item, int number, double price) {
            this.uMAnalyticsJavaObject.Call("use", item, number, price);
        }

        public void Bonus(string item, int num, double price, int trigger) {
            this.uMAnalyticsJavaObject.Call("bonus", item, num, price, trigger);
        }

        public void OnProfileSignIn(string provider, string id) {
            this.uMAnalyticsJavaObject.Call("onProfileSignIn", provider, id);
        }

        public void SetPlayerLevel(int level) {
            this.uMAnalyticsJavaObject.Call("setPlayerLevel", level);
        }

        public void OnEvent(string eventId) {
            this.uMAnalyticsJavaObject.Call("onEvent", activity, eventId);
        }

        public void OnEvent(string eventId, Dictionary<string, string> map) {
            this.uMAnalyticsJavaObject.Call("onEvent", eventId, Utils.CreateJavaMap(map));
        }

        public void OnEventValue(string id, Dictionary<string, string> map, int duration) {
            this.uMAnalyticsJavaObject.Call("onEventValue", id, Utils.CreateJavaMap(map), duration);
        }

        public void OnEvent(List<string> keyPath, int value, string label) {
            this.uMAnalyticsJavaObject.Call("onEvent", activity, Utils.CreateJavaList(keyPath), value, label);
        }
    }
}