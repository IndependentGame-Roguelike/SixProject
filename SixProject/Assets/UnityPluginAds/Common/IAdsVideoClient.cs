using System;
using System.Collections.Generic;
using UnityPluginAds.Api;

namespace UnityPluginAds.Common {

    public interface IAdsVideoClient {

        event Action<string> OnAdsReady;

        event Action<string> OnAdsStart;

        event Action<string, bool> OnAdsFinish;

        event Action<string> OnAdsError;


        void Initialize(string appId);

        bool IsReady(string placementId =null);

        void Show(VideoAdRequestConfig config);

        void OnPause();

        void OnResume();

        void Destroy();

    }

}
