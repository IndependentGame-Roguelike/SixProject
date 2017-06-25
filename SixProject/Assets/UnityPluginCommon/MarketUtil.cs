using UnityEngine;

namespace UnityPluginCommon.utils {

    public class MarketUtil {

        
        /// <summary>
        /// 跳至到应用市场某个应用的详情页
        /// </summary>
        /// <param name="packageName">应用包名</param>
        public static void ShowAppDetailInMarket(string packageName) {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
#elif UNITY_ANDROID
           //获取Android的Java接口  
            AndroidJavaClass mainActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject mainActivity = mainActivityClass.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaClass marketUtilClass = new AndroidJavaClass("com.handarui.unity.plugin.common.utils.MarketUtil");
            marketUtilClass.CallStatic("showAppDetailInMarket", mainActivity, packageName);
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
#else
            Debug.LogWarning("Not support in this platform");
#endif
        }

    }
}