using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace ModificationFiles
{
    public abstract class PaddleChanger : Modification
    {
        [SerializeField] private int _sizeChange;
        [SerializeField] private MirrorMovement _mirrorMovement;

        private Vector3 _standardScale;

        protected override void Start()
        {
            base.Start();
            _standardScale = BaseMovement.transform.localScale;
        }

        protected IEnumerator Resize()
        {
            EnableBuffUI();
            Change();
            yield return WaitForSeconds;
            Reset();
            Player.DeleteEffect(this);
        }

        protected void Reset()
        {
            DisableBuffUI();
            BaseMovement.transform.localScale = _standardScale;
            _mirrorMovement.transform.localScale = _standardScale;
        }

        private void Change()
        {
            Vector3 target = new Vector3(_standardScale.x, _standardScale.y + _sizeChange, _standardScale.z);
            BaseMovement.transform.localScale = target;
            _mirrorMovement.transform.localScale = target;
        }
    }
}