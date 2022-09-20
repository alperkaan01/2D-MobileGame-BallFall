using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{

    [SerializeField] private bool testMode = true;

    public static AdManager Instance;

    private GameOverHandler goh;


#if UNITY_ANDROID
    private string gameId = "4913163";
#elif UNITY_IOS
    private string gameId = "4913162";
#endif

    private void Awake() {
        if(Instance != null && Instance != this){
            
            Destroy(gameObject);

        }else {
            
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);

            Advertisement.Initialize(gameId, testMode);

        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Error is occured {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult) {
            case ShowResult.Finished:
                goh.ContinueGame();
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad is failed");
                break;
            case ShowResult.Skipped:
                //Debug.Log("Ad is skipped");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //Debug.Log($"Ad is just started with an id {placementId}");
    }

    public void OnUnityAdsReady(string placementId)
    {
        //Debug.Log($"Ad is ready with an id {placementId}");
    }
    

    public void showAd(GameOverHandler gameOverHandler){
        this.goh = gameOverHandler;

        Advertisement.Show("rewardedVideo");
    }
}
