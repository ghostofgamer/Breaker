using GameScene.BallContent;
using PlayerFiles.PlatformaContent;
using Statistics;
using UI.Screens;
using UI.Screens.EndScreens;
using UnityEngine;

namespace UI.Buttons.Settings
{
    public class SettingsButtonGameLevel : AbstractButton
    {
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private PlatformaMovement _platformaMovement;
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private BallTrigger _ball;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private AudioSource _audioSource;

        protected override void OnEnable()
        {
            base.OnEnable();
            _brickCounter.AllBrickDestroyed += SetValue;
            _ball.Dying += SetValue;
            _reviveScreen.Reviving += SetValue;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _brickCounter.AllBrickDestroyed -= SetValue;
            _ball.Dying -= SetValue;
            _reviveScreen.Reviving -= SetValue;
        }

        public void SetValue()
        {
            Button.interactable = !Button.interactable;
        }

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _platformaMovement.enabled = false;
            _platformaMovement.SetPressed(false);
            _settingsScreen.Open();
        }
    }
}