using PlayerFiles;
using PlayerFiles.PlatformaContent;
using Statistics;
using UnityEngine;

namespace GameScene.BallContent
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : Player
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private BaseMovement _baseMovement;
        [SerializeField] private Transform _environment;

        private bool _isWin;

        public BaseMovement BaseMovement => _baseMovement;

        public bool IsWin => _isWin;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnSetParent;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnSetParent;
        }

        private void OnSetParent()
        {
            _isWin = true;
            transform.parent = _environment;
        }
    }
}