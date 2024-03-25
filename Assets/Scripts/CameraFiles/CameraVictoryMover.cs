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
        [SerializeField] private AnimationsController _animationsController;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroy += Move;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= Move;
        }

        private void Move()
        {
            if (_reviveScreen.IsLose)
                return;

            StartCoroutine(OnMove());
        }

        private IEnumerator OnMove()
        {
            yield return _waitForSeconds;
            _animationsController.PlayVictory();
        }
    }
}