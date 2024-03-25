using GameScene.BallContent;
using Statistics;
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class PlatformaDestroyer : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private ParticleSystem _victoryEffect;
        [SerializeField] private ParticleSystem _loseEffect;
        [SerializeField] private GameObject _mousePosition;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private Transform _enviropment;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroy += OnVictoriousDestruction;
            _ballTrigger.Dying += OnLosingDestruction;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= OnVictoriousDestruction;
            _ballTrigger.Dying -= OnLosingDestruction;
        }

        private void OnVictoriousDestruction()
        {
            SetValue(_victoryEffect);
            transform.parent = _enviropment;
        }

        private void OnLosingDestruction()
        {
            SetValue(_loseEffect);
        }

        private void SetValue(ParticleSystem effect)
        {
            effect.transform.parent = null;
            effect.Play();
            gameObject.SetActive(false);
            _mousePosition.SetActive(false);
        }
    }
}