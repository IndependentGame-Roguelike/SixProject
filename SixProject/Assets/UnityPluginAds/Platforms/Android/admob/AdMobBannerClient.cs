using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds.Api;
using UnityPluginAds.Common;

namespace UnityPluginAds.Android {

    public class AdMobBannerClient : AndroidJavaProxy, IBannerClient {

        public event Action OnAdLoaded;

        public event Action<string> OnAdFailedToLoad;

        public event Action OnAdOpened;

        public event Action OnAdClosed;

        public event Action OnAdLeftApplication;

        private AndroidJavaObject adMobBanner;

        public AdMobBannerClient() : base("com.handarui.unity.plugin.ads.AdListener") {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.adMobBanner = new AndroidJavaObject("com.handarui.unity.plugin.ads.platform.admob.AdMobBanner", activity, this);
        }

        public void Create(string adUnitId, BannerSize bannerSize, int positionCode) {
            this.adMobBanner.Call("create", adUnitId, Utils.GetBannerSizeJavaObject(bannerSize), positionCode);
        }

        public void Destroy() {
            this.adMobBanner.Call("destroy");
        }

        public void Hide() {
            this.adMobBanner.Call("hide");
        }

        public void LoadAd(AdRequestConfig config) {
            this.adMobBanner.Call("loadAd", Utils.GetAdRequestConfigJavaObject(config));
        }

        public void Show() {
            this.adMobBanner.Call("show");
        }

        public void onAdLoaded() {
            this.OnAdLoaded();
        }

        public void onAdFailedToLoad(string errorReason) {
            this.OnAdFailedToLoad(errorReason);
        }


        public void onAdOpened() {
            this.OnAdOpened();
        }

        public void onAdClosed() {
            this.OnAdClosed();
        }

        public void onAdLeftApplication() {
            this.OnAdLeftApplication();
        }
    }

}