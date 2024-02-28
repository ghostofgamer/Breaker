using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEZIE : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private Transform _object1;
    [SerializeField] private Transform _object2;
    [SerializeField] private Transform[] _objects;

    [SerializeField] private Transform _parentLine;
    [SerializeField] private Transform _parentLine1;
    [SerializeField] private Transform _parentLine2;

    [SerializeField] private Transform[] _parentLines;

    [Range(0, 1)] [SerializeField] private float _value;

    private List<Transform> _line;
    private List<Transform> _line1;
    private List<Transform> _line2;

    private List<Transform>[] _lines;

    // private int _bonusCount = 6;

    /*private int _countLine;
    private int _countLine1;
    private int _countLine2;*/

    void Start()
    {
        _lines = new List<Transform>[_parentLines.Length];
        
        for (int i = 0; i < _lines.Length; i++)
        {
            _lines[i]= new List<Transform>();
        }
        
        _line = new List<Transform>();
        _line1 = new List<Transform>();
        _line2 = new List<Transform>();

        RefreshLine3();
        _value = 0;
        StartCoroutine(PlusValue());
    }

    void RefreshLine3()
    {
        for (int i = 0; i < _parentLines.Length; i++)
        {
            _parentLines[i].GetComponentsInChildren<Transform>(_lines[i]);
        }
        // parentLine.GetComponentsInChildren<Transform>(line);
        // count = line.Count;
        //
        
        
        
        
        _parentLine.GetComponentsInChildren<Transform>(_line);
        // _countLine = _line.Count;

        _parentLine1.GetComponentsInChildren<Transform>(_line1);
        // _countLine1 = _line1.Count;
        
        _parentLine2.GetComponentsInChildren<Transform>(_line2);
        // _countLine2 = _line2.Count;
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

    /*void LerpLine3()
    {
        List<Vector3> list = new List<Vector3>();

        for (int i = 1; i < _line.Count - 1; i++)
        {
            list.Add(Vector3.Lerp(_line[i].position, _line[i + 1].position, _value));
        }

        Lerp2Line3(list);
    }

    void Lerp2Line3(List<Vector3> list2)
    {
        if (list2.Count > 2)
        {
            List<Vector3> list = new List<Vector3>();

            for (int i = 0; i < list2.Count - 1; i++)
            {
                list.Add(Vector3.Lerp(list2[i], list2[i + 1], _value));
            }

            Lerp2Line3(list);
        }
        else
        {
            _object.position = Vector3.Lerp(list2[0], list2[1], _value);
        }
    }*/

    IEnumerator PlusValue()
    {
        while (_value <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            _value += 0.01f;
            Move();
        }

        StartCoroutine(MinusValue());
    }

    IEnumerator MinusValue()
    {
        while (_value >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            _value -= 0.01f;
            Move();
        }

        StartCoroutine(PlusValue());
    }

    void Move()
    {
        /*if (_parentLine.childCount != _countLine - 1||_parentLine1.childCount != _countLine1 - 1||_parentLine2.childCount != _countLine2 - 1)
        {
            RefreshLine3();
        }*/

        for (int i = 0; i < _lines.Length; i++)
        {
            LerpPosition(_lines[i], _objects[i]);
        }

        /*LerpPosition(_line, _object);
        LerpPosition(_line1, _object1);
        LerpPosition(_line2, _object2);*/
    }
}