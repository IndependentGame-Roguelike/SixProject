using System.Collections.Generic;
using UnityEngine;
using UnityPluginAds;
using UnityPluginAds.Api;
using UnityPluginAds.Common;
using UnityEngine.SceneManagement;

public class TestVungle : MonoBehaviour {

    private IAdsVideoClient vungleAdsVideoClient;

	// Use this for initialization
	void Start () {
        InitVungleAds();
	}

    // Called when the player pauses
    void OnApplicationPause(bool pauseStatus) {
        if (vungleAdsVideoClient != null) {
            if (pauseStatus)
                vungleAdsVideoClient.OnPause();
            else
                vungleAdsVideoClient.OnResume();
        }
    }

    private void InitVungleAds() {
        string vungleId;
#if UNITY_EDITOR
        vungleId = "";
#elif UNITY_ANDROID
        vungleId = "593e30bc25cbbb8e4f001aa8";
#elif UNITY_IOS
        vungleId = "5922da0a5b2462ab38000606";
#else
        vungleId = "";
#endif
        vungleAdsVideoClient = AdsClientFactory.BuildeVungleAdsVideoClient();
        vungleAdsVideoClient.Initialize(vungleId);

        vungleAdsVideoClient.OnAdsReady += HandleVideoReady;
        vungleAdsVideoClient.OnAdsStart += HandleVideoStart;
        vungleAdsVideoClient.OnAdsFinish += HandleVideoFinish;
        vungleAdsVideoClient.OnAdsError += HandleVideoError;
    }

    private void ShowAds() {
        VideoAdRequestConfig config = new VideoAdRequestConfig();
        config.Incentivized = true;
        vungleAdsVideoClient.Show(config);
    }

    private void HandleVideoReady(string placementId) {
        Debug.Log("Vungle Ads Ready ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    private void HandleVideoStart(string placementId) {
        Debug.Log("Vungle Ads Start ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    private void HandleVideoFinish(string placementId, bool complete) {
        Debug.Log("Vungle Ads Finish ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~:::" + complete);

        if (complete == true)
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
                    SceneManager.LoadScene(1);

                    PlayerCanSeeAds.Instance.IsCanWatchMove = false;
                }
            
        }

    }

    private void HandleVideoError(string message) {
        Debug.Log("Vungle Ads Error ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~:::" + message);
    }

    public void HandleShowButtonClick() {
        if (vungleAdsVideoClient.IsReady()) {
            ShowAds();
        } else {
            Debug.Log("Video not ready!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        }
    }
}
