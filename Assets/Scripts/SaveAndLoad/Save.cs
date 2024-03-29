using UnityEngine;

namespace SaveAndLoad
{
    public class Save : MonoBehaviour
    {
        public const string Money = "Money";
        public const string TemporaryMoney = "TemporaryMoney";
        public const string Score = "Score";
        public const string BrickSmashed = "BrickSmashed";
        [Header("SelectedSkins")]
        public const string SkinBall = "SkinBall";
        public const string SelectedSkinBall = "SelectedSkinBall";
        [Header("Buffs")]
        public const string Laser = "Laser";
        [Header("SystemSavePlatforms")]
        public const string ActiveCapsuleIndex = "ActiveCapsuleIndex";
        public const string CapsuleSkinBought = "CapsuleSkinBought";
        public const string CapsuleSkinActive = "CapsuleSkinActive";
        [Header("ProgressLevel")]
        public const string LevelStatus = "LevelStatus";

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
}