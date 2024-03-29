using System.Collections;
using GameScene;
using Statistics;
using UI.Buttons.EndScreenButtons;
using UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace ADS
{
    [RequireComponent(typeof(Button))]
    public class RewardRevive : RewardVideo
    {
        [SerializeField] private ReviveButton _reviveButton;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private BrickCounter _brickCounter;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private Coroutine _coroutine;

        protected override void OnReward()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Revive());
        }

        protected override void OnClose()
        {
            base.OnClose();
            _reviveButton.GetComponent<Button>().interactable = true;
        }

        private IEnumerator Revive()
        {
            _reviveScreen.ChooseRevive();
            yield return _waitForSeconds;
            _sceneLoader.RevivePlatform();
            _brickCounter.CheckAliveBrickCount();
        }
    }
}