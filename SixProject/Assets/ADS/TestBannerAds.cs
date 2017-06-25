using UnityEngine;
using UnityPluginAds;
using UnityPluginAds.Api;
using UnityPluginAds.Common;

public class TestBannerAds : MonoBehaviour {

    private IBannerClient bannerClient;

    

    // Use this for initialization
    void Start () {
        CreateBanner();
	}

    private void CreateBanner() {
        string bannerId;  
#if UNITY_EDITOR
        bannerId = "";
#elif UNITY_ANDROID
        bannerId = "ca-app-pub-5713125831161190/7852859863";
#elif UNITY_IOS
        bannerId = "ca-app-pub-5713125831161190/5903402262";
#else
        bannerId = "";
#endif
        bannerClient = AdsClientFactory.BuildAdMobBannerClient();
        bannerClient.Create(bannerId, BannerSize.BANNER, BannerPosition.POSITION_TOP);
        bannerClient.OnAdLoaded += HandleBannerLoaded;
        bannerClient.OnAdFailedToLoad += HandleBannerFailedLoad;

        AdRequestConfig config = new AdRequestConfig();
        config.TestDevices = new string[] { "BD85DEF743C4D60096243610AE1C1C0C" };
        bannerClient.LoadAd(config);
    }

    private void HandleBannerLoaded() {
        Debug.Log("Banner Ads Loaded ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        // bannerClient.Show();
        HandleShowAdButtonClick();

    }

    private void HandleBannerFailedLoad(string errorMessage) {
        Debug.LogWarning("Banner failed to load:" + errorMessage);
    }
    

    public void HandleHideAdButtonClick() {
        bannerClient.Hide();
    }

    public void HandleShowAdButtonClick() {
        bannerClient.Show();
    }
	
	
}
