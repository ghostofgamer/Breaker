using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Screens.EndScreens
{
    public class BonusEndScreenMoving : MonoBehaviour
    {
        [SerializeField] private Transform _parentLine;

        private float _value;
        private float _endValue = 1;
        private float _sumValue = 0.01f;
        private List<Transform> _line;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.01f);

        private void Start()
        {
            _line = new List<Transform>();
            _value = 0;
            RefreshLine();
            StartCoroutine(PlusValue());
        }

        private void RefreshLine()
        {
            _parentLine.GetComponentsInChildren<Transform>(_line);
        }

        private void LerpPosition(List<Transform> lines, Transform objectMove)
        {
            List<Vector3> list = new List<Vector3>();

            for (int i = 1; i < _line.Count - 1; i++)
            {
                list.Add(Vector3.Lerp(lines[i].position, lines[i + 1].position, _value));
            }

            LerpNext(list, objectMove);
        }

        private void LerpNext(List<Vector3> listStart, Transform objectMove)
        {
            if (listStart.Count > 2)
            {
                List<Vector3> list = new List<Vector3>();

                for (int i = 0; i < listStart.Count - 1; i++)
                {
                    list.Add(Vector3.Lerp(listStart[i], listStart[i + 1], _value));
                }

                LerpNext(list, objectMove);
            }
            else
            {
                objectMove.position = Vector3.Lerp(listStart[0], listStart[1], _value);
            }
        }

        private IEnumerator PlusValue()
        {
            while (_value <= _endValue)
            {
                yield return _waitForSeconds;
                _value += _sumValue;
                Move();
            }

            gameObject.SetActive(false);
        }

        private void Move()
        {
            LerpPosition(_line, transform);
        }
    }
}