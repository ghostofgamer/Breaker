using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bonus
{
    public class BonusDeath : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effectDie;
        [SerializeField] private GameObject _bonusFly;
        [SerializeField] private TMP_Text _bonusCountTxt;

        private int _minValue = 1;
        private int _maxValue = 3;
        
        public int Reward { get; private set; }
    
        private void Start()
        {
            Reward = Random.Range(_minValue, _maxValue);
            _bonusCountTxt.text = Reward.ToString();
        }

        public void Die()
        {
            _effectDie.transform.parent = null;
            _effectDie.Play();
            BonusFlying();
            gameObject.SetActive(false);
        }

        private void BonusFlying()
        {
            _bonusFly.transform.parent = null;
            _bonusFly.transform.position = transform.position;
            _bonusFly.SetActive(true);
        }
    }
}