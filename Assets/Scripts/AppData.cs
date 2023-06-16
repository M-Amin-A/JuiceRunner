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
        levels.Add(initializeLevel1());
        levels.Add(initializeLevel2());
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
        KeyValuePair<FruitGenerator.FruitType, int> pair11 = new(FruitGenerator.FruitType.APPLE, 2);
        KeyValuePair<FruitGenerator.FruitType, int> pair12 = new(FruitGenerator.FruitType.BANANA, 1);
        KeyValuePair<FruitGenerator.FruitType, int> pair13 = new(FruitGenerator.FruitType.CARROT, 1);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs1 = { pair11, pair12, pair13 };
        CustumerRequest custumerRequest1 = new CustumerRequest(pairs1);

        CustumerRequest[] requests = { custumerRequest1 };

        LevelData levelData = new LevelData(requests,120,0.2f);
        return levelData;
    }

    private static LevelData initializeLevel1()
    {
        KeyValuePair<FruitGenerator.FruitType, int> pair11 = new(FruitGenerator.FruitType.STRAWBERRY, 3);
        KeyValuePair<FruitGenerator.FruitType, int> pair12 = new(FruitGenerator.FruitType.WATERMENON, 1);
        KeyValuePair<FruitGenerator.FruitType, int> pair13 = new(FruitGenerator.FruitType.CARROT, 1);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs1 = { pair11, pair12, pair13 };
        CustumerRequest custumerRequest1 = new CustumerRequest(pairs1);

        KeyValuePair<FruitGenerator.FruitType, int> pair21 = new(FruitGenerator.FruitType.PEAR, 2);
        KeyValuePair<FruitGenerator.FruitType, int> pair22 = new(FruitGenerator.FruitType.ORANGE, 2);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs2 = { pair21, pair22};
        CustumerRequest custumerRequest2 = new CustumerRequest(pairs2);

        CustumerRequest[] requests = { custumerRequest1, custumerRequest2 };

        LevelData levelData = new LevelData(requests, 120, 0.25f);
        return levelData;
    }

    private static LevelData initializeLevel2()
    {
        KeyValuePair<FruitGenerator.FruitType, int> pair11 = new(FruitGenerator.FruitType.PURPLE_GRAPES, 3);
        KeyValuePair<FruitGenerator.FruitType, int> pair12 = new(FruitGenerator.FruitType.BANANA, 1);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs1 = { pair11, pair12};
        CustumerRequest custumerRequest1 = new CustumerRequest(pairs1);

        KeyValuePair<FruitGenerator.FruitType, int> pair21 = new(FruitGenerator.FruitType.PINE_APPLE, 3);
        KeyValuePair<FruitGenerator.FruitType, int> pair22 = new(FruitGenerator.FruitType.TOMATO, 2);
        KeyValuePair<FruitGenerator.FruitType, int> pair23 = new(FruitGenerator.FruitType.CHERRY, 1);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs2 = { pair21, pair22, pair23 };
        CustumerRequest custumerRequest2 = new CustumerRequest(pairs2);

        KeyValuePair<FruitGenerator.FruitType, int> pair31 = new(FruitGenerator.FruitType.ORANGE, 4);
        KeyValuePair<FruitGenerator.FruitType, int>[] pairs3 = { pair31};
        CustumerRequest custumerRequest3 = new CustumerRequest(pairs3);

        CustumerRequest[] requests = { custumerRequest1, custumerRequest2, custumerRequest3 };

        LevelData levelData = new LevelData(requests, 60, 0.4f);
        return levelData;
    }

}
