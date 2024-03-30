using System.Collections;
using UnityEngine;

namespace ModificationFiles.DebuffsFiles
{
    public class PaddleLag : Modification
    {
        [SerializeField] private float _speedChanger;

        private float _startSpeed;

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(OnPaddleLagActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Stop();
        }

        private void Stop()
        {
            SetActive(false);
            BaseMovement.SetValue(_startSpeed);
        }

        private IEnumerator OnPaddleLagActivated()
        {
            SetActive(true);
            _startSpeed = BaseMovement.Speed;
            BaseMovement.SetValue(_startSpeed / _speedChanger);
            yield return WaitForSeconds;
            Stop();
            Player.DeleteEffect(this);
        }
    }
}