using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds.Api;
using UnityPluginAds.Common;

namespace UnityPluginAds.Android {

    public class VungleAdsVideoClient : AndroidJavaProxy, IAdsVideoClient {

        public event Action<string> OnAdsError;
        public event Action<string, bool> OnAdsFinish;
        public event Action<string> OnAdsReady;
        public event Action<string> OnAdsStart;

        private AndroidJavaObject vungleAdsVideo;

        public VungleAdsVideoClient(): base("com.handarui.unity.plugin.ads.VideoAdListener") {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.vungleAdsVideo = new AndroidJavaObject("com.handarui.unity.plugin.ads.platform.vungle.VungleAdsVideo", activity, this);
        }

        public void Destroy() {
            this.vungleAdsVideo.Call("destroy");
        }

        public void Initialize(string appId) {
            this.vungleAdsVideo.Call("initialize", appId);
        }

        public bool IsReady(string placementId = null) {
            return this.vungleAdsVideo.Call<bool>("isReady", placementId);
        }

        public void OnPause() {
            this.vungleAdsVideo.Call("onPause");
        }

        public void OnResume() {
            this.vungleAdsVideo.Call("onResume");
        }

        public void Show(VideoAdRequestConfig config) {
            this.vungleAdsVideo.Call("show", Utils.GetVideoAdRequestConfigJavaObject(config));
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
