using System;
using GoogleMobileAds.Api;
using MadFireOn;

public class AdsController
{

    private int isPayNoAds = 0;
#if UNITY_EDITOR
    string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-9603977744732337~6909654805";
#elif UNITY_IPHONE
        string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
#else
        string adUnitId = "unexpected_platform";
#endif
    private InterstitialAd interstitial;
    private BannerView bannerView;
    private static AdsController _instance;

    public static AdsController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance=new AdsController();
            }
            return _instance;
        }
    }

    public void Init()
    {
        if (!GameManager.instance.canShowAds)
        {
            RequestBanner();
            RequestInterstitial();
        }
    }

    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        //   AdRequest request = new AdRequest.Builder().Build();
        AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
       .Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    #region Event

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        // Handle the ad loaded event.
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // Handle the ad failed to load event.
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        // Handle the ad loaded event.
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        // Handle the ad loaded event.
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        // Handle the ad loaded event.
    }

    #endregion

    public void ShowRewardedAd()
    {
        ShowInterstitialAds();
    }

    public void ShowInterstitialAds()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideADs()
    {
        if (bannerView != null)
        {
            bannerView.Hide();
        }
    }

    public void ShowADs()
    {
        if (bannerView != null)
        {
            bannerView.Show();
        }
    }

    public void OnDestroy()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerView.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerView.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerView.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerView.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }
    }
}
