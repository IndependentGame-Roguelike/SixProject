using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds.Api;
using UnityPluginAds.Common;

namespace UnityPluginAds.Android {

    class UnityAdsVideoClient : AndroidJavaProxy, IAdsVideoClient {
        public event Action<string> OnAdsError;
        public event Action<string, bool> OnAdsFinish;
        public event Action<string> OnAdsReady;
        public event Action<string> OnAdsStart;

        private AndroidJavaObject unityAdsVideo;

        public UnityAdsVideoClient(bool testMode): base("com.handarui.unity.plugin.ads.VideoAdListener") {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.unityAdsVideo = new AndroidJavaObject("com.handarui.unity.plugin.ads.platform.unityads.UnityAdsVideo", activity, this, testMode);
        }

        public void Destroy() {
            this.unityAdsVideo.Call("destroy");
        }

        public void Initialize(string appId) {
            this.unityAdsVideo.Call("initialize", appId);
        }

        public bool IsReady(string placementId = null) {
            return this.unityAdsVideo.Call<bool>("isReady", placementId);
        }

        public void OnPause() {
            this.unityAdsVideo.Call("onPause");
        }

        public void OnResume() {
            this.unityAdsVideo.Call("onResume");
        }

        public void Show(VideoAdRequestConfig config) {
            this.unityAdsVideo.Call("show", Utils.GetVideoAdRequestConfigJavaObject(config));
        }

        public void onAdsReady(string placementId) {
            this.OnAdsReady(placementId);
        }

        public void onAdsStart(string placementId) {
            this.OnAdsStart(placementId);
        }

        public void onAdsFinish(string placementId, bool complete) {
            this.OnAdsFinish(placementId, complete);
        }

        public void onAdsError(string message) {
            this.OnAdsError(message);
        }
    }

}
