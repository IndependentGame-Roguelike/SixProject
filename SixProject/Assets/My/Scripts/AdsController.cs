using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsController : MonoBehaviour {

    private int isPayNoAds = 0;

    void Start()
    {
        Init();
    }

    void Init()
    {
        isPayNoAds = PlayerPrefs.GetInt("isPay");

        if (!PlayerCanSeeAds.Instance.isHaveAdsController)
        {
            PlayerCanSeeAds.Instance.isHaveAdsController = true;

            DontDestroyOnLoad(gameObject);

        }

        if (isPayNoAds != 1)
        {
            AddAds();
        }
    }


    void AddAds()
    {
        gameObject.AddComponent<TestBannerAds>();
        gameObject.AddComponent<TestInterstitialAd>();
    }

    public void PaySucceed()
    {
        if (PlayerPrefs.GetInt("isPay") == 1)
        {
            isPayNoAds = PlayerPrefs.GetInt("isPay");
        }
        else
        {
            isPayNoAds = 1;
            PlayerPrefs.SetInt("isPay", 1);
            //GameObject.Find("RemoveAdsButton").SetActive(false);

            //Init();
            SceneManager.LoadScene(0);
        }
        Debug.Log("Succeed");


    }

    public void PayDefeat()
    {
        if (PlayerPrefs.GetInt("isPay") != 1)
        {
            isPayNoAds = 0;
        }

        Debug.Log("Defeat");
    }

}
