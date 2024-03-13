using System.Collections;
using Bricks;
using GameScene.BallContent;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace GameScene
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Brick[] _bricks;
        [SerializeField]private ParticleSystem _startEffect;
        [SerializeField] private Platforma _platforma;
        [SerializeField] private Ball _ball;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.05f);
        private WaitForSeconds _waitForSpawnPlatform = new WaitForSeconds(1f);
    
        private void Start()
        {
            StartCoroutine(SetActive());
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
            yield return _waitForSpawnPlatform;
            _platforma.gameObject.SetActive(true);
            _ball.gameObject.SetActive(true);
        }

        public void RevivePlatform()
        {
            StartCoroutine(ComeLife());
        }
    
        private IEnumerator ComeLife()
        {
            _startEffect.Play();
            yield return _waitForSpawnPlatform;
            _platforma.GetComponent<PlatformaRevive>().Revive();
            _ball.GetComponent<BallRevive>().Revive();
        }
    }
}