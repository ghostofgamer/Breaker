using Statistics;
using UnityEngine;

namespace ModificationFiles
{
    public class BuffDistributor : MonoBehaviour
    {
        [SerializeField] private Effect[] _effects;
        [SerializeField] private BuffCounter _buffCounter;

        private float _randomProcent = 0.3f;
        private bool _isEffect = false;

        public Effect AssignEffect()
        {
            _isEffect = Random.value < _randomProcent;

            if (_isEffect)
            {
                int index = Random.Range(0, _effects.Length);

                if (_effects[index].GetComponent<Buff>())
                    _buffCounter.IncreaseBuffCount();

                return _effects[index];
            }

            return null;
        }
    }
}