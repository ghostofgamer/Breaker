using System.Collections;
using GameScene.BallContent;
using Statistics;
using UI.Screens.EndScreens;
using UnityEngine;

namespace ModificationFiles
{
    public class AdditionalLaser : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private Effect _effect;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private BuffCounter _buffCounter;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(10f);
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _brickCounter.BricksDestructionHelp += SpawnLaser;
            _reviveScreen.Revive += SpawnLaser;
            _brickCounter.AllBrickDestory += StopCorutine;
            _ballTrigger.Dying += StopCorutine;
        }

        private void OnDisable()
        {
            _brickCounter.BricksDestructionHelp -= SpawnLaser;
            _brickCounter.AllBrickDestory -= StopCorutine;
            _reviveScreen.Revive -= SpawnLaser;
            _ballTrigger.Dying -= StopCorutine;
        }

        private void StopCorutine()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void SpawnLaser()
        {
            if (_brickCounter.BrickCount > _brickCounter.RemainingAmountHelp)
                return;
        
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(StartSpawnlaser());
        }

        private IEnumerator StartSpawnlaser()
        {
            while (true)
            {
                Instantiate(_effect, transform);
                _buffCounter.IncreaseBuffCount();
                yield return _waitForSeconds;
            }
        }
    }
}