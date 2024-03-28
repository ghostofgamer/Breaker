using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FadeStatistics : MonoBehaviour
    {
        [SerializeField] private Image _backGroundImage;
        [SerializeField] private TMP_Text _textLabel;
        [SerializeField] private float _alpha;

        private float _elapsedTime;
        private float _duration = 0.365f;
        private Color _startBackGroundColor;
        private Color _startTextColor;
        private Color _endBackGroundColor;
        private Color _endTextColor;

        private void OnEnable()
        {
            StartCoroutine(OnFadeStatistic());
        }

        private IEnumerator OnFadeStatistic()
        {
            _elapsedTime = 0;
            _startBackGroundColor = _backGroundImage.color;
            _startTextColor = _textLabel.color;
            _endBackGroundColor =
                new Color(_startBackGroundColor.r, _startBackGroundColor.g, _startBackGroundColor.b, 0f);
            _endTextColor = new Color(_startTextColor.r, _startTextColor.g, _startTextColor.b, _alpha);

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                _backGroundImage.color =
                    Color.Lerp(_startBackGroundColor, _endBackGroundColor, _elapsedTime / _duration);
                _textLabel.color = Color.Lerp(_startTextColor, _endTextColor, _elapsedTime / _duration);
                yield return null;
            }

            _backGroundImage.color = _endBackGroundColor;
        }
    }
}