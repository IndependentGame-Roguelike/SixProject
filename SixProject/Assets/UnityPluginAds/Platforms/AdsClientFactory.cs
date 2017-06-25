using System;
using UnityEngine;
using UnityPluginAds.Common;
using UnityPluginAds.Android;

namespace UnityPluginAds {

    public class AdsClientFactory {

        public static IBannerClient BuildAdMobBannerClient() {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new AdMobBannerClient();
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
            return null;
#else
            Debug.LogWarning("Not support in this platform");
            return null;
#endif
        }

        public static IInterstitialClient BuildAdMobInterstitialClient() {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new AdMobInterstitialClient();
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
            return null;
#else
            Debug.LogWarning("Not support in this platform");
            return null;
#endif
        }

        public static IAdsVideoClient BuildeVungleAdsVideoClient() {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new VungleAdsVideoClient();
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
            return null;
#else
            Debug.LogWarning("Not support in this platform");
            return null;
#endif
        }

        public static IAdsVideoClient BuildeUnityAdsVideoClient(bool testMode=false) {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new UnityAdsVideoClient(testMode);
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
            return null;
#else
            Debug.LogWarning("Not support in this platform");
            return null;
#endif
        }
    }
}
