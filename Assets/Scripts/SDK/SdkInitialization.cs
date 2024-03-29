using System.Collections;
using Agava.YandexGames;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDK
{
    public class SdkInitialization : MonoBehaviour
    {
        private const string MainScene = "MainScene";

        [SerializeField] private WaveImages _waveImages;

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
        }

        private IEnumerator Start()
        {
            yield return YandexGamesSdk.Initialize(OnInitialized);
        }

        private void OnInitialized()
        {
            _waveImages.StopWave();
            SceneManager.LoadScene(MainScene);
        }
    }
}