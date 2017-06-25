using System;
using System.Collections.Generic;
using UnityPluginAds.Api;

namespace UnityPluginAds.Common {

    public interface IBannerClient {

        event Action OnAdLoaded;

        event Action<string> OnAdFailedToLoad;

        event Action OnAdOpened;

        event Action OnAdClosed;

        event Action OnAdLeftApplication;


        void Create(string adUnitId, BannerSize bannerSize, int positionCode);

        void LoadAd(AdRequestConfig config);

        void Show();

        void Hide();

        void Destroy();

    }

}