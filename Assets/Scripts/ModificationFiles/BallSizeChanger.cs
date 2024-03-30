using System.Collections;
using GameScene.BallContent;
using UnityEngine;

namespace ModificationFiles
{
    public abstract class BallSizeChanger : Modification
    {
        [SerializeField] private float _sizeChange;
        [SerializeField] private Vector3 _standardScale;

        protected IEnumerator Resize(BallMover ballMover)
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
            BallMover.transform.localScale = _standardScale;
        }

        private void Change()
        {
            Vector3 target = new Vector3(
                _standardScale.x + _sizeChange,
                _standardScale.y + _sizeChange,
                _standardScale.z + _sizeChange);
            BallMover.transform.localScale = target;
        }
    }
}