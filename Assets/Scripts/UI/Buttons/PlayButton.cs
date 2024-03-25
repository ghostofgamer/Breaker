using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class PlayButton : AbstractButton
    {
        private const string SceneName = "ChooseLvlScene";

        [SerializeField] private WaveMotion _waveMotion;
        [SerializeField] private CanvasAnimator _canvasAnimator;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private WaitForSeconds _waitForAnimation = new WaitForSeconds(0.16f);

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            StartCoroutine(BricksMove());
        }

        private IEnumerator BricksMove()
        {
            _canvasAnimator.Close();
            yield return _waitForAnimation;
            _waveMotion.FlyBackAllCubes();
            yield return _waitForSeconds;
            SceneManager.LoadScene(SceneName);
        }
    }
}