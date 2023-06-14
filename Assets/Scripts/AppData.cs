using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData
{
    public static int currentLevelIndex { get; set; } = 0;
    private static int highScore = 0;
    private static ArrayList levels=new ArrayList();

    public static GameData currentGameData { get; set; }


    static AppData()
    {
        levels.Add(initializeLevel0());
    }

    public static bool trySetHighScore(int newScore)
    {
        if (highScore >= newScore)
            return false;

        highScore = newScore;
        return true;
    }
    public static int getHighScore()
    {
        return highScore;
    }

    public static LevelData getCurrentLevel()
    {
        return (LevelData)levels[currentLevelIndex];
    }

    private static LevelData initializeLevel0()
    {
        KeyValuePair<FruitGenerator.FruitType, int> pair1 = new(FruitGenerator.FruitType.APPLE, 2);
        KeyValuePair<FruitGenerator.FruitType, int> pair2 = new(FruitGenerator.FruitType.BANANA, 1);
        KeyValuePair<FruitGenerator.FruitType, int> pair3 = new(FruitGenerator.FruitType.CARROT, 1);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs = { pair1, pair2, pair3 };

        CustumerRequest custumerRequest1 = new CustumerRequest(pairs);
        CustumerRequest[] requests = { custumerRequest1 };

        LevelData levelData = new LevelData(requests);
        return levelData;
    }

}
