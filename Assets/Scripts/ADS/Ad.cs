using UnityEngine;

namespace ADS
{
    public abstract class Ad : MonoBehaviour
    {
        public abstract void Show();

        protected virtual void OnOpen()
        {
            AudioListener.volume = 0;
            Time.timeScale = 0;
        }

        protected virtual void OnClose(bool isClosed)
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }

        protected virtual void OnClose()
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }
    }
}