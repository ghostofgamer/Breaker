using System.Collections;
using GameScene;
using Statistics;
using UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace ADS
{
    public class RewardRevive : RewardVideo
    {
        [SerializeField] private Reviver _reviver;
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private Button _button;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        protected override void OnReward()
        {
            StartCoroutine(Revive());
        }

        protected override void OnClose()
        {
            base.OnClose();
            _button.interactable = true;
        }

        private IEnumerator Revive()
        {
            yield return _waitForSeconds;
            _reviver.RevivePlatform();
            _brickCounter.CheckAliveBrickCount();
        }
    }
}