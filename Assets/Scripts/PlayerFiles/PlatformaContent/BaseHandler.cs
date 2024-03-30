using GameScene.BallContent;
using Statistics;
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    [RequireComponent(typeof(BaseMovement))]
    public class BaseHandler : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private ParticleSystem _victoryEffect;
        [SerializeField] private ParticleSystem _loseEffect;
        [SerializeField] private GameObject _mousePosition;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private Transform _environment;

        private BaseMovement _baseMovement;

        private void Start()
        {
            _baseMovement = GetComponent<BaseMovement>();
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
            BaseDeactivation(_victoryEffect);
            transform.parent = _environment;
            _baseMovement.Die();
        }

        private void OnLosingDestruction()
        {
            BaseDeactivation(_loseEffect);
            _baseMovement.Die();
        }

        private void BaseDeactivation(ParticleSystem effect)
        {
            effect.transform.parent = null;
            effect.Play();
            gameObject.SetActive(false);
            _mousePosition.SetActive(false);
        }
    }
}