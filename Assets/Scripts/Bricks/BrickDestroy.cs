using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickDestroy : MonoBehaviour
{
    [SerializeField] private GameObject particleEffectPrefab;
    [SerializeField] private Effect _effect;
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private bool _isBonus;
    
    private float _bonusRadius = 1.65f;
    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.TryGetComponent(out TestBall testBall))
        {
            gameObject.SetActive(false);
        }*/
        if (other.gameObject.TryGetComponent(out BallController chatHelp))
        {
            // Debug.Log("GameObject");
            // gameObject.SetActive(false);
        }
    }

    public void Destroy()
    {
        particleEffectPrefab.SetActive(true);
        particleEffectPrefab.transform.parent = null;
        /*_effect.transform.parent = null;
        _effect.gameObject.SetActive(true);*/
        if (_effect != null)
            Instantiate(_effect, transform.position, Quaternion.identity);

        GetBonus();
        
        gameObject.SetActive(false);
    }

    private void GetBonus()
    {
        if (!_isBonus)
            return;

        int amount = Random.Range(1, 5);
        
        for (int i = 0; i < amount; i++)
        {
            // Вычисляем угол для распределения бонусов вокруг центра куба
            float angle = i * Mathf.PI * 2 / amount;
            // Вычисляем позицию для каждого бонуса
            float x = transform.position.x + Mathf.Cos(angle) * _bonusRadius;
            float z = transform.position.z + Mathf.Sin(angle) * _bonusRadius;
            Vector3 bonusPosition = new Vector3(x, transform.position.y, z);

            // Создаем бонус на заданной позиции
            Instantiate(_bonusPrefab, bonusPosition, Quaternion.identity);
        }
        /*for (int i = 0; i < amount; i++)
        {
            StartCoroutine(SpawnBonuses(amount));
        }*/
    }

    private IEnumerator SpawnBonuses(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(_bonusPrefab, transform.position, Quaternion.identity);
            yield return  new WaitForSeconds(0.1f);
        }
    }

}