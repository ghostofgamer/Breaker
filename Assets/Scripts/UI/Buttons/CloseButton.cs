using UnityEngine;

namespace UI.Buttons
{
    public class CloseButton : AbstractButton
    {
        [SerializeField] private GameObject _screen;
    
        protected override void OnClick()
        {
            _screen.SetActive(false);
        }
    }
}