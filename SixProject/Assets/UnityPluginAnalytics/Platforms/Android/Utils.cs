using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityPluginAnalytics.Android {

    public class Utils {

        public static AndroidJavaObject CreateJavaMap(Dictionary<string, string> dictionary) {
            AndroidJavaObject map = new AndroidJavaObject("java.util.Map");
            foreach (KeyValuePair<string, string> entry in dictionary) {
                map.Call<string>("put", entry.Key, entry.Value);
            }

            return map;
        }

        public static AndroidJavaObject CreateJavaList(List<string> list) {
            AndroidJavaObject jo = new AndroidJavaObject("java.util.ArrayList");
            foreach (string item in list) {
                jo.Call<bool>("add", item);
            }

            return jo;
        }

    }
    
}
