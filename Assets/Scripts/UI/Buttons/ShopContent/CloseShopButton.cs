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
        [SerializeField] private ColliderController _colliderController;

        protected override void OnClick()
        {
            if (_colliderController != null)
                _colliderController.ColliderActivation();

            if (_cameraMover != null && !_cameraMover.enabled)
                _cameraMover.enabled = true;

            if (_levels.Length > 0)
            {
                foreach (var level in _levels)
                    level.GetComponent<BoxCollider>().enabled = true;
            }

            _shopScreen.Close();
        }
    }
}