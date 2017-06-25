using UnityEngine;

namespace UnityPluginCommon.utils {

    public class ConfigUtil {

        /// <summary>
        /// 获取AndroidManifest中的metadata数据
        /// </summary>
        /// <param name="key">metadata的key</param>
        /// <returns></returns>
        public static string GetAndroidManifestMetadata(string key) {

#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            //获取Android的Java接口  
            AndroidJavaClass mainActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject mainActivity = mainActivityClass.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaClass configUtilClass = new AndroidJavaClass("com.handarui.unity.plugin.common.utils.ConfigUtil");
            string value = configUtilClass.CallStatic<string>("getManifestMetadata", mainActivity, key);
            return value;
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