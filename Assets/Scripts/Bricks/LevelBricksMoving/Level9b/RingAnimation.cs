using System.Collections;
using Others;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level9b
{
    public class RingAnimation : WorkChanger
    {
        [SerializeField] private AnimationsActivator _animationsActivator;

        private WaitForSeconds _startWait = new WaitForSeconds(1.5f);
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

        private void Start()
        {
            StartCoroutine(Play());
        }

        private IEnumerator Play()
        {
            yield return _startWait;

            while (IsWork)
            {
                _animationsActivator.RingOpen();
                yield return _waitForSeconds;
                _animationsActivator.RingClose();
                yield return _waitForSeconds;
            }
        }
    }
}