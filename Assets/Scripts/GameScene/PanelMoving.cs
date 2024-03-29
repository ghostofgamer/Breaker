using Statistics;
using UI;
using UI.Screens.EndScreens;
using UnityEngine;

namespace GameScene
{
    public class PanelMoving : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private UIAnimations _uiAnimations;

        private void OnEnable()
        {
            _reviveScreen.Losed += OnPanelMover;
            _brickCounter.AllBrickDestroyed += OnPanelMover;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnPanelMover;
            _reviveScreen.Losed -= OnPanelMover;
        }

        private void OnPanelMover()
        {
            _uiAnimations.Close();
        }
    }
}