using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameData : MonoBehaviour
{
    private int currentGameScore = 0;

    private Queue customerRequestsQueue;

    private Dictionary<FruitGenerator.FruitType, int> currentRequest;
    private int numberOfFruitAtFirstOfRequest;
    private int numberOfFruitClaimed;

    public TextMeshProUGUI scoreTextBox;
    public GameObject currentRequestBox;
    public GameObject Ads;

    private float remainingTime = 120;
    public TextMeshProUGUI timeTextBox;

    public GameObject liquid;

    public AudioSource gameMusic;

    private const float maxLiquidHeight = 5.5f;

    public bool gameFinished = false;
    void Start()
    {
        AppData.currentGameData = this;

        LevelData levelData = AppData.getCurrentLevel();
        customerRequestsQueue = (Queue)levelData.customerRequestsQueue.Clone();

        dequeueNewRequest();

        updateTimeBox();
        Ads.GetComponent<AdsInitializer>().InitializeAds();
    }

    private void Update()
    {
        if (gameFinished) return;

        remainingTime -= Time.deltaTime;

        updateTimeBox();

        if (remainingTime <= 0)
            finishGame(false);
    }

    public void finishGame(bool isWin)
    {
        gameFinished = true;
        gameMusic.Stop();

        Ads.GetComponent<AdsInitializer>().InitializeAds();

        if (isWin)
        {
            AppData.currentLevelIndex++;
            if (AppData.currentLevelIndex > 2)
                AppData.currentLevelIndex = 2;
        }

    }

    private void dequeueNewRequest()
    {
        currentRequestBox.GetComponent<Animator>().SetTrigger("boxGo");
        liquid.GetComponent<RectTransform>().localScale = new Vector3(liquid.GetComponent<RectTransform>().localScale.x, 0, 0);

        if (customerRequestsQueue.Count == 0)
        {
            finishGame(true);
            return;
        }

        CustumerRequest newCustomerRequest = (CustumerRequest)customerRequestsQueue.Dequeue();
        currentRequest = new();

        numberOfFruitAtFirstOfRequest = 0;
        numberOfFruitClaimed = 0;
        foreach (KeyValuePair<FruitGenerator.FruitType, int> pair in newCustomerRequest.fruitCountPairs)
        {
            numberOfFruitAtFirstOfRequest += pair.Value;
            currentRequest.Add(pair.Key, pair.Value);
        }


        GameObject newRequestBox = Instantiate(currentRequestBox,currentRequestBox.transform.parent);
        newRequestBox.SetActive(true);
        newRequestBox.GetComponent<RawImage>().rectTransform.anchoredPosition = new Vector2(-550, newRequestBox.GetComponent<RawImage>().rectTransform.anchoredPosition.y);

        
        currentRequestBox = newRequestBox;
        requestBoxTextSet();

        currentRequestBox.GetComponent<Animator>().SetTrigger("boxCome");
    }

    private void requestBoxTextSet()
    {
        GameObject requestText = currentRequestBox.transform.Find("RequestTextBox").gameObject;
        GameObject requestNumbers = currentRequestBox.transform.Find("Numbers").gameObject;

        ArrayList requestFruitsArrayList = new();
        string requestNumbersString = "";

        foreach (KeyValuePair<FruitGenerator.FruitType, int> pair in currentRequest)
        {
            requestFruitsArrayList.Add(FruitGenerator.getSpriteIndexOfFruitType(pair.Key));
            requestNumbersString += pair.Value + "\n";
        }

        requestText.GetComponent<TextMeshProUGUI>().text = requestNumbersToString(requestFruitsArrayList);
        requestNumbers.GetComponent<TextMeshProUGUI>().text = requestNumbersString;
    }

    private void updateTimeBox()
    {
        float minute = remainingTime / 60;
        float seconds = remainingTime % 60;

        int min = Mathf.FloorToInt(minute);
        int sec = Mathf.FloorToInt(seconds);

        min = Mathf.Max(min, 0);
        sec = Mathf.Max(sec, 0);

        string minuteString = min < 10 ? "0" + min : "" + min;
        string secondString = sec < 10 ? "0" + sec : "" + sec;

        timeTextBox.text = minuteString + ":" + secondString;
    }
    public string requestNumbersToString(ArrayList numbers)
    {
        string s = "";

        foreach (int number in numbers)
            s += "<sprite="+number+">\n";

        return s;
    }

    public bool fruitClaim(FruitGenerator.FruitType fruitType)
    {
        if (currentRequest.ContainsKey(fruitType) && currentRequest[fruitType] > 0)
        {
            currentRequest[fruitType]--;

            requestBoxTextSet();

            increaseGameScore(1);

            StartCoroutine(increaseLiquid(2,fruitType));

            numberOfFruitClaimed++;

            if (hasRequestCompleted())
                dequeueNewRequest();

            return true;
        }
        return false;
    }
    private bool hasRequestCompleted()
    {
        foreach (KeyValuePair<FruitGenerator.FruitType, int> pair in currentRequest)
            if (pair.Value > 0)
                return false;
        return true;
    }

    private void increaseGameScore(int amount)
    {
        currentGameScore += amount;
        scoreTextBox.text = currentGameScore.ToString();
    }

    public FruitGenerator.FruitType getUnclaimedFruitType()
    {
        if (currentRequest == null)
            return FruitGenerator.FruitType.CHERRY;

        ArrayList unclaimedFruits = new();
        foreach (KeyValuePair<FruitGenerator.FruitType, int> pair in currentRequest)
            if (pair.Value > 0)
                unclaimedFruits.Add(pair.Key);

        if(unclaimedFruits.Count==0)
            return FruitGenerator.FruitType.PINE_APPLE;

        int randomIndex = Random.Range(0, unclaimedFruits.Count - 1);
        return (FruitGenerator.FruitType)unclaimedFruits[randomIndex];
    }

    /*
    private int playerClaimsFruitTypeCount(FruitGenerator.FruitType fruitType)
    {
        int count = 0;
        foreach(FruitGenerator.FruitType claim in playerClaims)
        {
            if (claim.Equals(fruitType))
                count++;
        }
        return count;
    }
    */

    public int getGameScore()
    {
        return currentGameScore;
    }

    private IEnumerator increaseLiquid(float waitTime,FruitGenerator.FruitType fruitType)
    {
        yield return new WaitForSeconds(waitTime);
        liquid.GetComponent<RectTransform>().localScale = new Vector3(liquid.GetComponent<RectTransform>().localScale.x, (float)numberOfFruitClaimed / (float)numberOfFruitAtFirstOfRequest * maxLiquidHeight, 0);

        liquid.GetComponent<RawImage>().color = FruitGenerator.getColorOfFruitType(fruitType);
    }
}
