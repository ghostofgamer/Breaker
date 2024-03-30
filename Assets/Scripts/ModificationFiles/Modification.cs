using Enum;
using GameScene.BallContent;
using PlayerFiles;
using PlayerFiles.PlatformaContent;
using SaveAndLoad;
using UnityEngine;

namespace ModificationFiles
{
    public abstract class Modification : MonoBehaviour
    {
        [SerializeField] private BaseMovement _baseMovement;
        [SerializeField] private BallMover _ballMover;
        [SerializeField] private Player _player;
        [SerializeField] private float _duration;
        [SerializeField] private NameEffectAnimation _nameEffect;
        [SerializeField] private Load _load;
        [SerializeField] private bool _isImproving;
        [SerializeField] private BuffUIFade _buffUI;
        [SerializeField] private BuffType _buffType;

        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;

        private int _startIndex = 0;
        private float _factor = 1.5f;

        protected WaitForSeconds WaitForSeconds => _waitForSeconds;
        
        protected Coroutine Coroutine => _coroutine;
        
        protected Player Player => _player;

        protected float Duration => _duration;

        protected BallMover BallMover => _ballMover;

        protected BaseMovement BaseMovement => _baseMovement;

        protected virtual void Awake()
        {
            if (_isImproving)
            {
                int number = _load.Get(_buffType.ToString(), _startIndex);

                if (number > _startIndex)
                {
                    _duration *= _factor;
                }
            }

            if (_buffUI != null)
                _buffUI.Init(Duration);
        }

        protected virtual void Start()
        {
            SetValue(Duration);
        }

        public abstract void OnApplyModification();

        public abstract void StopModification();

        protected void SetActive(bool isActive)
        {
            _buffUI.gameObject.SetActive(isActive);
        }

        protected void EnableBuffUI()
        {
            _buffUI.gameObject.SetActive(true);
        }

        protected void DisableBuffUI()
        {
            _buffUI.gameObject.SetActive(false);
        }
        
        protected void ShowNameEffect()
        {
            _nameEffect.Show();
        }

        protected void SetValue(float value)
        {
            _waitForSeconds = new WaitForSeconds(value);
        }
        
        protected void SetCoroutine(Coroutine coroutine)
        {
            _coroutine = coroutine;
        }
    }
}