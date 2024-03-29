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
        [SerializeField] protected PlatformaMover PlatformaMover;
        [SerializeField] protected BallMover BallMover;
        [SerializeField] protected Player Player;
        [SerializeField] protected float Duration;
        [SerializeField] protected NameEffectAnimation NameEffect;

        [SerializeField] private Load _load;
        [SerializeField] private bool _isImproving;
        [SerializeField] private BuffUIFade _buffUI;
        [SerializeField] private BuffType _buffType;

        protected Coroutine Coroutine;
        protected WaitForSeconds WaitForSeconds;

        private int _startIndex = 0;
        private float _factor = 1.5f;

        private void Awake()
        {
            if (_isImproving)
            {
                int number = _load.Get(_buffType.ToString(), _startIndex);

                if (number > _startIndex)
                {
                    Duration *= _factor;
                }
            }

            if (_buffUI != null)
                _buffUI.Init(Duration);
        }

        protected virtual void Start()
        {
            WaitForSeconds = new WaitForSeconds(Duration);
        }

        public abstract void OnApplyModification();

        public abstract void StopModification();

        protected void SetActive(bool isActive)
        {
            _buffUI.gameObject.SetActive(isActive);
        }

        protected void ShowNameEffect()
        {
            NameEffect.Show();
        }
    }
}