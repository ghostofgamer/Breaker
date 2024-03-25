using System.Collections;
using UnityEngine;

namespace Bricks
{
    public class ShaderChanger : MonoBehaviour
    {
        private const string RimPower = "_RimPower";
        private static readonly int Power = Shader.PropertyToID(RimPower);

        [SerializeField] private Material _material;

        private float _duration = 3;
        private float _elapsedTime;
        private float _maxValue = 5f;
        private float _minValue = 0f;

        private void Start()
        {
            StartCoroutine(ChangeValue());
        }

        private IEnumerator ChangeValue()
        {
            _material.SetFloat(Power, _maxValue);
            float value = _material.GetFloat(Power);

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                float newValue = Mathf.Lerp(value, _minValue, _elapsedTime / _duration);
                _material.SetFloat(Power, newValue);
                yield return null;
            }

            _material.SetFloat(Power, _minValue);
        }
    }
}