using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds;
using UnityPluginAds.Api;
using UnityPluginAds.Common;

public class TestInterstitialAd : MonoBehaviour {

    private IInterstitialClient insterstitialClient;

	// Use this for initialization
	void Start () {
        CreateInterstitial();
    }

    private void CreateInterstitial() {
        string bannerId;
#if UNITY_EDITOR
        bannerId = "";
#elif UNITY_ANDROID
        bannerId = "ca-app-pub-5713125831161190/9329593061";
#elif UNITY_IOS
        bannerId = "ca-app-pub-5713125831161190/8856868667";
#else
        bannerId = "";
#endif
        insterstitialClient = AdsClientFactory.BuildAdMobInterstitialClient();
        insterstitialClient.Create(bannerId);
        insterstitialClient.OnAdLoaded += HandleBannerLoaded;
        insterstitialClient.OnAdFailedToLoad += HandleInterstitialFailedLoad;
        insterstitialClient.OnAdClosed += HandleInterstitialClosed;
        insterstitialClient.OnAdOpened += HandleInterstitialOpened;

        RequestAd();
    }

    private void RequestAd() {
        var args = new Dictionary<string, object>();


        AdRequestConfig config = new AdRequestConfig();
        config.TestDevices = new string[] { "BD85DEF743C4D60096243610AE1C1C0C" };
        insterstitialClient.LoadAd(config);
    }

    private void HandleBannerLoaded() {
        Debug.Log("Interstitial Ads Loaded ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    private void HandleInterstitialFailedLoad(string errorMessage) {
        Debug.LogWarning("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX Interstitial failed to load:" + errorMessage);
    }

    private void HandleInterstitialOpened() {
        Debug.Log("Interstitial Ads Opened ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    private void HandleInterstitialClosed() {
        Debug.Log("Interstitial Ads Closed ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        RequestAd();
    }

    public void HandleShowAdButtonClick() {
        insterstitialClient.Show();
    }

}
