using UnityEngine;

namespace ADS
{
    public abstract class Ad : MonoBehaviour
    {
        public abstract void Show();

        protected virtual void OnOpen()
        {
            SetValue(0);
        }

        protected virtual void OnClose(bool isClosed)
        {
            SetValue(1);
        }

        protected virtual void OnClose()
        {
            SetValue(1);
        }

        private void SetValue(int value)
        {
            Time.timeScale = value;
            AudioListener.volume = value;
        }
    }
}