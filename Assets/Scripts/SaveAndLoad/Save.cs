using UnityEngine;

namespace SaveAndLoad
{
    public class Save : MonoBehaviour
    {
        public const string SceneNumber = "SceneNumber";
        public const string Money = "Money";
        public const string TemporaryMoney = "TemporaryMoney";
        public const string Score = "Score";
        public const string Volume = "Volume";
        public const string Music = "Music";
        public const string SFX = "SFX";

        // public const string IsMuted = "IsMuted";
        [Header("SelectedSkins")] public const string SkinBall = "SkinBall";
        public const string SelectedHeavy = "SelectedHeavy";
        public const string SelectedFaster = "SelectedFaster";
        public const string SelectedBouncy = "SelectedBouncy";
        public const string SelectedSteel = "SelectedSteel";
        public const string SelectedNimble = "SelectedNimble";
        public const string SelectedBright = "SelectedBright";
        public const string SelectedLucky = "SelectedLucky";
        public const string SelectedSteep = "SelectedSteep";
        public const string SelectedImportant = "SelectedImportant";

        [Header("SkinBalls")] public const string Heavy = "Heavy";
        public const string Faster = "Faster";
        public const string Bouncy = "Bouncy";
        public const string Steel = "Steel";
        public const string Nimble = "Nimble";
        public const string Bright = "Bright";
        public const string Lucky = "Lucky";
        public const string Steep = "Steep";
        public const string Important = "Important";

        [Header("Buffs")] public const string Mirror = "Mirror";
        public const string Laser = "Laser";
        public const string Shield = "Shield";
        public const string Portal = "Portal";

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