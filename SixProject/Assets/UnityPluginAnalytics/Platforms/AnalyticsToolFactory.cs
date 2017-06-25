using UnityPluginAnalytics.Common;
using UnityPluginAnalytics.Android;
using UnityEngine;

namespace UnityPluginAnalytics {
    class AnalyticsToolFactory {

        public static IAppsFlyerAnalytics BuildAppsFlyerAnalyticsTool() {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new AppsFlyerAnalytics();
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
            return null;
#else
            Debug.LogWarning("Not support in this platform");
            return null;
#endif
        }

        public static IFBAnalytics BuildFBAnalyticsTool() {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new FBAnalytics();
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
            return null;
#else
            Debug.LogWarning("Not support in this platform");
            return null;
#endif
        }

        public static IUMAnalytics BuildUMAnalyticsTool() {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new UMAnalytics();
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
