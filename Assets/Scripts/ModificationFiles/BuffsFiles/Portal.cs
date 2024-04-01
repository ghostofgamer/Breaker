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

                SetCoroutine(StartCoroutine(OnPortalActivated()));
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            DisablePortalEffect();
        }

        private IEnumerator OnPortalActivated()
        {
            EnablePortalEffect();
            yield return WaitForSeconds;
            DisablePortalEffect();
            Player.DeleteEffect(this);
        }

        private void EnablePortalEffect()
        {
            EnableBuffUI();

            foreach (BoxCollider wall in _walls)
                wall.enabled = false;

            BallMover.PortalActivated();
            _portal.SetActive(true);
        }

        private void DisablePortalEffect()
        {
            DisableBuffUI();

            foreach (BoxCollider wall in _walls)
                wall.enabled = true;

            BallMover.PortalDeactivation();
            _portal.SetActive(false);
        }
    }
}