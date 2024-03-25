using UI.Screens.EndScreens;
using UnityEngine;

namespace UI.Buttons.EndScreenButtons
{
    public class CloseReviveScreen : AbstractButton
    {
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private AudioSource _audioSource;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _reviveScreen.ChooseLose();
        }
    }
}