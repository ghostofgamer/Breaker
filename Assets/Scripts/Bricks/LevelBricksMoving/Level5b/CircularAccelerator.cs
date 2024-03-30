using System.Collections;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level5b
{
    [RequireComponent(typeof(AccelerateRotate), typeof(DecelerateStop))]
    public class CircularAccelerator : WorkChanger
    {
        [SerializeField] private GameObject[] _objects;
        [SerializeField] private float _rotationTime = 6f;
        [SerializeField] private float _delayBetweenObjects = 1.65f;

        private WaitForSeconds _delay;
        private WaitForSeconds _delayRotaion;
        private AccelerateRotate[] _accelerateRotateComponents;
                                    private DecelerateStop[] _decelerateStopComponents;
                            
                                    private void Start()
        {
            _delay = new WaitForSeconds(_delayBetweenObjects);
            _delayRotaion = new WaitForSeconds(_rotationTime);
            _accelerateRotateComponents = new AccelerateRotate[_objects.Length];
            _decelerateStopComponents = new DecelerateStop[_objects.Length];

            for (int i = 0; i < _objects.Length; i++)
            {
                _accelerateRotateComponents[i] = _objects[i].GetComponent<AccelerateRotate>();
                _decelerateStopComponents[i] = _objects[i].GetComponent<DecelerateStop>();
            }

            StartCoroutine(RotateObjects());
        }

        private IEnumerator RotateObjects()
        {
            while (IsWork)
            {
                yield return _delay;

                for (int i = 0; i < _objects.Length; i++)
                {
                    _accelerateRotateComponents[i].StartRotation();
                    yield return _delay;
                }

                yield return _delayRotaion;

                for (int i = _objects.Length - 1; i >= 0; i--)
                {
                    _accelerateRotateComponents[i].StopRotation();
                    _decelerateStopComponents[i].StartDeceleration(_accelerateRotateComponents[i].MaxSpeed);
                    yield return _delay;
                }
            }
        }
    }
}