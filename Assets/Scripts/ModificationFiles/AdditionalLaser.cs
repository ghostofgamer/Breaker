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
        private bool _isWork = true;
        
        private void OnEnable()
        {
            _brickCounter.BricksDestructionHelping += OnSpawnLaser;
            _reviveScreen.Reviving += OnSpawnLaser;
            _brickCounter.AllBrickDestroyed += OnSpawnOver;
            _ballTrigger.Dying += OnSpawnOver;
        }

        private void OnDisable()
        {
            _brickCounter.BricksDestructionHelping -= OnSpawnLaser;
            _brickCounter.AllBrickDestroyed -= OnSpawnOver;
            _reviveScreen.Reviving -= OnSpawnLaser;
            _ballTrigger.Dying -= OnSpawnOver;
        }

        private void OnSpawnOver()
        {
            _isWork = false;
            
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        private void OnSpawnLaser()
        {
            if (_brickCounter.BrickCount > _brickCounter.RemainingAmountHelp)
                return;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(StartSpawnLaser());
        }

        private IEnumerator StartSpawnLaser()
        {
            while (_isWork)
            {
                Instantiate(_effect, transform);
                _buffCounter.IncreaseBuffCount();
                yield return _waitForSeconds;
            }
        }
    }
}