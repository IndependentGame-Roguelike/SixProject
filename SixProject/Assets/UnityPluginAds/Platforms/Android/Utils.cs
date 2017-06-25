using System;
using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds.Api;

namespace UnityPluginAds.Android {
    internal class Utils {

        public static AndroidJavaObject GetBannerSizeJavaObject(BannerSize bannerSize) {
            return new AndroidJavaObject("com.handarui.unity.plugin.ads.BannerSize", bannerSize.Width, bannerSize.Height);
        }


        public static AndroidJavaObject GetAdRquestArgumentsJavaObject(Dictionary<string, object> args) {
            AndroidJavaObject map = new AndroidJavaObject("java.util.HashMap");

            if (args != null) {
                List<string> testDevices = args["testDevices"] as List<string>;

                if (testDevices != null) {
                    AndroidJavaObject list = new AndroidJavaObject("java.util.ArrayList");
                    foreach (string deviceId in testDevices) {
                        list.Call<bool>("add", deviceId);
                    }

                    map.Call<string>("put", "testDevices", list);
                }
            }

            return map;
        }

        public static AndroidJavaObject GetAdRequestConfigJavaObject(AdRequestConfig config) {
            AndroidJavaObject oj = new AndroidJavaObject("com.handarui.unity.plugin.ads.AdRequestConfig");

            if (config != null) {
                oj.Call("setTestDevices", new object[1] { config.TestDevices });
            }

            return oj;
        }

        public static AndroidJavaObject GetVideoAdRequestConfigJavaObject(VideoAdRequestConfig config) {
            AndroidJavaObject oj = new AndroidJavaObject("com.handarui.unity.plugin.ads.VideoAdRequestConfig");

            if (config != null) {
                oj.Call("setPlacementId", config.PlacementId);
                oj.Call("setIncentivized", config.Incentivized);
                oj.Call("setUserId", config.UserId);
            }

            return oj;
        }

    }
}
