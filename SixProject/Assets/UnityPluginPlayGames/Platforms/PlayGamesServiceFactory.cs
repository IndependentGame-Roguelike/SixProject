using System;
using UnityEngine;
using UnityPluginPlayGames.Common;
using UnityPluginPlayGames.Android;

namespace UnityPluginPlayGames
{

    public class AdsClientFactory
    {

        public static IPlayGamesService GetPlayGamesService()
        {
#if UNITY_EDITOR
            Debug.LogWarning("Not support in this platform");
            return null;
#elif UNITY_ANDROID
            return new AndoirdPlayGamesService();
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