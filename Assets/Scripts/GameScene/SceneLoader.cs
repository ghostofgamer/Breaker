using System.Collections;
using Bricks;
using GameScene.BallContent;
using ModificationFiles;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace GameScene
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private BrickActivator[] _bricksActivator;
        [SerializeField] private ParticleSystem _startEffect;
        [SerializeField] private PlatformaMovement _platformaMovement;
        [SerializeField] private BallRevive _ballRevive;
        [SerializeField] private float _duration = 0.05f;
        [SerializeField] private NameEffectAnimation _getReadyAnimation;

        private WaitForSeconds _waitForSeconds;
        private WaitForSeconds _waitForSpawnPlatform = new WaitForSeconds(1f);

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_duration);
            StartCoroutine(SetActive());
        }

        public void ShowActivation()
        {
            _startEffect.Play();
            _getReadyAnimation.Show();
        }

        private IEnumerator SetActive()
        {
            foreach (var brick in _bricksActivator)
            {
                yield return _waitForSeconds;
                brick.Activate();
            }

            yield return _waitForSeconds;
            ShowActivation();
            yield return _waitForSpawnPlatform;
            _platformaMovement.gameObject.SetActive(true);
            _platformaMovement.SetValue(true);
            _ballRevive.gameObject.SetActive(true);
        }
    }
}