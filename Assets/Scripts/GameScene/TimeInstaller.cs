using UI;
using UnityEngine;

namespace GameScene
{
    public class TimeInstaller : MonoBehaviour
    {
        [SerializeField] private CountDown _countDown;

        private int _activeValue = 1;
        private int _unActiveValue = 0;

        private void OnEnable()
        {
            _countDown.TimeActivated += OnActivationTime;
        }

        private void OnDisable()
        {
            _countDown.TimeActivated -= OnActivationTime;
        }

        public void OffActivationTime()
        {
            Time.timeScale = _unActiveValue;
        }

        private void OnActivationTime()
        {
            Time.timeScale = _activeValue;
        }
    }
}