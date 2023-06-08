using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppData
{
    public static int currentLevelIndex { get; set; } = 0;
    private static int highScore = 0;
    private static LevelData[] levels;

    public static GameData currentGameData { get; set; }

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

    public static LevelData getLevel(int index)
    {
        return levels[index];
    }
}
