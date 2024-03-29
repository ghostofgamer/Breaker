using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace ModificationFiles
{
    public abstract class PaddleChanger : Modification
    {
        [SerializeField] protected int _sizeChange;
        [SerializeField] private MirrorPlatformaMover _mirrorPlatformaMover;

        private Vector3 _standardScale;

        protected override void Start()
        {
            base.Start();
            _standardScale = PlatformaMover.transform.localScale;
        }

        protected IEnumerator Resize()
        {
            SetActive(true);
            Change();
            yield return WaitForSeconds;
            Reset();
            Player.DeleteEffect(this);
        }

        protected void Reset()
        {
            SetActive(false);
            PlatformaMover.transform.localScale = _standardScale;
            _mirrorPlatformaMover.transform.localScale = _standardScale;
        }

        private void Change()
        {
            Vector3 target = new Vector3(_standardScale.x, _standardScale.y + _sizeChange, _standardScale.z);
            PlatformaMover.transform.localScale = target;
            _mirrorPlatformaMover.transform.localScale = target;
        }
    }
}