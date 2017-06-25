using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityPluginCommon.utils;
using UnityPluginAnalytics;
using UnityPluginAnalytics.Common;

public class AnalyticsTools : MonoBehaviour {

    private static bool inited = false;
    private static AnalyticsTools instance;

    private IAppsFlyerAnalytics appsFlyerAnalytics;
    private IFBAnalytics fBAnalytics;
    private IUMAnalytics uMnalytics;

    private const string META_KEY_FB_APPID = "com.facebook.sdk.ApplicationId";
    private const string META_KEY_UMENG_APPKEY = "UMENG_APPKEY";
    private const string META_KEY_UMENG_CHANNEL = "UMENG_CHANNEL";
    private const string META_KEY_APPS_FLYER_DEV_KEY = "APPS_FLYER_DEV_KEY";

    public static AnalyticsTools Instance {
        get { return instance; }
    }

    public IAppsFlyerAnalytics GetAppsFlyerAnalytics() {
        return appsFlyerAnalytics;
    }

    public IFBAnalytics GetFBAnalytics() {
        return fBAnalytics;
    }

    public IUMAnalytics GetUMAnalytics() {
        return uMnalytics;
    }

    // Use this for initialization
    void Start () {
        if (!inited) {
            inited = true;
            AnalyticsTools.instance = this;
            DontDestroyOnLoad(gameObject);
            InitAnalytics();
        } else {
            Debug.LogWarning("You have already inited AnalyticsTools!");
        }
    }

    // Called when the player pauses
    void OnApplicationPause(bool pauseStatus) {
        if (pauseStatus) {
            if (fBAnalytics != null) {
                fBAnalytics.OnPause();
            }

            if (uMnalytics != null) {
                uMnalytics.OnPause();
            }
        } else {
            if (fBAnalytics != null) {
                fBAnalytics.OnResume();
            }

            if (uMnalytics != null) {
                uMnalytics.OnResume();
            }
        }
    }

    void InitAnalytics() {
        

        // Facebook
        fBAnalytics = AnalyticsToolFactory.BuildFBAnalyticsTool();
        string fBAppId = GetFBAppId();
        Debug.Log("*************Ready to init FBAnalytics with " + fBAppId);
        if (fBAppId != null) {
            fBAnalytics.Init(fBAppId);
        }

        // AppsFlyer
        //appsFlyerAnalytics = AnalyticsToolFactory.BuildAppsFlyerAnalyticsTool();
        //string appsFlyerDevKey = GetAppsFlyerDevKey();
        //Debug.Log("*************Ready to init AppsFlyerAnalytics with " + appsFlyerDevKey);
        //if (appsFlyerDevKey != null) {
        //    appsFlyerAnalytics.Init(appsFlyerDevKey);
        //}

        // UMeng
        uMnalytics = AnalyticsToolFactory.BuildUMAnalyticsTool();
        string uMAppKey = GetUMAppKey();
        string uMChannelId = GetUMAppChannelId();
        Debug.Log("*************Ready to init UMAnalytics with " + uMAppKey + " and " + uMChannelId);
        if (uMAppKey != null && uMChannelId != null) {
            uMnalytics.Init(uMAppKey, uMChannelId);
            uMnalytics.SetDebugMode(true);
        }
    }

    private string GetFBAppId() {
#if UNITY_EDITOR
        Debug.LogWarning("Not support in this platform");
        return null;
#elif UNITY_ANDROID
        return ConfigUtil.GetAndroidManifestMetadata(META_KEY_FB_APPID);
#elif UNITY_IOS
        Debug.LogWarning("Not support in this platform");
        return null;
#else
        Debug.LogWarning("Not support in this platform");
        return null;
#endif
    }

    private string GetAppsFlyerDevKey() {
#if UNITY_EDITOR
        Debug.LogWarning("Not support in this platform");
        return null;
#elif UNITY_ANDROID
        return ConfigUtil.GetAndroidManifestMetadata(META_KEY_APPS_FLYER_DEV_KEY);
#elif UNITY_IOS
        Debug.LogWarning("Not support in this platform");
        return null;
#else
        Debug.LogWarning("Not support in this platform");
        return null;
#endif
    }

    private string GetUMAppKey() {
#if UNITY_EDITOR
        Debug.LogWarning("Not support in this platform");
        return null;
#elif UNITY_ANDROID
        return ConfigUtil.GetAndroidManifestMetadata(META_KEY_UMENG_APPKEY);
#elif UNITY_IOS
        Debug.LogWarning("Not support in this platform");
        return null;
#else
        Debug.LogWarning("Not support in this platform");
        return null;
#endif
    }

    private string GetUMAppChannelId() {
#if UNITY_EDITOR
        Debug.LogWarning("Not support in this platform");
        return null;
#elif UNITY_ANDROID
        return ConfigUtil.GetAndroidManifestMetadata(META_KEY_UMENG_CHANNEL);
#elif UNITY_IOS
        Debug.LogWarning("Not support in this platform");
        return null;
#else
        Debug.LogWarning("Not support in this platform");
        return null;
#endif
    }

}
