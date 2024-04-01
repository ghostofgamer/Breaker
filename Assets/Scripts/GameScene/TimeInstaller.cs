using UI;
using UnityEngine;

namespace GameScene
{
    public class TimeInstaller : MonoBehaviour
    {
        [SerializeField] private CountDown _countDown;

        private int _activeValue = 1;

        private void OnEnable()
        {
            _countDown.TimeActivated += OnActivationTime;
        }

        private void OnDisable()
        {
            _countDown.TimeActivated -= OnActivationTime;
        }

        private void OnActivationTime()
        {
            Time.timeScale = _activeValue;
        }
    }
}