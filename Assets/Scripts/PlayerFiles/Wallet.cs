using System;
using System.Collections;
using SaveAndLoad;
using TMPro;
using UnityEngine;

namespace PlayerFiles
{
    public class Wallet : MonoBehaviour
    {
        private const string MoneyValue = "Money";
        private const string TemporaryMoney = "TemporaryMoney";

        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;

        private int _startMoney = 0;
        private int _money;
        private int _temporaryMoney;
        private int _zero = 0;
        private float _elapsedTime;
        private float _duration = 1;
        private float _longDuration = 2;
        private Coroutine _coroutine;

        public event Action ValueChanged;

        public int Money => _money;

        private void Start()
        {
            _money = _load.Get(MoneyValue, _startMoney);
            _temporaryMoney = _load.Get(TemporaryMoney, _zero);
            ShowInfo();

            if (_temporaryMoney > _zero)
            {
                int target = _money + _temporaryMoney;
                Calculate(target, _longDuration);
                _save.SetData(TemporaryMoney, _zero);
            }
        }

        public void RemoveMoney(int price)
        {
            int target = _money - price;
            Calculate(target, _duration);
            ValueChanged?.Invoke();
        }

        private void ShowInfo()
        {
            _moneyText.text = _money.ToString();
        }

        private void SaveMoney()
        {
            _save.SetData(MoneyValue, _money);
        }

        private void Calculate(int target, float duration)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(RecalculateMoney(target, duration));
        }

        private IEnumerator RecalculateMoney(int target, float duration)
        {
            _elapsedTime = 0;
            int currentMoney = _money;

            while (_elapsedTime < duration)
            {
                _elapsedTime += Time.deltaTime;
                _money = (int) Mathf.Lerp(currentMoney, target, _elapsedTime / duration);
                ShowInfo();
                yield return null;
            }

            _money = target;
            SaveMoney();
            ShowInfo();
            ValueChanged?.Invoke();
        }
    }
}