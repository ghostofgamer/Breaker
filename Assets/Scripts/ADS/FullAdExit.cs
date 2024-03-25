using UnityEngine.SceneManagement;

namespace ADS
{
    public class FullAdExit : FullAds
    {
        private const string MainScene = "MainScene";

        protected override void OnClose(bool isClosed)
        {
            base.OnClose(isClosed);
            SceneManager.LoadScene(MainScene);
        }
    }
}