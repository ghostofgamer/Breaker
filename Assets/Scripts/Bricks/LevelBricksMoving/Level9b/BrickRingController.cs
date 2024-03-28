using System.Collections;
using Others;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level9b
{
    public class BrickRingController : MotionController
    {
        [SerializeField] private AnimationsController _animationsController;

        private WaitForSeconds _startWait = new WaitForSeconds(1.5f);
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
        
        private void Start()
        {
            StartCoroutine(PlayAnimation());
        }

        private IEnumerator PlayAnimation()
        {
            yield return _startWait;

            while (IsWork)
            {
                _animationsController.RingOpen();
                yield return _waitForSeconds;
                _animationsController.RingClose();
                yield return _waitForSeconds;
            }
        }
    }
}