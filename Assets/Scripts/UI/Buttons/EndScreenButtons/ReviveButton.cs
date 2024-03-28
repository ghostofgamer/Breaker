using UnityEngine;

namespace UI.Buttons.EndScreenButtons
{
    public class ReviveButton : AbstractButton
    {
        [SerializeField] private AudioSource _audioSource;

        private Coroutine _coroutine;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);

#if UNITY_WEBGL && !UNITY_EDITOR
           Button.interactable = false;
                   
                   _rewardRevive.Show();
#endif
        }
    }
}