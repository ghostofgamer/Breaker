using System.Collections;
using UI.Screens;
using UnityEngine;

namespace PlayerFiles
{
    public class SlowMotionEffect : MonoBehaviour
    {
        [SerializeField]private SettingsScreen _settingsScreen;

        private float _slowMove = 0.35f;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);

        public void DisableSlowMoEffect()
        {
            if (_settingsScreen.IsOpen)
                return;

            Time.timeScale = 1f;
        }

        public void EnableSlowMotionEffect()
        {
            if (_settingsScreen.IsOpen)
                return;

            StartCoroutine(TimeScaleChanged());
        }

        private IEnumerator TimeScaleChanged()
        {
            Time.timeScale = _slowMove;
            yield return _waitForSeconds;

            while (Time.timeScale < 1f)
                Time.timeScale += Time.deltaTime;
        }
    }
}
