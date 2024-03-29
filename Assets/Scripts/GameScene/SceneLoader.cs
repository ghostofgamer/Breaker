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
        [SerializeField] private PlatformaMover _platformaMover;
        [SerializeField] private PlatformaRevive _platformaRevive;
        [SerializeField] private BallRevive _ballRevive;
        [SerializeField] private float _duration = 0.05f;
        [SerializeField] private NameEffectAnimation _getReadyAnimation;
        [SerializeField] private NameEffectAnimation _reviveAnimation;

        private WaitForSeconds _waitForSeconds;
        private WaitForSeconds _waitForSpawnPlatform = new WaitForSeconds(1f);

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_duration);
            StartCoroutine(SetActive());
        }

        public void RevivePlatform()
        {
            StartCoroutine(ComeLife());
        }

        private IEnumerator SetActive()
        {
            foreach (var brick in _bricksActivator)
            {
                yield return _waitForSeconds;
                brick.Activate();
            }

            yield return _waitForSeconds;
            _startEffect.Play();
            _getReadyAnimation.Show();
            yield return _waitForSpawnPlatform;
            _platformaMover.gameObject.SetActive(true);
            _platformaMover.SetValue(true);
            _ballRevive.gameObject.SetActive(true);
        }

        private IEnumerator ComeLife()
        {
            _reviveAnimation.Show();
            yield return _waitForSpawnPlatform;
            _startEffect.Play();
            _getReadyAnimation.Show();
            yield return _waitForSpawnPlatform;
            _platformaRevive.GetLife();
            _ballRevive.Revive();
        }
    }
}