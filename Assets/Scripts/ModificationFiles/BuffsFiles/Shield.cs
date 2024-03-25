using System.Collections;
using UnityEngine;

namespace ModificationFiles.BuffsFiles
{
    public class Shield : Modification
    {
        [SerializeField] private GameObject _shield;

        public override void ApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                Coroutine = StartCoroutine(OnShieldActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Stop();
        }

        private IEnumerator OnShieldActivated()
        {
            SetActive(true);
            _shield.SetActive(true);
            yield return WaitForSeconds;
            Stop();
            Player.DeleteEffect(this);
        }

        private void Stop()
        {
            SetActive(false);
            _shield.SetActive(false);
        }
    }
}