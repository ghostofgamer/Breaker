using System.Collections;
using SaveAndLoad;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerFiles
{
    public class Wallet : MonoBehaviour
    {
        [Range(0, 50000)] [SerializeField] private int _startMoney;
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;

        private int _money;
        private int _temporaryMoney;
        private int _zero = 0;
        private float _elapsedTime;
        private float _duration = 1;
        private float _longDuration = 2;
        private Coroutine _coroutine;

        public event UnityAction ValueChanged;

        public int Money => _money;

        private void Start()
        {
            _money = _load.Get(Save.Money, _startMoney);
            _temporaryMoney = _load.Get(Save.TemporaryMoney, _zero);
            ShowInfo();

            if (_temporaryMoney > _zero)
            {
                int target = _money + _temporaryMoney;
                Calculate(target, _longDuration);
                _save.SetData(Save.TemporaryMoney, _zero);
            }
        }

        public void AddMoney(int credit)
        {
            int target = _money + credit;
            Calculate(target, _duration);
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
            _save.SetData(Save.Money, _money);
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