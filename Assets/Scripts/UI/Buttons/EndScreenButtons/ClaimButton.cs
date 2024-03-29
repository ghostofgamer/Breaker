using System.Collections;
using TMPro;
using UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons.EndScreenButtons
{
    public class ClaimButton : AbstractButton
    {
        [SerializeField] private LevelCompleteScreen _levelCompleteScreen;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private TMP_Text _creditsTxt;
        [SerializeField] private Image _creditIcon;
        [SerializeField] private ClaimRewardButton _claimRewardButton;
        [SerializeField] private TMP_Text _claimTxt;
        [SerializeField] private AudioSource _audioSource;

        private int _credits = 0;
        private float _endTime = 1f;
        private float _elapsedTime = 0;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
        private WaitForSeconds _waitForSound = new WaitForSeconds(0.1f);

        private void Start()
        {
            Button.interactable = false;
        }

        public void SetValue(int credits)
        {
            StartCoroutine(EnableSetValue(credits));
        }

        protected override void OnClick()
        {
            StartCoroutine(ButtonClick());
        }

        private IEnumerator ButtonClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            yield return _waitForSound;
            _levelCompleteScreen.gameObject.SetActive(false);
            _victoryScreen.OpenScreen(_credits);
        }

        private IEnumerator EnableSetValue(int credits)
        {
            _elapsedTime = 0;
            yield return _waitForSeconds;
            _creditsTxt.enabled = true;
            _creditIcon.enabled = true;
            _claimTxt.enabled = true;

            while (_elapsedTime < _endTime)
            {
                _elapsedTime += Time.deltaTime;
                float time = _elapsedTime / _endTime;
                _credits = (int)Mathf.Lerp(_credits, credits, time);
                _creditsTxt.text = _credits.ToString();
                yield return null;
            }

            Button.interactable = true;
            _credits = credits;
            _creditsTxt.text = _credits.ToString();
            _claimRewardButton.SetActive(_credits);
        }
    }
}