using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public const string SceneNumber = "SceneNumber";
    public const string Money = "Money";
    public const string Volume = "Volume";
    [Header("SkinBalls")]
    public const string Heavy = "Heavy";
    [Header("SkinPlatforms")]
    public const string StartScin = "StartScin";
    [Header("Buffs")]
    public const string Mirror = "Mirror";
    public const string Laser = "Laser";
    public const string Shield = "Shield";
    public const string Portal = "Portal";
    
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SetData(string name, int number)
    {
        PlayerPrefs.SetInt(name, number);
        PlayerPrefs.Save();
    }

    public void SetData(string name, float number)
    {
        PlayerPrefs.SetFloat(name, number);
        PlayerPrefs.Save();
    }
}
