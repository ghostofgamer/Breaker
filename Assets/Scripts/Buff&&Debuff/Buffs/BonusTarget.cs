using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusTarget : Modification
{
    [SerializeField] private Transform _bricks;
    [SerializeField] private Material _newMaterial;
    [SerializeField] private Effect[] _effects;

    private List<Transform> _filtredBrick;
    private int _randomIndex;
    private int _randomEffectIndex;
    private Effect _startEffect;
    private Material _startMaterial;

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            StartCoroutine(OnBonusTargetActivated());
        }
    }

    private IEnumerator OnBonusTargetActivated()
    {
        List<Transform> bricksList = new List<Transform>();

        for (int i = 0; i < _bricks.childCount; i++)
            bricksList.Add(_bricks.GetChild(i));

        _filtredBrick = bricksList.Where(p =>
            p.gameObject.activeSelf == true && p.gameObject.GetComponent<Brick>().IsImmortalFlag == false).ToList();

        if (_filtredBrick.Count > 0)
        {
            Change();
            yield return WaitForSeconds;
            Reset();
            Player.DeleteEffect(this);
        }
    }

    public override void StopModification()
    {
        Reset();
    }

    private void Change()
    {
        SetActive(true);
        _randomIndex = GetRandomIndex(_filtredBrick.Count);
        _randomEffectIndex = GetRandomIndex(_effects.Length);
        _startMaterial = _filtredBrick[_randomIndex].GetComponent<Renderer>().material;
        _startEffect = _filtredBrick[_randomIndex].GetComponent<BrickDestroy>().EffectElement;
        _filtredBrick[_randomIndex].GetComponent<BrickDestroy>().SetEffect(_effects[_randomEffectIndex]);
        _filtredBrick[_randomIndex].GetComponent<Renderer>().material = _newMaterial;
    }

    private int GetRandomIndex(int count)
    {
        var random = new System.Random();
        return random.Next(count);
    }

    private void Reset()
    {
        SetActive(false);
        _filtredBrick[_randomIndex].GetComponent<BrickDestroy>().SetEffect(_startEffect);
        _filtredBrick[_randomIndex].GetComponent<Renderer>().material = _startMaterial;
    }
}