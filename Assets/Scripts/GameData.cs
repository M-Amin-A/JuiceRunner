using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData : MonoBehaviour
{
    private int currentGameScore = 0;

    private Queue customerRequestsQueue;

    private CustumerRequest currentRequest;
    private ArrayList playerClaims;

    public TextMeshProUGUI scoreTextBox;
    void Start()
    {
        AppData.currentGameData = this;

        LevelData levelData = AppData.getCurrentLevel();
        customerRequestsQueue = (Queue)levelData.customerRequestsQueue.Clone();

        dequeueNewRequest();
    }

    private void dequeueNewRequest()
    {
        currentRequest = (CustumerRequest)customerRequestsQueue.Dequeue();
        playerClaims = new ArrayList();
    }
    
    public void fruitClaim(FruitGenerator.FruitType fruitType)
    {
        playerClaims.Add(fruitType);
        increaseGameScore(1);
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

        foreach(KeyValuePair<FruitGenerator.FruitType, int> pair in currentRequest.fruitCountPairs)
        {
            if (playerClaimsFruitTypeCount(pair.Key) < pair.Value)
                return pair.Key;
        }

        return FruitGenerator.FruitType.PINE_APPLE;
    }

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
    public int getGameScore()
    {
        return currentGameScore;
    }
}
