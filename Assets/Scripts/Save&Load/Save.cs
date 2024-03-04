using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public const string SceneNumber = "SceneNumber";
    public const string Money = "Money";
    public const string Volume = "Volume";
    [Header("SelectedSkins")]
    public const string SkinBall = "SkinBall";
    public const string SelectedHeavy = "SelectedHeavy";
    public const string SelectedFaster = "SelectedFaster";
    public const string SelectedBouncy = "SelectedBouncy";
    public const string SelectedSteel = "SelectedSteel";
    public const string SelectedNimble = "SelectedNimble";
    public const string SelectedBright = "SelectedBright";
    public const string SelectedLucky = "SelectedLucky";
    public const string SelectedSteep = "SelectedSteep";
    public const string SelectedImportant = "SelectedImportant";
    [Header("SkinBalls")]
    public const string Heavy = "Heavy";
    public const string Faster = "Faster";
    public const string Bouncy = "Bouncy";
    public const string Steel = "Steel";
    public const string Nimble = "Nimble";
    public const string Bright = "Bright";
    public const string Lucky = "Lucky";
    public const string Steep = "Steep";
    public const string Important = "Important";
    [Header("SkinPlatforms")]
    public const string StartSkin = "StartSkin";
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
