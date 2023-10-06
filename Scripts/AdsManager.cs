using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{

    [SerializeField] string _androidGameId = "5052955";
    [SerializeField] string _IOSGameId = "5052954";
    string _gameId;
    bool _testMode = false;

    private void Awake()
    {
        InitializeAds();
    }

    public void StartAds()
    {
        if (Advertisement.isInitialized)
        {
            LoadIntersitialAds();
        }
        else
        {
            InitializeAds();
        }
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _IOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode,this );
    }

    public void OnInitializationComplete()
    {
        //LoadIntersitialAds();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Initilazing Error ");
    }

    public void LoadIntersitialAds()
    {
        Advertisement.Load("Interstitial_Android",this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(placementId,this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Load Error ");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Time.timeScale = 0f;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1f;
    }
}
