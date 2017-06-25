using UnityEngine;

namespace UnityPluginCommon.utils {

    public class DialogUtil {
  

        /// <summary>
        /// Android弹出Toast
        /// </summary>
        /// <param name="message">信息文本</param>
        /// <param name="longTime">是否显示较长时间</param>
        public static void Toast(string message, bool longTime = false) {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
#elif UNITY_ANDROID
            //获取Android的Java接口  
            AndroidJavaClass mainActivityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject mainActivity = mainActivityClass.GetStatic<AndroidJavaObject>("currentActivity");

            AndroidJavaClass dialogUtilClass = new AndroidJavaClass("com.handarui.unity.plugin.common.utils.DialogUtil");
            dialogUtilClass.CallStatic("toast", mainActivity, message, false);
#elif UNITY_IOS
            Debug.LogWarning("Not support in this platform");
#else
            Debug.LogWarning("Not support in this platform");
#endif
        }

    }
}