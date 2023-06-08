using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private int currentGameScore = 0;
    private LevelData levelData;

    void Start()
    {
        AppData.currentGameData = this;
        //levelData = AppData.getLevel(0);
    }

    public void resetGameScore()
    {
        currentGameScore = 0;
    }
    public void increaseGameScore(int amount)
    {
        currentGameScore += amount;
    }
    public int getGameScore()
    {
        return currentGameScore;
    }
}
