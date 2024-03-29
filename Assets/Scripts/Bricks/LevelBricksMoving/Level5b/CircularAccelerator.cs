using System.Collections;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level5b
{
    [RequireComponent(typeof(AccelerateRotate), typeof(DecelerateStop))]
    public class CircularAccelerator : MotionController
    {
        [SerializeField] private GameObject[] _objects;
        [SerializeField] private float _rotationTime = 6f;
        [SerializeField] private float _delayBetweenObjects = 1.65f;

        private WaitForSeconds _delay;
        private WaitForSeconds _delayRotaion;

        private void Start()
        {
            _delay = new WaitForSeconds(_delayBetweenObjects);
            _delayRotaion = new WaitForSeconds(_rotationTime);
            StartCoroutine(RotateObjects());
        }

        private IEnumerator RotateObjects()
        {
            while (IsWork)
            {
                yield return _delay;

                for (int i = 0; i < _objects.Length; i++)
                {
                    _objects[i].GetComponent<AccelerateRotate>().StartRotation();
                    yield return _delay;
                }

                yield return _delayRotaion;

                for (int i = _objects.Length - 1; i >= 0; i--)
                {
                    _objects[i].GetComponent<AccelerateRotate>().StopRotation();
                    _objects[i].GetComponent<DecelerateStop>()
                        .StartDeceleration(_objects[i].GetComponent<AccelerateRotate>().MaxSpeed);

                    yield return _delay;
                }
            }
        }
    }
}