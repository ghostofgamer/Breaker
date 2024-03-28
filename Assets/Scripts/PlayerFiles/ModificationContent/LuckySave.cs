using System.Collections;
using GameScene;
using ModificationFiles;
using Statistics;
using UI.Buttons.Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class LuckySave : PlatformModification
    {
        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private NameEffectAnimation _nameEffectAnimation;
        [SerializeField] private SettingsButtonGameLevel _settingsButtonGameLevel;

        private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);
        private WaitForSecondsRealtime _waitForStart = new WaitForSecondsRealtime(0.3f);
        private Coroutine _coroutine;

        public bool TryGetLuckySave()
        {
            RandomValue = Random.Range(MinValue, MaxValue);

            if (RandomValue > BonusChances)
                return false;

            Activated();
            return true;
        }

        private void Activated()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ActivateExtraLife());
        }

        private IEnumerator ActivateExtraLife()
        {
            yield return _waitForStart;
            _nameEffectAnimation.Show();
            yield return _waitForSeconds;
            _settingsButtonGameLevel.SetValue();
            _sceneLoader.RevivePlatform();
            _brickCounter.TryVictory();
        }
    }
}