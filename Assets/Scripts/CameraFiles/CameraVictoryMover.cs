using System.Collections;
using Others;
using Statistics;
using UI.Screens.EndScreens;
using UnityEngine;

namespace CameraFiles
{
    public class CameraVictoryMover : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private AnimationsActivator _animationsActivator;
        [SerializeField] private Animator _animator;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnMove;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnMove;
        }

        private void OnMove()
        {
            if (_reviveScreen.IsLose)
                return;

            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            _animator.enabled = true;
            yield return _waitForSeconds;
            _animationsActivator.PlayVictory();
        }
    }
}