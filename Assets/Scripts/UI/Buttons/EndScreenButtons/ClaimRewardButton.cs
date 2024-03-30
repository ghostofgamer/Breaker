using System.Collections;
using ADS;
using TMPro;
using UnityEngine;

namespace UI.Buttons.EndScreenButtons
{
    public class ClaimRewardButton : AbstractButton
    {
        [SerializeField] private GameObject[] _infoObjects;
        [SerializeField] private TMP_Text _creditsText;
        [SerializeField] private RewardTripleCredit _rewardTripleCredit;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
        private WaitForSeconds _waitForSound = new WaitForSeconds(0.1f);
        private int _credits = 0;
        private int _factor = 3;

        public int Credits => _credits;

        public void SetActive(int credits)
        {
            gameObject.SetActive(true);
            _credits = credits * _factor;
            StartCoroutine(OpenButton());
        }

        protected override void OnClick()
        {
            StartCoroutine(ButtonClick());
        }

        private IEnumerator ButtonClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            Button.interactable = false;
            yield return _waitForSound;
            _rewardTripleCredit.Show();
        }

        private IEnumerator OpenButton()
        {
            yield return _waitForSeconds;
            _creditsText.text = _credits.ToString();

            foreach (GameObject infoObject in _infoObjects)
                infoObject.SetActive(true);
        }
    }
}