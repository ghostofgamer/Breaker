using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusTarget : Modification
{
    [SerializeField] private Transform _bricks;
    [SerializeField] private Material _newMaterial;
    [SerializeField] private Effect[] _effects;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(15f);
    private List<Transform> filtredBrick;
    private int _randomIndex;
    private Effect _startEffect;
    private Material _startMaterial;
    
    public override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(this))
            StartCoroutine(OnBonusTargetActivated());
    }

    /*public void BonusTargetActivated(PlatformaMover platformMover)
    {
        if (platformMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnBonusTargetActivated(platformMover));
    }*/

    private IEnumerator OnBonusTargetActivated()
    {
        List<Transform> _bricksList = new List<Transform>();

        for (int i = 0; i < _bricks.childCount; i++)
            _bricksList.Add(_bricks.GetChild(i));

        filtredBrick = _bricksList.Where(p => p.gameObject.activeSelf == true).ToList();

        if (filtredBrick.Count > 0)
        {
            Change();
            yield return _waitForSeconds;
            Reset(Player);
        }
    }

    public override void StopModification(Player player)
    {
        Reset(Player);
    }

    private void Change()
    {
        var random = new System.Random();
        _randomIndex = random.Next(filtredBrick.Count);
        int randomEffect = random.Next(_effects.Length);
        _startMaterial = filtredBrick[_randomIndex].GetComponent<Renderer>().material;
        _startEffect = filtredBrick[_randomIndex].GetComponent<BrickDestroy>().Effect;
        filtredBrick[_randomIndex].GetComponent<BrickDestroy>().SetEffect(_effects[randomEffect]);
        filtredBrick[_randomIndex].GetComponent<Renderer>().material = _newMaterial;
    }

    private void Reset(Player player)
    {
        filtredBrick[_randomIndex].GetComponent<BrickDestroy>().SetEffect(_startEffect);
        filtredBrick[_randomIndex].GetComponent<Renderer>().material = _startMaterial;
        player.DeleteEffect(this);
        Debug.Log("выкл");
    }
}