using System.Collections;
using System.Collections.Generic;
using GameScene.BallContent;
using UnityEngine;

public class ElectricBallActivator : MonoBehaviour
{
    [SerializeField] private BallTrigger _ballTrigger;
    [SerializeField] private ElectricBall _electricBall;

    private float _bonusChances = 30;
    private float _randomValue;

    private void OnEnable()
    {
        _ballTrigger.Bounce += TryActivatedElectricEffect;
    }

    private void OnDisable()
    {
        _ballTrigger.Bounce -= TryActivatedElectricEffect;
    }

    private void TryActivatedElectricEffect()
    {
        _randomValue = Random.Range(0, 100f);

        if (_randomValue > _bonusChances)
        {
            Activator(false);
            return;
        }
        
 Activator(true);
        // if (_randomValue < _bonusChances)
        // {
        //    
        // }
    }

    private void Activator(bool flag)
    {
        _electricBall.gameObject.SetActive(flag);
    }
}