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
        [SerializeField] private Brick[] _bricks;
        [SerializeField] private ParticleSystem _startEffect;
        [SerializeField] private Platforma _platforma;
        [SerializeField] private Ball _ball;
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
            foreach (var brick in _bricks)
            {
                yield return _waitForSeconds;
                brick.GetComponent<BrickActivator>().Activate();
            }

            yield return _waitForSeconds;
            _startEffect.Play();
            _getReadyAnimation.Show();
            yield return _waitForSpawnPlatform;
            _platforma.gameObject.SetActive(true);
            _platforma.GetComponent<PlatformaMover>().SetValue(true);
            _ball.gameObject.SetActive(true);
        }

        private IEnumerator ComeLife()
        {
            _reviveAnimation.Show();
            yield return _waitForSpawnPlatform;
            _startEffect.Play();
            _getReadyAnimation.Show();
            yield return _waitForSpawnPlatform;
            _platforma.GetComponent<PlatformaRevive>().Revive();
            _ball.GetComponent<BallRevive>().Revive();
        }
    }
}