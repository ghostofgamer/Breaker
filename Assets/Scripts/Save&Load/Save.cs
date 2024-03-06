using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public const string SceneNumber = "SceneNumber";
    public const string Money = "Money";
    public const string TemporaryMoney = "TemporaryMoney";
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
    [Header("SelectedPlatforms")]
    public const string DefaultPlatform = "SkinBall";
    public const string One = "One";
    public const string Two = "Two";
    public const string Three = "Three";
    public const string Four = "Four";
    public const string Five = "Five";
    public const string Six = "Six";
    public const string Seven = "Seven";
    public const string Eight = "Eight";
    public const string Nine = "Nine";
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
    public const string SkinPlatform = "SkinPlatform";
    public const string StartSkin = "StartSkin";
    public const string one = "one";
    public const string two = "two";
    public const string three = "three";
    public const string four = "four";
    public const string five = "five";
    public const string six = "six";
    public const string seven = "seven";
    public const string eight = "eight";

    [Header("Buffs")]
    public const string Mirror = "Mirror";
    public const string Laser = "Laser";
    public const string Shield = "Shield";
    public const string Portal = "Portal";

    [Header("SystemSavePlatforms")] 
    public const string ActiveCapsuleIndex = "ActiveCapsuleIndex";
    public const string CapsuleSkinBought0  = "CapsuleSkinBought0";
    public const string CapsuleSkinBought1  = "CapsuleSkinBought1";
    public const string CapsuleSkinBought2  = "CapsuleSkinBought2";
    public const string CapsuleSkinBought3  = "CapsuleSkinBought3";
    public const string CapsuleSkinBought4  = "CapsuleSkinBought4";
    public const string CapsuleSkinBought5  = "CapsuleSkinBought5";
    public const string CapsuleSkinBought6  = "CapsuleSkinBought6";
    public const string CapsuleSkinBought7  = "CapsuleSkinBought7";
    public const string CapsuleSkinBought8  = "CapsuleSkinBought8";
    
    public const string CapsuleSkinActive0  = "CapsuleSkinActive0";
    public const string CapsuleSkinActive1  = "CapsuleSkinActive1";
    public const string CapsuleSkinActive2  = "CapsuleSkinActive2";
    public const string CapsuleSkinActive3  = "CapsuleSkinActive3";
    public const string CapsuleSkinActive4  = "CapsuleSkinActive4";
    public const string CapsuleSkinActive5  = "CapsuleSkinActive5";
    public const string CapsuleSkinActive6  = "CapsuleSkinActive6";
    public const string CapsuleSkinActive7  = "CapsuleSkinActive7";
    public const string CapsuleSkinActive8  = "CapsuleSkinActive8";
    
    
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
