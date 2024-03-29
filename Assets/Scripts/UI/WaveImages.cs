using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WaveImages : MonoBehaviour
    {
        [SerializeField] private Image[] _images;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _amplitude = 1f;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
        private bool _isWork = true;

        private void Start()
        {
            StartCoroutine(WaveMove());
        }

        public void StopWave()
        {
            _isWork = false;
        }

        private IEnumerator WaveMove()
        {
            while (_isWork)
            {
                for (int i = 0; i < _images.Length; i++)
                {
                    _images[i].rectTransform.anchoredPosition = new Vector2(
                        _images[i].rectTransform.anchoredPosition.x,
                        Mathf.Sin((Time.time * _speed) + i) * _amplitude);
                    yield return null;
                }

                yield return _waitForSeconds;
            }
        }
    }
}