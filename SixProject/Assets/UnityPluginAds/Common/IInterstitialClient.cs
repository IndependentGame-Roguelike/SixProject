using System;
using System.Collections.Generic;
using UnityPluginAds.Api;

namespace UnityPluginAds.Common {

    public interface IInterstitialClient {

        event Action OnAdLoaded;

        event Action<string> OnAdFailedToLoad;

        event Action OnAdOpened;

        event Action OnAdClosed;

        event Action OnAdLeftApplication;

        void Create(string adUnitId);

        void LoadAd(AdRequestConfig config);

        bool IsLoaded();

        void Show();

        void Destroy();

    }

}
