using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Umeng;

public class UmengGameAnalytics : MonoBehaviour
{
    private const string AppKey = "594f808b677baa0cb5001eaa";
    private const string ChannelId = "GooglePlay";
    private const string ConfigKey = "";
    // Use this for initialization
    void Start()
    {
        GA.StartWithAppKeyAndChannelId(AppKey, ChannelId);
        GA.EnableActivityDurationTrack(true);
        GA.PageBegin("mainGame");
        //GA.UpdateOnlineConfig();
        //GA.GetConfigParamForKey(ConfigKey);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDestroy()
    {
        GA.PageEnd("mainGame");
    }
}
