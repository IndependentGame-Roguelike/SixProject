using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds.Api;
using UnityPluginAds.Common;

namespace UnityPluginAds.Android {

    public class AdMobInterstitialClient : AndroidJavaProxy, IInterstitialClient {
        public event Action OnAdClosed;
        public event Action<string> OnAdFailedToLoad;
        public event Action OnAdLeftApplication;
        public event Action OnAdLoaded;
        public event Action OnAdOpened;

        private AndroidJavaObject adMobInterstitial;

        public AdMobInterstitialClient(): base("com.handarui.unity.plugin.ads.AdListener") {
            AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.adMobInterstitial = new AndroidJavaObject("com.handarui.unity.plugin.ads.platform.admob.AdMobInterstitial", activity, this);
        }

        public void Create(string adUnitId) {
            this.adMobInterstitial.Call("create", adUnitId);
        }

        public void Destroy() {
            this.adMobInterstitial.Call("destory");
        }

        public bool IsLoaded() {
            return this.adMobInterstitial.Call<bool>("isLoaded");
        }

        public void LoadAd(AdRequestConfig config) {
            this.adMobInterstitial.Call("loadAd", Utils.GetAdRequestConfigJavaObject(config));
        }

        public void Show() {
            this.adMobInterstitial.Call("show");
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
