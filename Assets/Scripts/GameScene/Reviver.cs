using System.Collections;
using GameScene.BallContent;
using ModificationFiles;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace GameScene
{
    public class Reviver : MonoBehaviour
    {
        [SerializeField] private BaseRevive _baseRevive;
        [SerializeField] private NameEffectAnimation _reviveAnimation;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private BallRevive _ballRevive;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        public void RevivePlatform()
        {
            StartCoroutine(ComeLife());
        }

        private IEnumerator ComeLife()
        {
            _reviveAnimation.Show();
            yield return _waitForSeconds;
            _sceneLoader.ShowActivation();
            yield return _waitForSeconds;
            _baseRevive.gameObject.SetActive(true);
            _baseRevive.RespawnWithExtraLife();
            _ballRevive.Revive();
        }
    }
}