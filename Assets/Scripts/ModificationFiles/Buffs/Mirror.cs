using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace ModificationFiles.Buffs
{
    public class Mirror : Modification
    {
        [SerializeField] private MirrorPlatformaMover _mirrorPlatformaPrefab;

        private MirrorPlatformaMover _mirrorPlatforma;

        public override void ApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                Coroutine = StartCoroutine(OnGetMirrorPlatform());
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