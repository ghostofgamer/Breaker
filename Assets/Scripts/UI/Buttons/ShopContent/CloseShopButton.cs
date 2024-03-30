using CameraFiles;
using Levels;
using UI.Screens;
using UnityEngine;

namespace UI.Buttons.ShopContent
{
    public class CloseShopButton : AbstractButton
    {
        [SerializeField] private CameraMover _cameraMover;
        [SerializeField] private Level[] _levels;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private ColliderToggle _colliderToggle;

        private BoxCollider[] _levelColliders;

        private void Awake()
        {
            _levelColliders = new BoxCollider[_levels.Length];
            for (int i = 0; i < _levels.Length; i++)
            {
                _levelColliders[i] = _levels[i].GetComponent<BoxCollider>();
            }
        }

        protected override void OnClick()
        {
            if (_colliderToggle != null)
                _colliderToggle.ColliderActivation();

            if (_cameraMover != null && !_cameraMover.enabled)
                _cameraMover.enabled = true;

            if (_levelColliders.Length > 0)
            {
                foreach (var levelCollider in _levelColliders)
                    levelCollider.enabled = true;
            }

            _shopScreen.Close();
        }
    }
}