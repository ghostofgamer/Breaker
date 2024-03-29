using UnityEngine.SceneManagement;

namespace ADS
{
    public abstract class FullAdOverScene : FullAds
    {
        protected override void OnClose(bool isClosed)
        {
            base.OnClose(isClosed);
            SceneManager.LoadScene(GetScenenameToLoad());
        }

        protected abstract string GetScenenameToLoad();
    }
}
