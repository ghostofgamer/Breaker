using UnityEngine.SceneManagement;

namespace ADS
{
    public class FullAdContinue : FullAds
    {
        private const string MainScene = "ChooseLvlScene";
    
        protected override void OnClose(bool isClosed)
        {
            base.OnClose(isClosed);
            SceneManager.LoadScene(MainScene);
        }
    }
}
