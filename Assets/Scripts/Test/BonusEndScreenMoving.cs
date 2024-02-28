using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BonusEndScreenMoving : MonoBehaviour
{
    [SerializeField] private Transform _parentLine;
    [Range(0, 1)] [SerializeField] private float _value;
    
    private List<Transform> _line;
    private int _countLine;

    void Start()
    {
        _line = new List<Transform>();

        RefreshLine3();
        _value = 0;
        StartCoroutine(PlusValue());
    }
    
    void RefreshLine3()
    {
        _parentLine.GetComponentsInChildren<Transform>(_line);
        _countLine = _line.Count;
    }
    
    private void LerpPosition(List<Transform> lines,Transform objectMove)
    {
        List<Vector3> list = new List<Vector3>(); 
        
        for (int i = 1; i < _line.Count - 1; i++)
        {
            list.Add(Vector3.Lerp(lines[i].position, lines[i + 1].position, _value));
        }

        LerpNext(list,objectMove);
    }

    private void LerpNext(List<Vector3> listStart,Transform objectMove)
    {
        if (listStart.Count > 2)
        {
            List<Vector3> list = new List<Vector3>();

            for (int i = 0; i < listStart.Count - 1; i++)
            {
                list.Add(Vector3.Lerp(listStart[i], listStart[i + 1], _value));
            }

            LerpNext(list,objectMove);
        }
        else
        {
            objectMove.position = Vector3.Lerp(listStart[0], listStart[1], _value);
        }
    }
    
    IEnumerator PlusValue()
    {
        while (_value <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            _value += 0.01f;
            Move();
        }
gameObject.SetActive(false);
        // StartCoroutine(MinusValue());
    }

    /*IEnumerator MinusValue()
    {
        while (_value >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            _value -= 0.01f;
            Move();
        }

        StartCoroutine(PlusValue());
    }*/

    void Move()
    {
        if (_countLine != _parentLine.childCount)
        {
            Debug.Log("Refresh");
            RefreshLine3();
        }
        
        LerpPosition(_line, transform);
    }
}
