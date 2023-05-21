using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSystem
{
    public static string NameGame
    {
        get => "";
    }
    #region [ Setting ]

    public static bool Vibrate
    {
        set => PlayerPrefs.SetInt("Vibrate" + NameGame, value ? 1 : 0);
        get => PlayerPrefs.GetInt("Vibrate" + NameGame, 0) == 1;
    }

    #endregion
    public static bool isPowerBullet
    {
        set => PlayerPrefs.SetInt("isPowerBullet" + NameGame, value ? 1 : 0);
        get => PlayerPrefs.GetInt("isPowerBullet" + NameGame, 0) == 1;
    }
    public static int LevelPlaying
    {
        set => PlayerPrefs.SetInt("LevelPlaying" + NameGame, value);
        get => PlayerPrefs.GetInt("LevelPlaying" + NameGame, 1);
    }
    public static int LevelCurrent
    {
        set => PlayerPrefs.SetInt("LevelCurrent" + NameGame, value);
        get => PlayerPrefs.GetInt("LevelCurrent" + NameGame, 5);
    }
    public static int LevelMax
    {
        set => PlayerPrefs.SetInt("LevelMax" + NameGame, value);
        get => PlayerPrefs.GetInt("LevelMax" + NameGame, 10);
    }
    #region [ Tank ]
    /// <summary>
    /// Tank Green => 0 || Tank Yellow =>1 || Tank Red => 2
    /// </summary>
    public static int TankColor
    {
        set => PlayerPrefs.SetInt("TankColor" + NameGame, value);
        get => PlayerPrefs.GetInt("TankColor" + NameGame, 0);
    }
    public static int TankLife
    {
        set => PlayerPrefs.SetInt("TankLife" + NameGame, value);
        get => PlayerPrefs.GetInt("TankLife" + NameGame, 3);
    }
    public static int LevelTankInGame
    {
        set
        {
            if (value >= 4)
                value = 4;
            if (value <= 0)
                value = 0;
            PlayerPrefs.SetInt("LevelTankInGame" + NameGame, value);
        }
        get => PlayerPrefs.GetInt("LevelTankInGame" + NameGame, 0);
    }
    public static float TankSpeed
    {
        set => PlayerPrefs.SetFloat("TankSpeed" + NameGame, value);
        get => PlayerPrefs.GetFloat("TankSpeed" + NameGame, 1);
    }
    public static float BulletSpeed
    {
        set => PlayerPrefs.SetFloat("BulletSpeed" + NameGame, value);
        get => PlayerPrefs.GetFloat("BulletSpeed" + NameGame, 2);
    }
    #endregion

    #region [ currency ]
    public static int StoreCoin
    {
        set => PlayerPrefs.SetInt("StoreCoin" + NameGame, value);
        get => PlayerPrefs.GetInt("StoreCoin" + NameGame, 0);
    }
    public static int StoreGem
    {
        set => PlayerPrefs.SetInt("StoreGem" + NameGame, value);
        get => PlayerPrefs.GetInt("StoreGem" + NameGame, 0);
    }
    #endregion
}

