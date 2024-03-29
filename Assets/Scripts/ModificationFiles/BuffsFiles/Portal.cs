using System.Collections;
using UnityEngine;

namespace ModificationFiles.BuffsFiles
{
    public class Portal : Modification
    {
        [SerializeField] private GameObject _portal;
        [SerializeField] private BoxCollider[] _walls;

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                Coroutine = StartCoroutine(OnPortalActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            SetValue(false);
        }

        private IEnumerator OnPortalActivated()
        {
            SetValue(true);
            yield return WaitForSeconds;
            SetValue(false);
            Player.DeleteEffect(this);
        }

        private void SetValue(bool value)
        {
            SetActive(value);

            foreach (BoxCollider wall in _walls)
                wall.enabled = !value;

            BallMover.SetValue(value);
            _portal.SetActive(value);
        }
    }
}