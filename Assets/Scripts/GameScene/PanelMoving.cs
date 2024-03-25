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
            _reviveScreen.Lose += PanelMover;
            _brickCounter.AllBrickDestroy += PanelMover;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= PanelMover;
            _reviveScreen.Lose -= PanelMover;
        }

        private void PanelMover()
        {
            _uiAnimations.Close();
        }
    }
}