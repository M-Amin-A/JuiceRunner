using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "5316742";
    [SerializeField] string _iOSGameId = "5316743";
    [SerializeField] bool _testMode = true;
    private string _gameId;

    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (Advertisement.isSupported)
        {
            if(!Advertisement.isInitialized)
                Advertisement.Initialize(_gameId, _testMode, this);
            else
            {
                GetComponent<InterstitialAdExample>().LoadAd();
                GetComponent<InterstitialAdExample>().ShowAd();
            }
        }
    }


    public void OnInitializationComplete()
    {
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
    }
}