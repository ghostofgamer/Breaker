using System.Collections;
using UnityEngine;

namespace PlayerFiles
{
    public class SlowMo : MonoBehaviour
    {
        private float _slowMove = 0.35f;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);

        public void DisableSlowMoEffect()
        {
            Time.timeScale = 1f;
        }

        public void EnableSlowMotionEffect()
        {
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
