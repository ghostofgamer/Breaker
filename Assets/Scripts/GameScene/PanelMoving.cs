using Statistics;
using UI.Screens.EndScreens;
using UnityEngine;

namespace GameScene
{
    public class PanelMoving : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private Animator _animator;

        private const string Move = "Move";

        private bool _isMove = false;

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
            _animator.Play(Move);
        }

        private void GoOffScreen()
        {
            _isMove = true;
        }
    }
}