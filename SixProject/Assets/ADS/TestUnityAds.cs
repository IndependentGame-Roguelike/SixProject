using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds;
using UnityPluginAds.Api;
using UnityPluginAds.Common;
using UnityEngine.SceneManagement;

public class TestUnityAds : MonoBehaviour {

    private IAdsVideoClient unityAdsVideoClient;

    // Use this for initialization
    void Start() {
        InitUnityAds();
    }

    // Called when the player pauses
    void OnApplicationPause(bool pauseStatus) {
        if (unityAdsVideoClient != null) {
            if (pauseStatus)
                unityAdsVideoClient.OnPause();
            else
                unityAdsVideoClient.OnResume();
        }
    }

    private void InitUnityAds() {
                string unityId;
#if UNITY_EDITOR
        unityId = "";
#elif UNITY_ANDROID
        unityId = "1443326";
#elif UNITY_IOS
        unityId = "1443325";
#else
        unityId = "";
#endif
        unityAdsVideoClient = AdsClientFactory.BuildeUnityAdsVideoClient(true);
        unityAdsVideoClient.Initialize(unityId);
        
        unityAdsVideoClient.OnAdsReady += HandleVideoReady;
        unityAdsVideoClient.OnAdsStart += HandleVideoStart;
        unityAdsVideoClient.OnAdsFinish += HandleVideoFinish;
        unityAdsVideoClient.OnAdsError += HandleVideoError;
    }

    private void ShowAds() {
        VideoAdRequestConfig config = new VideoAdRequestConfig();
        config.PlacementId = "rewardedVideo";
        unityAdsVideoClient.Show(config);
    }

    private void HandleVideoReady(string placementId) {
        Debug.Log("Vungle Ads Ready ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    private void HandleVideoStart(string placementId) {
        Debug.Log("Vungle Ads Start ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    private void HandleVideoFinish(string placementId, bool complete) {
        Debug.Log("Vungle Ads Finish ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~:::" + complete);

        if (complete==true)
        {
            
                if (RewardButton.instance.isButton == true)
                {
                    RewardButton.instance.AddPlayerScore();
                    GameObject a = GameObject.FindGameObjectWithTag("Player");
                    //a.transform.GetChild(1).gameObject.GetComponent<Reward>().enabled = true;
                    Rigidbody2D aRigibody = a.GetComponent<Rigidbody2D>();
                    aRigibody.AddForce(new Vector2(0, 0.001f));
                    Reward reward = a.transform.GetChild(1).GetComponent<Reward>();
                    reward.Open();

                    try
                    {
                        GameObject.Find("RewardButton").gameObject.SetActive(false);

                    }
                    catch (System.Exception)
                    {

                        Debug.Log("Can not see Ads");
                    }
                }
                else
                {
                    //string sceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(1);

                    PlayerCanSeeAds.Instance.IsCanWatchMove = false;
                }
            

        }

    }

    private void HandleVideoError(string message) {
        Debug.Log("Vungle Ads Error ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~:::" + message);
    }

    public void HandleShowButtonClick() {
        if (unityAdsVideoClient.IsReady("rewardedVideo")) {
            ShowAds();
        } else {
            Debug.Log("Video not ready!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            gameObject.GetComponent<TestVungle>().HandleShowButtonClick();
        }
    }
}
