using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace ModificationFiles.BuffsFiles
{
    public class Mirror : Modification
    {
        [SerializeField] private MirrorMovement _mirrorPlatformaPrefab;

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                SetCoroutine(StartCoroutine(OnGetMirrorPlatform()));
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
            Stop();
        }

        private IEnumerator OnGetMirrorPlatform()
        {
            SetActive(true);
            _mirrorPlatformaPrefab.gameObject.SetActive(true);
            yield return WaitForSeconds;
            Stop();
            Player.DeleteEffect(this);
        }

        private void Stop()
        {
            SetActive(false);
            _mirrorPlatformaPrefab.gameObject.SetActive(false);
        }
    }
}