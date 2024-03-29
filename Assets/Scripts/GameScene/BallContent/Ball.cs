using PlayerFiles;
using PlayerFiles.PlatformaContent;
using Statistics;
using UnityEngine;

namespace GameScene.BallContent
{
    [RequireComponent(typeof(BallMover),typeof(Rigidbody))]
    public class Ball : Player
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private PlatformaMovement _platformaMovement;
        [SerializeField] private Transform _environment;

        private BallMover _ballMover;
        private bool _isWin;
        private Rigidbody _rigidbody;
        // private float _factor = 3f;
        private float _directionForward = 1;

        public bool IsMoving { get; private set; }

        public PlatformaMovement PlatformaMovement => _platformaMovement;

        public bool IsWin => _isWin;
        
        private void Start()
        {
            _ballMover = GetComponent<BallMover>();
            _rigidbody = GetComponent<Rigidbody>();
            OnStopMove();
        }

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnStopMove;
            _brickCounter.AllBrickDestroyed += OnSetParent;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnStopMove;
            _brickCounter.AllBrickDestroyed -= OnSetParent;
        }

        // private void Update()
        // {
        //     if (!IsMoving && !_isWin)
        //     {
        //         var position = _platformaMovement.transform.position;
        //         transform.position = new Vector3(position.x, position.y, position.z + _factor);
        //     }
        // }

        public void OnStopMove()
        {
            IsMoving = false;
            // _ballMover.enabled = false;
            _rigidbody.isKinematic = true;
        }

        public void SetMove(bool flag, float directionX)
        {
            IsMoving = flag;
            // _ballMover.enabled = flag;
            _rigidbody.isKinematic = !flag;
            _ballMover.SetStartDirection(new Vector3(directionX, 0, _directionForward).normalized);
        }

        private void OnSetParent()
        {
            _isWin = true;
            transform.parent = _environment;
        }
    }
}