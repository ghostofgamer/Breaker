using System.Collections;
using Others;
using Statistics;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level9b
{
    public class BrickRingController : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private AnimationsController _animationsController;

        private WaitForSeconds _starWait = new WaitForSeconds(1.5f);
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
        private bool _isWork = true;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroy += Stop;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= Stop;
        }

        private void Start()
        {
            StartCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            yield return _starWait;

            while (_isWork)
            {
                _animationsController.RingOpen();
                yield return _waitForSeconds;
                _animationsController.RingClose();
                yield return _waitForSeconds;
            }
        }

        private void Stop()
        {
            _isWork = false;
        }
    }
}