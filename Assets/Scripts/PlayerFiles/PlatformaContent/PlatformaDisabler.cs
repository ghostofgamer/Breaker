using GameScene.BallContent;
using Statistics;
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    [RequireComponent(typeof(PlatformaMovement))]
    public class PlatformaDisabler : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private ParticleSystem _victoryEffect;
        [SerializeField] private ParticleSystem _loseEffect;
        [SerializeField] private GameObject _mousePosition;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private Transform _environment;

        private PlatformaMovement _platformaMovement;

        private void Start()
        {
            _platformaMovement = GetComponent<PlatformaMovement>();
        }

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnVictoriousDestruction;
            _ballTrigger.Dying += OnLosingDestruction;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnVictoriousDestruction;
            _ballTrigger.Dying -= OnLosingDestruction;
        }

        private void OnVictoriousDestruction()
        {
            SetValue(_victoryEffect);
            transform.parent = _environment;
            _platformaMovement.SetValue(false);
        }

        private void OnLosingDestruction()
        {
            SetValue(_loseEffect);
            _platformaMovement.SetValue(false);
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