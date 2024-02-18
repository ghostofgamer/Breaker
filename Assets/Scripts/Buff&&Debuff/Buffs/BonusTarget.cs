using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusTarget : MonoBehaviour
{
    [SerializeField] private Transform _bricks;
    [SerializeField] protected BuffType _buffType;
    [SerializeField] private Material _newMaterial;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public void BonusTargetActivated(PlatformaMover platformMover)
    {
        if (platformMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnBonusTargetActivated(platformMover));
    }

    private IEnumerator OnBonusTargetActivated(PlatformaMover platformMover)
    {
        List<Transform> _bricksList = new List<Transform>();
        int randomIndex = 0;
        
        for (int i = 0; i < _bricks.childCount; i++)
        {
            _bricksList.Add(_bricks.GetChild(i));
        }

        List<Transform> filtredBrick = _bricksList.Where(p => p.gameObject.activeSelf == true).ToList();

        if (filtredBrick.Count > 0)
        {
            var random = new System.Random();
            randomIndex = random.Next(filtredBrick.Count);
            Material originalmaterial = filtredBrick[randomIndex].GetComponent<Renderer>().material;
            filtredBrick[randomIndex].GetComponent<Renderer>().material = _newMaterial;
            yield return _waitForSeconds;
            filtredBrick[randomIndex].GetComponent<Renderer>().material = originalmaterial;
            platformMover.GetComponent<Platforma>().DeleteEffect(_buffType);
        }
    }
}